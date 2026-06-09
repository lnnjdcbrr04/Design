using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Design
{
    public partial class frmUsers : Form
    {
        private const string connStr = "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;Initial Catalog=BernabestInventorySystem;Integrated Security=True;TrustServerCertificate=True";

        public frmUsers()
        {
            InitializeComponent();
            this.Load += frmUsers_Load;
            dgvAll.AutoGenerateColumns = true;
            dgvAll.AllowUserToAddRows = false;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadFilterRoles();
            LoadFilterStatus();
            LoadRolesComboBox_Form();
            LoadDataGrid(dgvAll, "All");
        }

        private void btnProd_Click(object sender, EventArgs e)
        { new frmProducts().Show(); this.Close(); }

        private void btnUsrDsh_Click(object sender, EventArgs e)
        { new frmDashboard().Show(); this.Close(); }

        private void btnUsrStocks_Click(object sender, EventArgs e)
        { new frmStocks().Show(); this.Close(); }

        private void btnUsrTrans_Click(object sender, EventArgs e)
        { new frmTransaction().Show(); this.Close(); }

        private void btnUsrOrders_Click(object sender, EventArgs e)
        { new frmOrders().Show(); this.Close(); }

        private void LoadFilterRoles()
        {
            cmbRoles.Items.Clear();
            cmbRoles.Items.AddRange(new object[]
            { "-- Select Roles --",
                "All",
                "Administrator",
                "Baker",
                "Inventory Manager",
                "Owner" });
            cmbRoles.SelectedIndex = 0;
        }

        private void LoadFilterStatus()
        {
            cmbUsrStatus.Items.Clear();
            cmbUsrStatus.Items.AddRange(new object[]
            { "-- Select Status --", "All", "Active", "Inactive" });
            cmbUsrStatus.SelectedIndex = 0;
        }

        private void LoadRolesComboBox_Form()
        {
            cmbStaffRole.Items.Clear();
            cmbStaffRole.Items.AddRange(new object[]
            { "-- Select Role --", "Administrator", "Baker", "Inventory Manager", "Owner" });
            cmbStaffRole.SelectedIndex = 0;

            cmbStaffStatus.Items.Clear();
            cmbStaffStatus.Items.AddRange(new object[]
            { "-- Select Status --", "Active", "Inactive" });
            cmbStaffStatus.SelectedIndex = 0;
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = cmbRoles.SelectedItem?.ToString();
            if (role == null || role.StartsWith("--")) return;
            LoadDataGrid(dgvAll, role);
        }

        private void cmbUsrStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cmbUsrStatus.SelectedItem?.ToString();
            if (status == null || status.StartsWith("--")) return;

            string role = cmbRoles.SelectedItem?.ToString() ?? "All";
            if (role.StartsWith("--")) role = "All";
            LoadDataGrid(dgvAll, role);
        }

        private void LoadDataGrid(DataGridView dgv, string category)
        {
            string status = cmbUsrStatus.SelectedItem?.ToString() ?? "All";
            if (status.StartsWith("--")) status = "All";

            string roles = category.StartsWith("--") ? "All" : category;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT UserID, FirstName, LastName, Username, Password, Role, Status, DateCreated
                                     FROM Users
                                     WHERE (@Roles = 'All' OR Role = @Roles)
                                       AND (@Status = 'All' OR Status = @Status)
                                     ORDER BY DateCreated DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Roles", roles);
                        cmd.Parameters.AddWithValue("@Status", status);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgv.DataSource = null;
                            dgv.Columns.Clear();
                            dgv.DataSource = dt;
                        }
                    }
                }

                ConfigureGridColumns(dgv);
                ApplyRowColors(dgv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Password"))
                dgv.Columns["Password"].Visible = false;

            if (dgv.Columns.Contains("DateCreated"))
                dgv.Columns["DateCreated"].HeaderText = "Date Created";
        }

        private void ApplyRowColors(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Status"].Value == null) continue;

                string status = row.Cells["Status"].Value.ToString();
                switch (status)
                {
                    case "Active":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(234, 243, 222);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(59, 109, 17);
                        break;
                    case "Inactive":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
                        break;
                }
            }

            dgv.Refresh();
        }

        private void dgvAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAll.Rows[e.RowIndex];

            lblSelectedUserID.Text = row.Cells["UserID"].Value?.ToString() ?? "";

            string firstName = row.Cells["FirstName"].Value?.ToString() ?? "";
            string lastName = row.Cells["LastName"].Value?.ToString() ?? "";
            txtStaffname.Text = $"{firstName} {lastName}".Trim();
            txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
            txtUsrPw.Text = row.Cells["Password"].Value?.ToString() ?? "";

            string role = row.Cells["Role"].Value?.ToString() ?? "";
            string status = row.Cells["Status"].Value?.ToString() ?? "";

            cmbStaffRole.SelectedItem = cmbStaffRole.Items.Contains(role) ? role : "-- Select Role --";
            cmbStaffStatus.SelectedItem = cmbStaffStatus.Items.Contains(status) ? status : "-- Select Status --";
        }

        private string GenerateUserID(string role)
        {
            string prefix;
            switch (role)
            {
                case "Administrator": prefix = "ADM"; break;
                case "Baker": prefix = "BKR"; break;
                case "Inventory Manager": prefix = "MGR"; break;
                case "Owner": prefix = "OWN"; break;
                default: prefix = "USR"; break;
            }

            int nextNum = 1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE UserID LIKE @Prefix";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Prefix", prefix + "%");
                        int count = (int)cmd.ExecuteScalar();
                        nextNum = count + 1;
                    }
                }
            }
            catch { /* fallback to 1 */ }

            return $"{prefix}{nextNum:D2}";
        }

        private (string firstName, string lastName) SplitFullname(string fullname)
        {
            string[] parts = fullname.Trim().Split(new char[] { ' ' }, 2);
            string first = parts.Length > 0 ? parts[0] : "";
            string last = parts.Length > 1 ? parts[1] : "";
            return (first, last);
        }

        private bool ValidateForm(bool requirePassword = true)
        {
            if (string.IsNullOrWhiteSpace(txtStaffname.Text))
            { MessageBox.Show("Please enter a Fullname.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            { MessageBox.Show("Please enter a Username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (requirePassword && string.IsNullOrWhiteSpace(txtUsrPw.Text))
            { MessageBox.Show("Please enter a Password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (cmbStaffRole.SelectedItem == null || cmbStaffRole.SelectedItem.ToString().StartsWith("--"))
            { MessageBox.Show("Please select a Role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (cmbStaffStatus.SelectedItem == null || cmbStaffStatus.SelectedItem.ToString().StartsWith("--"))
            { MessageBox.Show("Please select a Status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            return true;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(requirePassword: true)) return;

            var (firstName, lastName) = SplitFullname(txtStaffname.Text);
            string role = cmbStaffRole.SelectedItem.ToString();
            string status = cmbStaffStatus.SelectedItem.ToString();
            string username = txtUsername.Text.Trim();
            string password = txtUsrPw.Text.Trim();
            string userID = GenerateUserID(role);

            if (UsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different one.",
                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO Users
                        (UserID, FirstName, LastName, Username, Password, Role, Status, DateCreated)
                        VALUES
                        (@UserID, @FirstName, @LastName, @Username, @Password, @Role, @Status, @DateCreated)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Staff '{firstName} {lastName}' added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshCurrentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding staff: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSelectedUserID.Text))
            {
                MessageBox.Show("Please select a user from the table first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm(requirePassword: false)) return;

            var (firstName, lastName) = SplitFullname(txtStaffname.Text);
            string role = cmbStaffRole.SelectedItem.ToString();
            string status = cmbStaffStatus.SelectedItem.ToString();
            string username = txtUsername.Text.Trim();
            string userID = lblSelectedUserID.Text;

            if (UsernameExists(username, userID))
            {
                MessageBox.Show("Username already exists. Please choose a different one.",
                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query;
                    if (!string.IsNullOrWhiteSpace(txtUsrPw.Text))
                    {
                        query = @"UPDATE Users SET
                                    FirstName = @FirstName,
                                    LastName  = @LastName,
                                    Username  = @Username,
                                    Password  = @Password,
                                    Role      = @Role,
                                    Status    = @Status
                                  WHERE UserID = @UserID";
                    }
                    else
                    {
                        query = @"UPDATE Users SET
                                    FirstName = @FirstName,
                                    LastName  = @LastName,
                                    Username  = @Username,
                                    Role      = @Role,
                                    Status    = @Status
                                  WHERE UserID = @UserID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Status", status);
                        if (!string.IsNullOrWhiteSpace(txtUsrPw.Text))
                            cmd.Parameters.AddWithValue("@Password", txtUsrPw.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"User '{firstName} {lastName}' updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshCurrentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating staff: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSelectedUserID.Text))
            {
                MessageBox.Show("Please select a user from the table first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userID = lblSelectedUserID.Text;
            string fullname = txtStaffname.Text;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete '{fullname}'?\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"User '{fullname}' deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshCurrentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UsernameExists(string username, string excludeUserID = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = excludeUserID == null
                        ? "SELECT COUNT(*) FROM Users WHERE Username = @Username"
                        : "SELECT COUNT(*) FROM Users WHERE Username = @Username AND UserID <> @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        if (excludeUserID != null)
                            cmd.Parameters.AddWithValue("@UserID", excludeUserID);

                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch { return false; }
        }

        private void ClearForm()
        {
            lblSelectedUserID.Text = "";
            txtStaffname.Text = "";
            txtUsername.Text = "";
            txtUsrPw.Text = "";
            cmbStaffRole.SelectedIndex = 0;
            cmbStaffStatus.SelectedIndex = 0;
        }

        private void RefreshCurrentGrid()
        {
            string cat = cmbRoles.SelectedItem?.ToString() ?? "All";
            if (cat.StartsWith("--")) cat = "All";
            LoadDataGrid(dgvAll, cat);
        }
    }
}