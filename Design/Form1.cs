using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnDbProd_Click(object sender, EventArgs e)
        {
            frmProducts  db = new frmProducts();
            db.Show();
            this.Close();
        }

        private void btnDbStocks_Click(object sender, EventArgs e)
        {
            frmStocks db = new frmStocks();
            db.Show();
            this.Close();
        }

        private void btnDbTrans_Click(object sender, EventArgs e)
        {
            frmTransaction db = new frmTransaction();
            db.Show();
            this.Close();
        }

        private void btnDbOrders_Click(object sender, EventArgs e)
        {
            frmOrders db = new frmOrders();
            db.Show();
            this.Close();
        }

        private void btnDbUsers_Click(object sender, EventArgs e)
        {
            frmUsers db = new frmUsers();
            db.Show();
            this.Close();
        }
    }
}
