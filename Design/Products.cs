using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Design
{
    public partial class frmProducts : Form
    {
        private const string connStr = "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;Initial Catalog=BernabestInventorySystem;Integrated Security=True;TrustServerCertificate=True";
        public frmProducts()
        {
            InitializeComponent();
            Load += frmProducts_Load;
            btnAddProduct.Click += btnAddProduct_Click;
            btnEditProduct.Click += btnEditProduct_Click;
            
            btnDelProduct.Click += btnDelProduct_Click;
            cmbProdCategory.SelectedIndexChanged += FilterCombo_Changed;
            cmbProdStatus.SelectedIndexChanged += FilterCombo_Changed;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadFilterCombos();
            LoadDetailCombos();
            ConfigureGrid();
            LoadProducts();
        }

        private void LoadFilterCombos()
        {
            cmbProdCategory.Items.Clear();
            cmbProdCategory.Items.Add("All Category");

            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                "SELECT CategoryName FROM Category ORDER BY CategoryName", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbProdCategory.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load category filters.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cmbProdStatus.Items.Clear();
            cmbProdStatus.Items.Add("All Status");
            cmbProdStatus.Items.AddRange(new object[]
            {
                "Available", "Out of Stock", "Low Stock",
                "Expired", "Sold Out Today", "Inactive"
            });

            cmbProdCategory.SelectedIndex = 0;
            cmbProdStatus.SelectedIndex = 0;
        }

        private void LoadDetailCombos()
        {
            cmbProduct.Items.Clear();
            cmbProduct.Items.Add("-- Select Category --");

            cmdStatus.Items.Clear();
            cmdStatus.Items.Add("-- Select Status --");
            cmdStatus.Items.AddRange(new object[]
            {
                "Available", "Out of Stock", "Low Stock",
                "Expired", "Sold Out Today", "Inactive"
            });

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CategoryName FROM Category ORDER BY CategoryName", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbProduct.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load categories.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbProduct.SelectedIndex = 0;
            cmdStatus.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            string category = NormalizeFilter(cmbProdCategory.Text, "All Category");
            string status = NormalizeFilter(cmbProdStatus.Text, "All Status");

            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_GetProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", category);
                    cmd.Parameters.AddWithValue("@Status", status);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvProducts.DataSource = table;
                    }
                }

                ApplyStatusColors();
            }
            catch (SqlException ex) when (ex.Number == 2812) 
            {
                LoadProductsDirect(category, status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load products.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductsDirect(string category, string status)
        {
            const string sql = @"
                SELECT
                    p.ProductID,
                    p.ProductName,
                    c.CategoryName AS Category,
                    p.Price,
                    p.QuantityInStock AS Qty,
                    ISNULL(p.Description, '') AS Description,
                    p.Status
                FROM Product p
                INNER JOIN Category c ON p.CategoryID = c.CategoryID
                WHERE (@CategoryName = 'All' OR c.CategoryName = @CategoryName)
                  AND (@Status = 'All' OR p.Status = @Status)
                ORDER BY c.CategoryName, p.ProductName";

            using(SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CategoryName", category);
                cmd.Parameters.AddWithValue("@Status", status);
                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvProducts.DataSource = table;
                }
            }

            ApplyStatusColors();
        }

        private static string NormalizeFilter(string value, string allLabel)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Trim().Equals(allLabel, StringComparison.OrdinalIgnoreCase) ||
                value.Trim().StartsWith("All", StringComparison.OrdinalIgnoreCase))
                return "All";

            return value.Trim();
        }

        private void ConfigureGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

            ProductID.DataPropertyName = "ProductID";
            ProdName.DataPropertyName = "ProductName";
            Category.DataPropertyName = "Category";
            Price.DataPropertyName = "Price";
            Qty.DataPropertyName = "Qty";
            Descritpion.DataPropertyName = "Description";
            Status.DataPropertyName = "Status";

            Price.DefaultCellStyle.Format = "N2";
        }

        private void ApplyStatusColors()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.IsNewRow) continue;

                string status = row.Cells["Status"].Value?.ToString() ?? string.Empty;
                Color backColor = Color.White;
                Color foreColor = Color.Black;

                switch (status)
                {
                    case "Available":
                        backColor = Color.FromArgb(234, 243, 222);
                        foreColor = Color.FromArgb(59, 109, 17);
                        break;
                    case "Low Stock":
                        backColor = Color.FromArgb(250, 238, 218);
                        foreColor = Color.FromArgb(133, 79, 11);
                        break;
                    case "Out of Stock":
                    case "Sold Out Today":
                        backColor = Color.FromArgb(252, 235, 235);
                        foreColor = Color.FromArgb(163, 45, 45);
                        break;
                    case "Expired":
                    case "Inactive":
                        backColor = Color.FromArgb(230, 230, 230);
                        foreColor = Color.FromArgb(80, 80, 80);
                        break;
                }

                row.DefaultCellStyle.BackColor = backColor;
                row.DefaultCellStyle.ForeColor = foreColor;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void FilterCombo_Changed(object sender, EventArgs e)
        {
            if (cmbProdCategory.SelectedIndex >= 0 && cmbProdStatus.SelectedIndex >= 0)
                LoadProducts();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.IsNewRow)
                return;

            DataGridViewRow row = dgvProducts.CurrentRow;
            txtProductID.Text = row.Cells["ProductID"].Value?.ToString();
            txtProdName.Text = row.Cells["ProdName"].Value?.ToString();

            if (row.Cells["Price"].Value != null &&
                decimal.TryParse(row.Cells["Price"].Value.ToString(), out decimal price))
                txtProdPrice.Text = price.ToString("N2", CultureInfo.CurrentCulture);
            else
                txtProdPrice.Text = row.Cells["Price"].Value?.ToString();

            txtProdQty.Text = row.Cells["Qty"].Value?.ToString();
            txtProdDesc.Text = row.Cells["Descritpion"].Value?.ToString();

            string category = row.Cells["Category"].Value?.ToString();
            if (!string.IsNullOrEmpty(category) && cmbProduct.Items.Contains(category))
                cmbProduct.SelectedItem = category;

            string status = row.Cells["Status"].Value?.ToString();
            if (!string.IsNullOrEmpty(status) && cmdStatus.Items.Contains(status))
                cmdStatus.SelectedItem = status;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal price, out int qty))
                return;

            try
            {
                string categoryId = GetCategoryId(cmbProduct.Text);
                if (categoryId == null)
                {
                    MessageBox.Show("Please select a valid category.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO Product
                                (ProductID, ProductName, CategoryID, UnitSize, Price,
                                 QuantityInStock, Description, DateProduced, ExpirationDate, Status)
                            VALUES
                                (@ProductID, @ProductName, @CategoryID, @UnitSize, @Price,
                                 @Qty, @Description, GETDATE(), DATEADD(DAY, 3, GETDATE()), @Status)", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                            cmd.Parameters.AddWithValue("@ProductName", txtProdName.Text.Trim());
                            cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                            cmd.Parameters.AddWithValue("@UnitSize", "Piece");
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Qty", qty);
                            cmd.Parameters.AddWithValue("@Description",
                                string.IsNullOrWhiteSpace(txtProdDesc.Text)
                                    ? (object)DBNull.Value
                                    : txtProdDesc.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", cmdStatus.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand stockCmd = new SqlCommand(@"
                            INSERT INTO Stocks (StockID, ProductID, StockIn, StockOut, Threshold)
                            VALUES (@StockID, @ProductID, @StockIn, 0, 10)", conn, tx))
                        {
                            stockCmd.Parameters.AddWithValue("@StockID",
                                GenerateNextId(conn, tx, "Stocks", "StockID", "S"));
                            stockCmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                            stockCmd.Parameters.AddWithValue("@StockIn", qty);
                            stockCmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Product added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProducts();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Product ID already exists.", "Duplicate ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add product.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Select a product to edit.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(out decimal price, out int qty))
                return;

            try
            {
                string categoryId = GetCategoryId(cmbProduct.Text);
                if (categoryId == null)
                {
                    MessageBox.Show("Please select a valid category.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Product
                            SET ProductName = @ProductName,
                                CategoryID = @CategoryID,
                                Price = @Price,
                                QuantityInStock = @Qty,
                                Description = @Description,
                                Status = @Status
                            WHERE ProductID = @ProductID", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                            cmd.Parameters.AddWithValue("@ProductName", txtProdName.Text.Trim());
                            cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Qty", qty);
                            cmd.Parameters.AddWithValue("@Description",
                                string.IsNullOrWhiteSpace(txtProdDesc.Text)
                                    ? (object)DBNull.Value
                                    : txtProdDesc.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", cmdStatus.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand stockCmd = new SqlCommand(@"
                            IF EXISTS (SELECT 1 FROM Stocks WHERE ProductID = @ProductID)
                                UPDATE Stocks
                                SET StockIn = @StockIn, DateUpdated = GETDATE()
                                WHERE ProductID = @ProductID
                            ELSE
                                INSERT INTO Stocks (StockID, ProductID, StockIn, StockOut, Threshold)
                                VALUES (@StockID, @ProductID, @StockIn, 0, 10)", conn, tx))
                        {
                            stockCmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                            stockCmd.Parameters.AddWithValue("@StockIn", qty);
                            stockCmd.Parameters.AddWithValue("@StockID",
                                GenerateNextId(conn, tx, "Stocks", "StockID", "S"));
                            stockCmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Product updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update product.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Select a product to delete.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Delete product " + txtProductID.Text.Trim() + "?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        using (SqlCommand stockCmd = new SqlCommand(
                            "DELETE FROM Stocks WHERE ProductID = @ProductID", conn, tx))
                        {
                            stockCmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                            stockCmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM Product WHERE ProductID = @ProductID", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Product deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadProducts();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "Cannot delete this product because it is used in orders or transactions.",
                    "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete product.\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out decimal price, out int qty)
        {
            price = 0;
            qty = 0;

            if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                string.IsNullOrWhiteSpace(txtProdName.Text) ||
                cmbProduct.SelectedIndex <= 0 ||
                cmdStatus.SelectedIndex <= 0)
            {
                MessageBox.Show("Fill in Product ID, Name, Category, and Status.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtProductID.Text.Trim().Length > 5)
            {
                MessageBox.Show("Product ID must be 5 characters or less (e.g. P001).",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtProdPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Enter a valid price.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtProdQty.Text, out qty) || qty < 0)
            {
                MessageBox.Show("Enter a valid quantity.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GetCategoryId(string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT CategoryID FROM Category WHERE CategoryName = @CategoryName", conn))
            {
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                conn.Open();
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        private static string GenerateNextId(SqlConnection conn, SqlTransaction tx,
            string tableName, string idColumn, string prefix)
        {
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT ISNULL(MAX(CAST(SUBSTRING({idColumn}, 2, 4) AS INT)), 0) + 1 FROM {tableName}",
                conn, tx))
            {
                int next = Convert.ToInt32(cmd.ExecuteScalar());
                return prefix + next.ToString("D3");
            }
        }

        private void ClearInputs()
        {
            txtProductID.Clear();
            txtProdName.Clear();
            txtProdPrice.Clear();
            txtProdQty.Clear();
            txtProdDesc.Clear();
            cmbProduct.SelectedIndex = 0;
            cmdStatus.SelectedIndex = 0;
        }

        private void btnProdStocks_Click(object sender, EventArgs e)
        {
            frmStocks stk = new frmStocks();
            stk.Show();
            this.Close();
        }

        private void btnProdDsh_Click(object sender, EventArgs e)
        {
            frmDashboard stk = new frmDashboard();
            stk.Show();
            this.Close();
        }

        private void btnProdTrans_Click(object sender, EventArgs e)
        {
            frmTransaction stk = new frmTransaction();
            stk.Show();
            this.Close();
        }

        private void btnProdOrders_Click(object sender, EventArgs e)
        {
            frmOrders stk = new frmOrders();
            stk.Show();
            this.Close();
        }

        private void btnProdLogout_Click(object sender, EventArgs e)
        {
            Login stk = new Login();
            stk.Show();
            this.Close();
        }

        private void btnProdUsers_Click(object sender, EventArgs e)
        {
            frmUsers stk = new frmUsers();
            stk.Show();
            this.Close();
        }

       
    }
}