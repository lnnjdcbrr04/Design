using Design;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Design
{
    public partial class frmStocks : Form
    {
        private const string connStr = "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;Initial Catalog=BernabestInventorySystem;Integrated Security=True;TrustServerCertificate=True";
        private DataTable _stockTable;
        public frmStocks()
        {
            InitializeComponent();
            Load += frmStocks_Load;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }
        private void frmStocks_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadStocks();
            UpdateLowStockAlert();
        }
        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductID.DataPropertyName = "Product";
            ProductID.ReadOnly = true;
            Stockin.DataPropertyName = "StockIn";
            Stockout.DataPropertyName = "StockOut";
            net.DataPropertyName = "Net";
            net.ReadOnly = true;
            Thresh.DataPropertyName = "Threshold";
            DataGridViewButtonColumn Updateed = new DataGridViewButtonColumn();
            Updateed.Text = "Save";
            Updateed.UseColumnTextForButtonValue = true;

        }
        private void LoadStocks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_GetStocks", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        _stockTable = new DataTable();
                        adapter.Fill(_stockTable);
                        dataGridView1.DataSource = _stockTable;
                    }
                }
                HighlightLowStockRows();
                UpdateLowStockAlert();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load stocks.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HighlightLowStockRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                int netQty = Convert.ToInt32(row.Cells["net"].Value ?? 0);
                int threshold = Convert.ToInt32(row.Cells["Thresh"].Value ?? 0);
                if (netQty <= threshold)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 228);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void UpdateLowStockAlert()
        {
            if (_stockTable == null || _stockTable.Rows.Count == 0)
            {
                
                return;
            }
            int lowCount = 0;
            foreach (DataRow row in _stockTable.Rows)
            {
                int net = Convert.ToInt32(row["Net"]);
                int threshold = Convert.ToInt32(row["Threshold"]);
                if (net <= threshold)
                    lowCount++;
            }
            int percent = (int)Math.Round((double)lowCount / _stockTable.Rows.Count * 100);
            
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            int stockIn = ParseInt(row.Cells["Stockin"].Value);
            int stockOut = ParseInt(row.Cells["Stockout"].Value);
            row.Cells["net"].Value = stockIn - stockOut;
            HighlightLowStockRows();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name != "Updateed") return;
            SaveStockRow(e.RowIndex);
        }
        private void SaveStockRow(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            DataRowView view = row.DataBoundItem as DataRowView;
            if (view == null) return;
            string stockId = view.Row["StockID"].ToString();
            string productId = view.Row["ProductID"].ToString();
            int stockIn = ParseInt(row.Cells["Stockin"].Value);
            int stockOut = ParseInt(row.Cells["Stockout"].Value);
            int threshold = ParseInt(row.Cells["Thresh"].Value);
            int netQty = stockIn - stockOut;
            if (threshold <= 0)
            {
                MessageBox.Show("Threshold must be greater than zero.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Stocks
                            SET StockIn = @StockIn,
                                StockOut = @StockOut,
                                Threshold = @Threshold,
                                DateUpdated = GETDATE()
                            WHERE StockID = @StockID", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@StockIn", stockIn);
                            cmd.Parameters.AddWithValue("@StockOut", stockOut);
                            cmd.Parameters.AddWithValue("@Threshold", threshold);
                            cmd.Parameters.AddWithValue("@StockID", stockId);
                            cmd.ExecuteNonQuery();
                        }
                        string status = netQty <= 0 ? "Out of Stock" : netQty <= threshold ? "Low Stock" : "Available";
                        using (SqlCommand productCmd = new SqlCommand(@"
                            UPDATE Product
                            SET QuantityInStock = @NetQty,
                                Status = @Status
                            WHERE ProductID = @ProductID", conn, tx))
                        {
                            productCmd.Parameters.AddWithValue("@NetQty", netQty);
                            productCmd.Parameters.AddWithValue("@Status", status);
                            productCmd.Parameters.AddWithValue("@ProductID", productId);
                            productCmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                }
                row.Cells["net"].Value = netQty;
                view.Row["Net"] = netQty;
                view.Row.AcceptChanges();
                HighlightLowStockRows();
                UpdateLowStockAlert();
                MessageBox.Show("Stock updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update stock.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadStocks();
            }
        }
        private static int ParseInt(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : 0;
        }
        private void progressBar1_Click(object sender, EventArgs e) { }
        private void btnStkDsh_Click(object sender, EventArgs e)
        {
            frmDashboard stk = new frmDashboard();
            stk.Show();
            this.Close();
        }
        private void btnStkProd_Click(object sender, EventArgs e)
        {
            frmProducts prd = new frmProducts();
            prd.Show();
            this.Close();
        }
        private void btnStkTrans_Click(object sender, EventArgs e)
        {
            frmTransaction prd = new frmTransaction();
            prd.Show();
            this.Close();
        }
        private void btnStkOrders_Click(object sender, EventArgs e)
        {
            frmOrders prd = new frmOrders();
            prd.Show();
            this.Close();
        }
        private void btnStkUsers_Click(object sender, EventArgs e)
        {
            frmUsers prd = new frmUsers();
            prd.Show();
            this.Close();
        }

        private void btnStkLogout_Click(object sender, EventArgs e)
        {
            Login stk = new Login();
            stk.Show();
            this.Close();
        }
    }
}
