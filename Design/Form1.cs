using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Design
{
    public partial class frmDashboard : Form
    {
        private const string connStr =
            "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;" +
            "Initial Catalog=BernabestInventorySystem;" +
            "Integrated Security=True;TrustServerCertificate=True";

        public frmDashboard()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadPendingOrdersGrid();
            LoadSalesChart();
            
        }

        private void LoadSummaryCards()
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    label5.Text = "Transaction";
                    lblTransac.Text = Scalar(conn,
                        @"SELECT COUNT(*) FROM Transactions
                          WHERE CAST(TransDate AS DATE) = CAST(GETDATE() AS DATE)")
                        .ToString();

                    label14.Text = "Revenue";
                    decimal revenue = ToDecimal(Scalar(conn,
                        @"SELECT ISNULL(SUM(TotalAmount),0) FROM Transactions
                          WHERE CAST(TransDate AS DATE) = CAST(GETDATE() AS DATE)
                            AND TransType = 'Sale'"));
                    lblRevenue.Text = "₱ " + revenue.ToString("N2");

                    label3.Text = "Low Stock";
                    lblLowStocks.Text = Scalar(conn,
                        @"SELECT COUNT(*) FROM Stocks
                          WHERE (StockIn - StockOut) <= Threshold")
                        .ToString();

                    
                    label20.Text = "Pendings";
                    lblPendings.Text = Scalar(conn,
                        @"SELECT COUNT(*) FROM Orders
                    WHERE OrderStatus IN ('Pending','Confirmed','In Progress')")
                        .ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary cards:\n" + ex.Message,
                    "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LoadPendingOrdersGrid()
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT TOP 20
                            o.CustomerName                              AS CustomerName,
                            ISNULL(p.ProductName,
                                cf.FlavorName + ' / ' + cs.SizeLabel)  AS ProductName,
                            ISNULL(o.Quantity, 1)                      AS Quantity,
                            CONVERT(VARCHAR, o.PickupDate, 107)        AS PickupDate,
                            o.OrderStatus                              AS OrderStatus,
                            '₱' + FORMAT(o.TotalAmount,'N2')          AS TotalAmount
                        FROM Orders o
                        LEFT JOIN Product       p  ON p.ProductID  = o.ProductID
                        LEFT JOIN CakeFlavors   cf ON cf.FlavorID  = o.FlavorID
                        LEFT JOIN CakeSizes     cs ON cs.SizeID    = o.SizeID
                        WHERE o.OrderStatus IN ('Pending','Confirmed','In Progress','Ready')
                        ORDER BY o.PickupDate ASC", conn);

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvPendings.AutoGenerateColumns = false;
                    Customer.DataPropertyName = "CustomerName";
                    product.DataPropertyName = "ProductName";
                    qty.DataPropertyName = "Quantity";
                    Pickup.DataPropertyName = "PickupDate";
                    Status.DataPropertyName = "OrderStatus";
                    Total.DataPropertyName = "TotalAmount";

                    dgvPendings.DataSource = dt;
                    dgvPendings.AllowUserToAddRows = false;
                    dgvPendings.ReadOnly = true;
                    dgvPendings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    ColorOrderRows();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders:\n" + ex.Message,
                    "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ColorOrderRows()
        {
            foreach (DataGridViewRow row in dgvPendings.Rows)
            {
                if (row.IsNewRow) continue;
                string status = row.Cells["Status"].Value?.ToString() ?? "";
                switch (status)
                {
                    case "Pending":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(133, 100, 4);
                        break;
                    case "Confirmed":
                    case "In Progress":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(207, 226, 255);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(10, 60, 140);
                        break;
                    case "Ready":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(198, 246, 213);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                        break;
                }
            }
        }

        private void LoadSalesChart()
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT
                            CONVERT(VARCHAR, TransDate, 107) AS Day,
                            ISNULL(SUM(TotalAmount), 0)      AS DaySales
                        FROM Transactions
                        WHERE TransType = 'Sale'
                          AND TransDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                        GROUP BY CAST(TransDate AS DATE),
                                 CONVERT(VARCHAR, TransDate, 107)
                        ORDER BY CAST(TransDate AS DATE) ASC", conn);

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    chMonthlySales.Series.Clear();
                    chMonthlySales.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                    chMonthlySales.ChartAreas[0].AxisX.LabelStyle.Font =
                        new Font("Times New Roman", 8f);
                    chMonthlySales.ChartAreas[0].AxisY.LabelStyle.Font =
                        new Font("Times New Roman", 8f);
                    chMonthlySales.ChartAreas[0].BackColor = Color.Linen;
                    chMonthlySales.BackColor = Color.Linen;

                    var series = new Series("Daily Sales")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.FromArgb(205, 133, 63),   
                        BorderColor = Color.SaddleBrown,
                        BorderWidth = 1,
                        IsValueShownAsLabel = true,
                        LabelFormat = "N0"
                    };

                    foreach (DataRow row in dt.Rows)
                        series.Points.AddXY(row["Day"].ToString(),
                                            Convert.ToDouble(row["DaySales"]));

                    if (dt.Rows.Count == 0)
                        for (int i = 6; i >= 0; i--)
                            series.Points.AddXY(
                                DateTime.Today.AddDays(-i).ToString("MMM d"), 0);

                    chMonthlySales.Series.Add(series);
                    chMonthlySales.Titles.Clear();
                    chMonthlySales.Titles.Add(new Title("Sales – Last 7 Days")
                    {
                        Font = new Font("Times New Roman", 11f, FontStyle.Bold),
                        ForeColor = Color.SaddleBrown
                    });
                    chMonthlySales.Legends[0].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart:\n" + ex.Message,
                    "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       


        private void Navigate(Form next) { next.Show(); this.Close(); }

        private void btnDbProd_Click(object sender, EventArgs e) => Navigate(new frmProducts());
        private void btnDbStocks_Click(object sender, EventArgs e) => Navigate(new frmStocks());
        private void btnDbTrans_Click(object sender, EventArgs e) => Navigate(new frmTransaction());
        private void btnDbOrders_Click(object sender, EventArgs e) => Navigate(new frmOrders());
        private void btnDbUsers_Click(object sender, EventArgs e) => Navigate(new frmUsers());
        private void btnDbLogout_Click(object sender, EventArgs e) 
        {
            MessageBox.Show("Are you sure you want to logout?");
            new Login().Show(); this.Close(); }


        private void guna2GradientPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }


        private static object Scalar(SqlConnection conn, string sql)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                var result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : result;
            }
        }

        private static decimal ToDecimal(object value)
        {
            try { return Convert.ToDecimal(value); }
            catch { return 0; }
        }
    }
}