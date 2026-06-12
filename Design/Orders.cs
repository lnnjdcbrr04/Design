using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Design
{
    public partial class frmOrders : Form
    {
        private const string connStr = "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;Initial Catalog=BernabestInventorySystem;Integrated Security=True;TrustServerCertificate=True";
        private string _selectedOrderID = null;
        private string _receiptStanOrderID = null;
        private string _receiptCustomOrderID = null;
        private string _printReceiptText = null;

        public frmOrders()
        {
            InitializeComponent();
            this.Load += Orders_Load;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            dtpDateStan.Value = DateTime.Today;
            dtpDateCustom.Value = DateTime.Today;
            dtpDateList.Value = DateTime.Today;
            dtpDateList.Tag = false;


            LoadStatusCombo(cmbStandStatus);
            LoadStatusCombo(cmbCustomStatus);
            LoadStatusCombo(cmbListStatus);
            LoadProductCombo();
            LoadFlavorCombo();
            LoadSizeCombo();
            LoadFrostingCombo();

            nudQty.Minimum = 0;
            nudQty.Value = 0;

            SetupOrderGrid();
            txtSearch.Text = "";
            LoadOrderList();

            WireStandardTotals();
            WireCustomTotals();
            WireNavigation();
            WireListFilters();

        }

        private void WireNavigation()
        {
            btnOrdDsh.Click += (s, e) => Navigate(new frmDashboard());
            btnOrdProd.Click += (s, e) => Navigate(new frmProducts());
            btnOrdStocks.Click += (s, e) => Navigate(new frmStocks());
            btnOrdTrans.Click += (s, e) => Navigate(new frmTransaction());
            btnTransUsers.Click += (s, e) => Navigate(new frmUsers());
            btnTransLogout.Click += btnTransLogout_Click;
        }

        private void Navigate(Form next)
        {
            next.Show();
            Close();
        }

        private void btnTransLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            new Login().Show();
            Close();
        }

        private void WireListFilters()
        {
            guna2DataGridView1.CellDoubleClick += OrderGrid_CellDoubleClick;
            cmbListStatus.SelectedIndexChanged += (s, e) => LoadOrderList();
            txtSearch.TextChanged += (s, e) => LoadOrderList();
            dtpDateList.ValueChanged += (s, e) =>
            {
                dtpDateList.Tag = true;   // user picked a date — enable date filter
                LoadOrderList();
            };
        }


        private void LoadStatusCombo(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.Items.Add("-- Select Status --");
            string[] statuses = { "Pending", "Confirmed", "In Progress", "Ready", "Done", "Cancelled" };
            foreach (var s in statuses) cmb.Items.Add(s);
            cmb.SelectedIndex = 0;
        }

        private void LoadProductCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Display");
            dt.Columns.Add("Price", typeof(decimal));

            var blank = dt.NewRow();
            blank["ProductID"] = DBNull.Value;
            blank["Display"] = "-- Select Product --";
            blank["Price"] = DBNull.Value;
            dt.Rows.Add(blank);

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT ProductID, ProductName, Price FROM Product WHERE Status='Available' ORDER BY CategoryID, ProductName",
                        conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            var row = dt.NewRow();
                            row["ProductID"] = r["ProductID"].ToString();
                            row["Display"] = $"{r["ProductName"]} – ₱{Convert.ToDecimal(r["Price"]):F2}";
                            row["Price"] = Convert.ToDecimal(r["Price"]);
                            dt.Rows.Add(row);
                        }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading products: " + ex.Message); }

            cmbOrdProduct.DataSource = dt;
            cmbOrdProduct.DisplayMember = "Display";
            cmbOrdProduct.ValueMember = "ProductID";
            cmbOrdProduct.SelectedIndex = 0;
        }

        private void LoadFlavorCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add("FlavorID");
            dt.Columns.Add("Display");
            dt.Columns.Add("BasePrice", typeof(decimal));

            var blank = dt.NewRow();
            blank["FlavorID"] = DBNull.Value;
            blank["Display"] = "-- Select Flavor --";
            blank["BasePrice"] = DBNull.Value;
            dt.Rows.Add(blank);

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT FlavorID, FlavorName, BasePrice FROM CakeFlavors ORDER BY FlavorName", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            var row = dt.NewRow();
                            row["FlavorID"] = r["FlavorID"].ToString();
                            row["Display"] = r["FlavorName"].ToString();
                            row["BasePrice"] = Convert.ToDecimal(r["BasePrice"]);
                            dt.Rows.Add(row);
                        }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading flavors: " + ex.Message); }

            cmbFlavor.DataSource = dt;
            cmbFlavor.DisplayMember = "Display";
            cmbFlavor.ValueMember = "FlavorID";
            cmbFlavor.SelectedIndex = 0;
        }

        private void LoadSizeCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add("SizeID");
            dt.Columns.Add("Display");
            dt.Columns.Add("PriceAdder", typeof(decimal));

            var blank = dt.NewRow();
            blank["SizeID"] = DBNull.Value;
            blank["Display"] = "-- Select Size --";
            blank["PriceAdder"] = DBNull.Value;
            dt.Rows.Add(blank);

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT SizeID, SizeLabel, PriceAdder FROM CakeSizes ORDER BY InchSize", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            var row = dt.NewRow();
                            row["SizeID"] = r["SizeID"].ToString();
                            row["Display"] = r["SizeLabel"].ToString();
                            row["PriceAdder"] = Convert.ToDecimal(r["PriceAdder"]);
                            dt.Rows.Add(row);
                        }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading sizes: " + ex.Message); }

            cmbSize.DataSource = dt;
            cmbSize.DisplayMember = "Display";
            cmbSize.ValueMember = "SizeID";
            cmbSize.SelectedIndex = 0;
        }

        private void LoadFrostingCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add("FrostingID");
            dt.Columns.Add("Display");
            dt.Columns.Add("PriceAdder", typeof(decimal));

            var blank = dt.NewRow();
            blank["FrostingID"] = DBNull.Value;
            blank["Display"] = "-- Select Frosting --";
            blank["PriceAdder"] = DBNull.Value;
            dt.Rows.Add(blank);

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT FrostingID, FrostingName, PriceAdder FROM FrostingTypes ORDER BY FrostingName", conn);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            var row = dt.NewRow();
                            row["FrostingID"] = r["FrostingID"].ToString();
                            row["Display"] = r["FrostingName"].ToString();
                            row["PriceAdder"] = Convert.ToDecimal(r["PriceAdder"]);
                            dt.Rows.Add(row);
                        }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading frostings: " + ex.Message); }

            cmbFrosting.DataSource = dt;
            cmbFrosting.DisplayMember = "Display";
            cmbFrosting.ValueMember = "FrostingID";
            cmbFrosting.SelectedIndex = 0;
        }

        private decimal GetComboPrice(ComboBox cmb, string priceColumn)
        {
            if (cmb.SelectedIndex <= 0) return 0;
            if (cmb.SelectedItem is DataRowView drv && drv[priceColumn] != DBNull.Value)
                return Convert.ToDecimal(drv[priceColumn]);
            return 0;
        }

        private string GetComboID(ComboBox cmb, string idColumn)
        {
            if (cmb.SelectedIndex <= 0) return null;
            if (cmb.SelectedItem is DataRowView drv && drv[idColumn] != DBNull.Value)
                return drv[idColumn].ToString();
            return null;
        }

        private void SelectComboByValue(ComboBox cmb, string value)
        {
            if (string.IsNullOrEmpty(value)) { cmb.SelectedIndex = 0; return; }
            cmb.SelectedValue = value;
            if (cmb.SelectedIndex < 0) cmb.SelectedIndex = 0;
        }

        private void SelectStatusCombo(ComboBox cmb, string status)
        {
            if (string.IsNullOrEmpty(status)) { cmb.SelectedIndex = 0; return; }
            int idx = cmb.Items.IndexOf(status);
            cmb.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private string GetSpecialMessage()
        {
            string msg = textBox7.Text.Trim();
            return msg == "e.g Happy Birthday!" ? "" : msg;
        }

        private void WireStandardTotals()
        {
            cmbOrdProduct.SelectedIndexChanged += (s, e) => RecalcStandard();
            nudQty.ValueChanged += (s, e) => RecalcStandard();
            checkBox1.CheckedChanged += (s, e) => RecalcStandard();
            checkBox10.CheckedChanged += (s, e) => RecalcStandard();
            checkBox2.CheckedChanged += (s, e) => RecalcStandard();
            checkBox3.CheckedChanged += (s, e) => RecalcStandard();
            checkBox4.CheckedChanged += (s, e) => RecalcStandard();
        }

        private void RecalcStandard()
        {
            decimal itemSub = GetComboPrice(cmbOrdProduct, "Price") * (int)nudQty.Value;
            decimal addOns = CalcAddOns(
                checkBox1.Checked, 0,
                checkBox10.Checked, 0,
                checkBox2.Checked,
                checkBox3.Checked,
                checkBox4.Checked);

            lblStanItemSub.Text = itemSub.ToString("F2");
            lblStanAddOns.Text = addOns.ToString("F2");
            lblStanTotal.Text = (itemSub + addOns).ToString("F2");
        }

        private void WireCustomTotals()
        {
            cmbFlavor.SelectedIndexChanged += (s, e) => RecalcCustom();
            cmbSize.SelectedIndexChanged += (s, e) => RecalcCustom();
            cmbFrosting.SelectedIndexChanged += (s, e) => RecalcCustom();
            checkBox8.CheckedChanged += (s, e) => RecalcCustom();
            checkBox9.CheckedChanged += (s, e) => RecalcCustom();
            checkBox7.CheckedChanged += (s, e) => RecalcCustom();
            checkBox6.CheckedChanged += (s, e) => RecalcCustom();
            checkBox5.CheckedChanged += (s, e) => RecalcCustom();
        }

        private void RecalcCustom()
        {
            decimal cakeSub = GetComboPrice(cmbFlavor, "BasePrice")
                            + GetComboPrice(cmbSize, "PriceAdder")
                            + GetComboPrice(cmbFrosting, "PriceAdder");

            decimal addOns = CalcAddOns(
                checkBox8.Checked, 0,
                checkBox9.Checked, 0,
                checkBox7.Checked,
                checkBox6.Checked,
                checkBox5.Checked);

            lblCusItemSub.Text = cakeSub.ToString("F2");
            lblCusAddOns.Text = addOns.ToString("F2");
            lblCusTotal.Text = (cakeSub + addOns).ToString("F2");
        }

        private decimal CalcAddOns(bool candles, int candleQty, bool numCandles, int numCandleQty,
                                   bool topperBasic, bool topperCustom, bool rush)
        {
            decimal total = 0;
            if (candles) total += 50 * (candleQty > 0 ? candleQty : 1);
            if (numCandles) total += 80 * (numCandleQty > 0 ? numCandleQty : 1);
            if (topperBasic) total += 120;
            if (topperCustom) total += 250;
            if (rush) total += 300;
            return total;
        }

        private void btnSaveOrderStan_Click(object sender, EventArgs e)
        {
            if (!ValidateStandardForm(out string productID)) return;

            decimal itemSub = decimal.Parse(lblStanItemSub.Text);
            decimal addOns = decimal.Parse(lblStanAddOns.Text);
            decimal total = decimal.Parse(lblStanTotal.Text);
            string orderID = GenerateOrderID();

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        var cmdO = new SqlCommand(@"
                            INSERT INTO Orders
                            (OrderID, OrderType, ProductID, Quantity, OrderStatus, CustomerName, ContactNo,
                             CreatedByUserID, ProductSubTotal, AddOnsTotal, TotalAmount, PickupDate, Notes)
                            VALUES
                            (@oid,'Standard',@pid,@qty,@status,@cname,@cno,
                             @uid,@sub,@aot,@tot,@pickup,@notes)", conn, tran);
                        cmdO.Parameters.AddWithValue("@oid", orderID);
                        cmdO.Parameters.AddWithValue("@pid", productID);
                        cmdO.Parameters.AddWithValue("@qty", (int)nudQty.Value);
                        cmdO.Parameters.AddWithValue("@status", cmbStandStatus.SelectedItem.ToString());
                        cmdO.Parameters.AddWithValue("@cname", txtCusNameStan.Text.Trim());
                        cmdO.Parameters.AddWithValue("@cno", txtCoNoStan.Text.Trim());
                        cmdO.Parameters.AddWithValue("@uid", GetCurrentUserID());
                        cmdO.Parameters.AddWithValue("@sub", itemSub);
                        cmdO.Parameters.AddWithValue("@aot", addOns);
                        cmdO.Parameters.AddWithValue("@tot", total);
                        cmdO.Parameters.AddWithValue("@pickup", dtpDateStan.Value.Date);
                        cmdO.Parameters.AddWithValue("@notes", txtNoteStan.Text.Trim());
                        cmdO.ExecuteNonQuery();

                        InsertAddOns(conn, tran, orderID,
                            checkBox1.Checked, 0,
                            checkBox10.Checked, 0,
                            checkBox2.Checked, checkBox3.Checked, checkBox4.Checked);

                        InsertCalendarEvent(conn, tran, orderID, dtpDateStan.Value.Date,
                            $"Pickup: {txtCusNameStan.Text.Trim()} (Standard)");

                        tran.Commit();
                    }
                }

                MessageBox.Show($"Standard order {orderID} saved!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearStandardForm();
                tabList.SelectedTab = tabPage3;
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateStandardForm(out string productID)
        {
            productID = null;
            if (string.IsNullOrWhiteSpace(txtCoNoStan.Text)) { MessageBox.Show("Enter contact number."); return false; }
            if (string.IsNullOrWhiteSpace(txtCusNameStan.Text)) { MessageBox.Show("Enter customer name."); return false; }

            productID = GetComboID(cmbOrdProduct, "ProductID");
            if (productID == null) { MessageBox.Show("Select a product."); return false; }
            if (nudQty.Value <= 0) { MessageBox.Show("Quantity must be > 0."); return false; }
            if (cmbStandStatus.SelectedIndex <= 0) { MessageBox.Show("Select an order status."); return false; }
            return true;
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_receiptStanOrderID))
            {
                MessageBox.Show("Save or select an order to update first.");
                return;
            }
            if (!ValidateStandardForm(out string productID)) return;

            decimal itemSub = decimal.Parse(lblStanItemSub.Text);
            decimal addOns = decimal.Parse(lblStanAddOns.Text);
            decimal total = decimal.Parse(lblStanTotal.Text);

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        var cmd = new SqlCommand(@"
                            UPDATE Orders SET
                                ProductID=@pid, Quantity=@qty, OrderStatus=@status,
                                CustomerName=@cname, ContactNo=@cno,
                                ProductSubTotal=@sub, AddOnsTotal=@aot, TotalAmount=@tot,
                                PickupDate=@pickup, Notes=@notes
                            WHERE OrderID=@oid", conn, tran);
                        cmd.Parameters.AddWithValue("@oid", _receiptStanOrderID);
                        cmd.Parameters.AddWithValue("@pid", productID);
                        cmd.Parameters.AddWithValue("@qty", (int)nudQty.Value);
                        cmd.Parameters.AddWithValue("@status", cmbStandStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@cname", txtCusNameStan.Text.Trim());
                        cmd.Parameters.AddWithValue("@cno", txtCoNoStan.Text.Trim());
                        cmd.Parameters.AddWithValue("@sub", itemSub);
                        cmd.Parameters.AddWithValue("@aot", addOns);
                        cmd.Parameters.AddWithValue("@tot", total);
                        cmd.Parameters.AddWithValue("@pickup", dtpDateStan.Value.Date);
                        cmd.Parameters.AddWithValue("@notes", txtNoteStan.Text.Trim());
                        cmd.ExecuteNonQuery();

                        new SqlCommand("DELETE FROM OrderAddOns WHERE OrderID=@id", conn, tran)
                        { Parameters = { new SqlParameter("@id", _receiptStanOrderID) } }.ExecuteNonQuery();

                        InsertAddOns(conn, tran, _receiptStanOrderID,
                            checkBox1.Checked, 0,
                            checkBox10.Checked, 0,
                            checkBox2.Checked, checkBox3.Checked, checkBox4.Checked);

                        new SqlCommand(@"
                            UPDATE CalendarEvents SET EventDate=@dt, EventTitle=@title
                            WHERE ReferenceID=@ref AND EventType='Order'", conn, tran)
                        {
                            Parameters =
                            {
                                new SqlParameter("@dt", dtpDateStan.Value.Date),
                                new SqlParameter("@title", $"Pickup: {txtCusNameStan.Text.Trim()} (Standard)"),
                                new SqlParameter("@ref", _receiptStanOrderID)
                            }
                        }.ExecuteNonQuery();

                        tran.Commit();
                    }
                }

                MessageBox.Show($"Order {_receiptStanOrderID} updated!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveOrderCustom_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomForm(out string flavorID, out string sizeID, out string frostingID)) return;

            decimal cakeSub = decimal.Parse(lblCusItemSub.Text);
            decimal addOns = decimal.Parse(lblCusAddOns.Text);
            decimal total = decimal.Parse(lblCusTotal.Text);
            string orderID = GenerateOrderID();

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        var cmdO = new SqlCommand(@"
                            INSERT INTO Orders
                            (OrderID, OrderType, OrderStatus, CustomerName, ContactNo,
                             CreatedByUserID, FlavorID, SizeID, FrostingID,
                             SpecialMessage, Notes, CakeSubTotal, AddOnsTotal, TotalAmount, PickupDate)
                            VALUES
                            (@oid,'CustomCake',@status,@cname,@cno,
                             @uid,@flv,@sz,@fr,
                             @msg,@notes,@sub,@aot,@tot,@pickup)", conn, tran);
                        cmdO.Parameters.AddWithValue("@oid", orderID);
                        cmdO.Parameters.AddWithValue("@status", cmbCustomStatus.SelectedItem.ToString());
                        cmdO.Parameters.AddWithValue("@cname", txtCusNameCustom.Text.Trim());
                        cmdO.Parameters.AddWithValue("@cno", txtCoNoCustom.Text.Trim());
                        cmdO.Parameters.AddWithValue("@uid", GetCurrentUserID());
                        cmdO.Parameters.AddWithValue("@flv", flavorID);
                        cmdO.Parameters.AddWithValue("@sz", sizeID);
                        cmdO.Parameters.AddWithValue("@fr", frostingID);
                        cmdO.Parameters.AddWithValue("@msg", GetSpecialMessage());
                        cmdO.Parameters.AddWithValue("@notes", txtNoteCustom.Text.Trim());
                        cmdO.Parameters.AddWithValue("@sub", cakeSub);
                        cmdO.Parameters.AddWithValue("@aot", addOns);
                        cmdO.Parameters.AddWithValue("@tot", total);
                        cmdO.Parameters.AddWithValue("@pickup", dtpDateCustom.Value.Date);
                        cmdO.ExecuteNonQuery();

                        InsertAddOns(conn, tran, orderID,
                            checkBox8.Checked, 0,
                            checkBox9.Checked, 0,
                            checkBox7.Checked, checkBox6.Checked, checkBox5.Checked);

                        InsertCalendarEvent(conn, tran, orderID, dtpDateCustom.Value.Date,
                            $"Pickup: {txtCusNameCustom.Text.Trim()} (Custom Cake)");

                        tran.Commit();
                    }
                }

                MessageBox.Show($"Custom order {orderID} saved!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearCustomForm();
                tabList.SelectedTab = tabPage3;
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateCustomForm(out string flavorID, out string sizeID, out string frostingID)
        {
            flavorID = sizeID = frostingID = null;
            if (string.IsNullOrWhiteSpace(txtCoNoCustom.Text)) { MessageBox.Show("Enter contact number."); return false; }
            if (string.IsNullOrWhiteSpace(txtCusNameCustom.Text)) { MessageBox.Show("Enter customer name."); return false; }

            flavorID = GetComboID(cmbFlavor, "FlavorID");
            sizeID = GetComboID(cmbSize, "SizeID");
            frostingID = GetComboID(cmbFrosting, "FrostingID");
            if (flavorID == null) { MessageBox.Show("Select a flavor."); return false; }
            if (sizeID == null) { MessageBox.Show("Select a size."); return false; }
            if (frostingID == null) { MessageBox.Show("Select frosting."); return false; }
            if (cmbCustomStatus.SelectedIndex <= 0) { MessageBox.Show("Select an order status."); return false; }
            return true;
        }

        private void btnUpdateCustomStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_receiptCustomOrderID))
            {
                MessageBox.Show("Save or select a custom order first.");
                return;
            }
            if (cmbCustomStatus.SelectedIndex <= 0)
            {
                MessageBox.Show("Select a status to update.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "UPDATE Orders SET OrderStatus=@status WHERE OrderID=@id", conn);
                    cmd.Parameters.AddWithValue("@status", cmbCustomStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", _receiptCustomOrderID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order status updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertAddOns(SqlConnection con, SqlTransaction tran, string orderID,
            bool candles, int candleQty, bool numCandles, int numCandleQty,
            bool topperBasic, bool topperCustom, bool rush)
        {
            var addOnsToInsert = new List<(string addOnID, int qty, decimal price)>();

            if (candles) addOnsToInsert.Add(("A0001", candleQty > 0 ? candleQty : 1, 50));
            if (numCandles) addOnsToInsert.Add(("A0002", numCandleQty > 0 ? numCandleQty : 1, 80));
            if (topperBasic) addOnsToInsert.Add(("A0003", 1, 120));
            if (topperCustom) addOnsToInsert.Add(("A0004", 1, 250));
            if (rush) addOnsToInsert.Add(("A0005", 1, 300));

            int nextNum = GetNextAddOnOrderNum(con, tran);

            foreach (var (addOnID, qty, price) in addOnsToInsert)
            {
                string aoID = "A" + nextNum.ToString("D4");
                nextNum++;
                EnsureAddOn(con, tran, addOnID, price);

                var cmd = new SqlCommand(@"
                    INSERT INTO OrderAddOns (OrderAddOnID, OrderID, AddOnID, Quantity, UnitPrice)
                    VALUES (@id, @oid, @aid, @qty, @price)", con, tran);
                cmd.Parameters.AddWithValue("@id", aoID);
                cmd.Parameters.AddWithValue("@oid", orderID);
                cmd.Parameters.AddWithValue("@aid", addOnID);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
            }
        }

        private int GetNextAddOnOrderNum(SqlConnection con, SqlTransaction tran)
        {
            var cmd = new SqlCommand(
                "SELECT ISNULL(MAX(CAST(SUBSTRING(OrderAddOnID,2,4) AS INT)),0) FROM OrderAddOns", con, tran);
            return Convert.ToInt32(cmd.ExecuteScalar()) + 1;
        }

        private void EnsureAddOn(SqlConnection con, SqlTransaction tran, string addOnID, decimal price)
        {
            var names = new Dictionary<string, string>
            {
                {"A0001","Candles (Set of 12)"},
                {"A0002","Number Candles"},
                {"A0003","Cake Toppers (Basic)"},
                {"A0004","Cake Topper (Custom)"},
                {"A0005","Rush Order Fee"}
            };

            var chk = new SqlCommand("SELECT COUNT(1) FROM AddOns WHERE AddOnID=@id", con, tran);
            chk.Parameters.AddWithValue("@id", addOnID);
            int cnt = (int)chk.ExecuteScalar();
            if (cnt == 0)
            {
                bool isQtyBased = addOnID == "A0001" || addOnID == "A0002";
                var ins = new SqlCommand(@"
                    INSERT INTO AddOns (AddOnID,AddOnName,UnitPrice,IsQtyBased)
                    VALUES (@id,@name,@price,@iq)", con, tran);
                ins.Parameters.AddWithValue("@id", addOnID);
                ins.Parameters.AddWithValue("@name", names[addOnID]);
                ins.Parameters.AddWithValue("@price", price);
                ins.Parameters.AddWithValue("@iq", isQtyBased ? 1 : 0);
                ins.ExecuteNonQuery();
            }
        }

        private void InsertCalendarEvent(SqlConnection con, SqlTransaction tran,
            string refID, DateTime date, string title)
        {
            string evID = GenerateEventID();
            var cmd = new SqlCommand(@"
                INSERT INTO CalendarEvents
                (EventID, EventDate, EventTitle, EventType, ReferenceID, CreatedBy)
                VALUES (@id, @dt, @title, 'Order', @ref, @uid)", con, tran);
            cmd.Parameters.AddWithValue("@id", evID);
            cmd.Parameters.AddWithValue("@dt", date);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@ref", refID);
            cmd.Parameters.AddWithValue("@uid", GetCurrentUserID());
            cmd.ExecuteNonQuery();
        }

        private void SetupOrderGrid()
        {
            guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.Columns.Clear();

            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colID", HeaderText = "Order ID", DataPropertyName = "OrderID", Width = 70 });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Type", DataPropertyName = "OrderType", Width = 90 });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCustomer", HeaderText = "Customer", DataPropertyName = "CustomerName", Width = 160 });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colContact", HeaderText = "Contact No.", DataPropertyName = "ContactNo", Width = 100 });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Status", DataPropertyName = "OrderStatus", Width = 100 });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPickup", HeaderText = "Pickup Date", DataPropertyName = "PickupDate", Width = 110 });
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "Total (₱)", DataPropertyName = "TotalAmount", Width = 100 });

            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            guna2DataGridView1.MultiSelect = false;
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.ColumnHeadersHeight = 35;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 35;
            guna2DataGridView1.SelectionChanged += OrderGrid_SelectionChanged;
        }

        private void LoadOrderList()
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string searchText = txtSearch.Text.Trim();
                    if (searchText.Equals("SEARCH", StringComparison.OrdinalIgnoreCase))
                        searchText = "";
                    bool filterDate = (dtpDateList.Tag is bool b && b);

                    var cmd = new SqlCommand(@"
                SELECT 
                    o.OrderID,
                    o.OrderType,
                    o.CustomerName,
                    o.ContactNo,
                    o.OrderStatus,
                    CONVERT(VARCHAR, o.PickupDate, 107) AS PickupDate,
                    o.TotalAmount
                FROM Orders o
                WHERE
                    (@status = '' OR o.OrderStatus = @status)
                    AND (@search = '' OR o.CustomerName LIKE '%' + @search + '%'
                                      OR o.OrderID LIKE '%' + @search + '%')
                    AND (@filterDate = 0 OR CAST(o.PickupDate AS DATE) = @pickupDate)
                ORDER BY o.PickupDate DESC", conn);
                    cmd.Parameters.AddWithValue("@status",
                        cmbListStatus.SelectedIndex <= 0 ? "" : cmbListStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@search", searchText);
                    cmd.Parameters.AddWithValue("@filterDate", filterDate ? 1 : 0);
                    cmd.Parameters.AddWithValue("@pickupDate", dtpDateList.Value.Date);

                    var dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }
        private void OrderGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
                _selectedOrderID = guna2DataGridView1.SelectedRows[0].Cells["colID"].Value?.ToString();
        }

        private void OrderGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string orderID = guna2DataGridView1.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
            if (!string.IsNullOrEmpty(orderID))
                LoadOrderIntoForm(orderID);
        }

        private void LoadOrderIntoForm(string orderID)
        {
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        SELECT o.*, p.ProductName, cf.FlavorName, cs.SizeLabel, ft.FrostingName
                        FROM Orders o
                        LEFT JOIN Product p ON p.ProductID = o.ProductID
                        LEFT JOIN CakeFlavors cf ON cf.FlavorID = o.FlavorID
                        LEFT JOIN CakeSizes cs ON cs.SizeID = o.SizeID
                        LEFT JOIN FrostingTypes ft ON ft.FrostingID = o.FrostingID
                        WHERE o.OrderID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", orderID);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return;

                        string orderType = r["OrderType"].ToString();
                        if (orderType == "Standard")
                        {
                            tabList.SelectedTab = tabPage1;
                            _receiptStanOrderID = orderID;

                            txtCusNameStan.Text = r["CustomerName"].ToString();
                            txtCoNoStan.Text = r["ContactNo"].ToString();
                            txtNoteStan.Text = r["Notes"] != DBNull.Value ? r["Notes"].ToString() : "";
                            SelectComboByValue(cmbOrdProduct, r["ProductID"]?.ToString());
                            nudQty.Value = r["Quantity"] != DBNull.Value ? Convert.ToDecimal(r["Quantity"]) : 0;
                            dtpDateStan.Value = r["PickupDate"] != DBNull.Value ? Convert.ToDateTime(r["PickupDate"]) : DateTime.Today;
                            SelectStatusCombo(cmbStandStatus, r["OrderStatus"].ToString());
                            RecalcStandard();


                        }
                        else
                        {
                            tabList.SelectedTab = tabPage2;
                            _receiptCustomOrderID = orderID;

                            txtCusNameCustom.Text = r["CustomerName"].ToString();
                            txtCoNoCustom.Text = r["ContactNo"].ToString();
                            txtNoteCustom.Text = r["Notes"] != DBNull.Value ? r["Notes"].ToString() : "";
                            textBox7.Text = r["SpecialMessage"] != DBNull.Value && !string.IsNullOrEmpty(r["SpecialMessage"].ToString())
                                ? r["SpecialMessage"].ToString() : "e.g Happy Birthday!";
                            SelectComboByValue(cmbFlavor, r["FlavorID"]?.ToString());
                            SelectComboByValue(cmbSize, r["SizeID"]?.ToString());
                            SelectComboByValue(cmbFrosting, r["FrostingID"]?.ToString());
                            dtpDateCustom.Value = r["PickupDate"] != DBNull.Value ? Convert.ToDateTime(r["PickupDate"]) : DateTime.Today;
                            SelectStatusCombo(cmbCustomStatus, r["OrderStatus"].ToString());
                            RecalcCustom();

                        }
                    }
                }

                LoadOrderAddOnCheckboxes(orderID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderAddOnCheckboxes(string orderID)
        {
            checkBox1.Checked = checkBox10.Checked = checkBox2.Checked =
            checkBox3.Checked = checkBox4.Checked = false;
            checkBox5.Checked = checkBox6.Checked = checkBox7.Checked =
            checkBox8.Checked = checkBox9.Checked = false;

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT AddOnID FROM OrderAddOns WHERE OrderID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", orderID);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                        {
                            switch (r["AddOnID"].ToString())
                            {
                                case "A0001":
                                    if (tabList.SelectedTab == tabPage1) checkBox1.Checked = true;
                                    else checkBox8.Checked = true;
                                    break;
                                case "A0002":
                                    if (tabList.SelectedTab == tabPage1) checkBox10.Checked = true;
                                    else checkBox9.Checked = true;
                                    break;
                                case "A0003":
                                    if (tabList.SelectedTab == tabPage1) checkBox2.Checked = true;
                                    else checkBox7.Checked = true;
                                    break;
                                case "A0004":
                                    if (tabList.SelectedTab == tabPage1) checkBox3.Checked = true;
                                    else checkBox6.Checked = true;
                                    break;
                                case "A0005":
                                    if (tabList.SelectedTab == tabPage1) checkBox4.Checked = true;
                                    else checkBox5.Checked = true;
                                    break;
                            }
                        }
                }
            }
            catch { }

            if (tabList.SelectedTab == tabPage1) RecalcStandard();
            else RecalcCustom();
        }



        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            string orderID = ResolveDeleteOrderID();
            if (orderID == null) { MessageBox.Show("Select an order first."); return; }
            if (MessageBox.Show($"Delete order {orderID}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"
                        DELETE FROM OrderAddOns WHERE OrderID=@id;
                        DELETE FROM CalendarEvents WHERE ReferenceID=@id;
                        DELETE FROM Orders WHERE OrderID=@id;", conn);
                    cmd.Parameters.AddWithValue("@id", orderID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Order deleted.");

                _selectedOrderID = null;
                LoadOrderList();
            }
            catch (Exception ex) { MessageBox.Show("Error deleting order: " + ex.Message); }
        }

        private string ResolveDeleteOrderID()
        {
            if (tabList.SelectedTab == tabPage1 && !string.IsNullOrEmpty(_receiptStanOrderID))
                return _receiptStanOrderID;
            if (tabList.SelectedTab == tabPage2 && !string.IsNullOrEmpty(_receiptCustomOrderID))
                return _receiptCustomOrderID;
            return _selectedOrderID;
        }

        private void ClearStandardForm()
        {
            txtCusNameStan.Clear();
            txtCoNoStan.Clear();
            txtNoteStan.Clear();
            cmbOrdProduct.SelectedIndex = 0;
            nudQty.Value = 0;
            dtpDateStan.Value = DateTime.Today;
            cmbStandStatus.SelectedIndex = 0;
            checkBox1.Checked = checkBox10.Checked =
            checkBox2.Checked = checkBox3.Checked =
            checkBox4.Checked = false;
            lblStanItemSub.Text = "00.00";
            lblStanAddOns.Text = "00.00";
            lblStanTotal.Text = "00.00";
        }

        private void ClearCustomForm()
        {
            txtCusNameCustom.Clear();
            txtCoNoCustom.Clear();
            txtNoteCustom.Clear();
            textBox7.Text = "e.g Happy Birthday!";
            cmbFlavor.SelectedIndex = cmbSize.SelectedIndex = cmbFrosting.SelectedIndex = 0;
            cmbCustomStatus.SelectedIndex = 0;
            dtpDateCustom.Value = DateTime.Today;
            checkBox8.Checked = checkBox9.Checked = checkBox7.Checked =
            checkBox6.Checked = checkBox5.Checked = false;
            lblCusItemSub.Text = "00.00";
            lblCusAddOns.Text = "00.00";
            lblCusTotal.Text = "00.00";
        }

        private string GenerateOrderID()
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(OrderID,2,4) AS INT)) FROM Orders", conn);
                var res = cmd.ExecuteScalar();
                int next = (res == DBNull.Value ? 0 : Convert.ToInt32(res)) + 1;
                return "O" + next.ToString("D4");
            }
        }

        private string GenerateEventID()
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(EventID,2,4) AS INT)) FROM CalendarEvents", conn);
                var res = cmd.ExecuteScalar();
                int next = (res == DBNull.Value ? 0 : Convert.ToInt32(res)) + 1;
                return "E" + next.ToString("D4");
            }
        }

        private string GetCurrentUserID() => Session.CurrentUserID ?? "U0001";

        private void checkBox9_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox10_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox4_CheckedChanged(object sender, EventArgs e) { }
        private void label45_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void label40_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
    }

    public static class Session
    {
        public static string CurrentUserID { get; set; }
        public static string CurrentUsername { get; set; }
        public static string CurrentRole { get; set; }
    }
}