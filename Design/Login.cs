using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string contString = "Data Source=DESKTOP-3ASQD5D\\SQLEXPRESS01;Initial Catalog=BernabestInventorySystem;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(contString))

            {
                try
                {

                    con.Open();


                    string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password";


                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);


                    int count = (int)cmd.ExecuteScalar();


                    if (count > 0)

                    {

                        MessageBox.Show("Login successful!");


                        frmDashboard dashboard = new frmDashboard();

                        dashboard.Show();

                        this.Hide();

                    }

                    else
                    {

                        MessageBox.Show("Invalid username or password");

                    }

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error: " + ex.Message);

                }
            }

        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '⁕';

            }
        }
    }
}