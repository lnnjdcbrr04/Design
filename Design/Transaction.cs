using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Design
{
    public partial class frmTransaction : Form
    {
        private const string connStr = "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;Initial Catalog=BernabestInventorySystem;Integrated Security=True;TrustServerCertificate=True";

        public frmTransaction()
        {
            InitializeComponent();
            this.Load += frmTransaction_Load;
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
           
            LoadCategoryCombo();
            LoadStatusCombo();
            SetupGrid();
            LoadTransactions();

            cmbTransCategory.SelectedIndexChanged += (s, ev) => LoadTransactions();
            cmbTransStat.SelectedIndexChanged += (s, ev) => LoadTransactions();
        }

        
            private void btnTransDsh_Click(object sender, EventArgs e)
    => Navigate(new frmDashboard());

        private void btnTransUsers_Click(object sender, EventArgs e)
            => Navigate(new frmUsers());

        private void btnTransOrders_Click(object sender, EventArgs e)
            => Navigate(new frmOrders());

        private void btnTransStocks_Click(object sender, EventArgs e)
            => Navigate(new frmStocks());

        private void btnTransProd_Click(object sender, EventArgs e)
            => Navigate(new frmProducts());

        private void btnTransLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            new Login().Show();
            Close();
        }
        

        private void Navigate(Form next) { next.Show(); Close(); }

        private void BtnTransLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            new Login().Show();
            Close();
        }

        private void LoadCategoryCombo()
        {
            cmbTransCategory.Items.Clear();
            cmbTransCategory.Items.Add("All Category");

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            cmbTransCategory.Items.Add(
                                new CategoryItem(r["CategoryID"].ToString(),
                                                 r["CategoryName"].ToString()));
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading categories: " + ex.Message); }

            cmbTransCategory.SelectedIndex = 0;
        }

        private void LoadStatusCombo()
        {
            cmbTransStat.Items.Clear();
            cmbTransStat.Items.Add("Status");
            cmbTransStat.Items.Add("Sale");
            cmbTransStat.Items.Add("Return");
            cmbTransStat.Items.Add("Adjustment");
            cmbTransStat.SelectedIndex = 0;
        }

        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Using the exact column variable names from your designer:
            // ProductID, prod, Type, Quantity, amnt, Staff, date
            ProductID.DataPropertyName = "TransactionID";
            ProductID.HeaderText = "ID";
            ProductID.Width = 60;

            prod.DataPropertyName = "ProductName";
            prod.HeaderText = "Product";
            prod.Width = 180;

            Type.DataPropertyName = "TransType";
            Type.HeaderText = "Type";
            Type.Width = 100;

            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Qty";
            Quantity.Width = 60;

            amnt.DataPropertyName = "TotalAmount";
            amnt.HeaderText = "Amount";
            amnt.Width = 100;

            Staff.DataPropertyName = "StaffName";
            Staff.HeaderText = "Staff";
            Staff.Width = 140;

            date.DataPropertyName = "TransDate";
            date.HeaderText = "Date";
            date.Width = 140;

            dataGridView1.Columns.AddRange(
                ProductID, prod, Type, Quantity, amnt, Staff, date);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersHeight = 35;
        }

        private void LoadTransactions()
        {
            try
            {
                string typeFilter = cmbTransStat.SelectedIndex <= 0
                    ? "" : cmbTransStat.SelectedItem.ToString();
                string categoryFilter = cmbTransCategory.SelectedItem is CategoryItem cat
                    ? cat.CategoryID : "";

                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT
                            t.TransactionID,
                            p.ProductName,
                            t.TransType,
                            t.Quantity,
                            t.TotalAmount,
                            u.FirstName + ' ' + u.LastName AS StaffName,
                            CONVERT(VARCHAR, t.TransDate, 107)
                                + ' ' + CONVERT(VARCHAR, t.TransDate, 108) AS TransDate
                        FROM Transactions t
                        JOIN Product p ON p.ProductID = t.ProductID
                        JOIN Users   u ON u.UserID    = t.UserID
                        WHERE
                            (@type = '' OR t.TransType  = @type)
                            AND (@cat  = '' OR p.CategoryID = @cat)
                        ORDER BY t.TransDate DESC", conn);

                    cmd.Parameters.AddWithValue("@type", typeFilter);
                    cmd.Parameters.AddWithValue("@cat", categoryFilter);

                    var dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class CategoryItem
        {
            public string CategoryID { get; }
            public CategoryItem(string id, string name)
            { CategoryID = id; _name = name; }
            private readonly string _name;
            public override string ToString() => _name;
        }

        private void btnTransLogout_Click_1(object sender, EventArgs e)
        {
            Login stk = new Login();
            stk.Show();
            this.Close();
        }
    }
}