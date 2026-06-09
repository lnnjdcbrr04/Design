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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProdDsh_Click(object sender, EventArgs e)
        {
            frmDb prd = new frmDb();
            prd.Show();
            this.Close();
        }

        private void btnProdStocks_Click(object sender, EventArgs e)
        {
            frmStocks prd = new frmStocks();
            prd.Show();
            this.Close();
        }

        private void btnProdTrans_Click(object sender, EventArgs e)
        {
            frmTransaction prd = new frmTransaction();
            prd.Show();
            this.Close();
        }

        private void btnProdOrders_Click(object sender, EventArgs e)
        {
            frmOrders prd = new frmOrders();
            prd.Show();
            this.Close();
        }

        private void btnProdUsers_Click(object sender, EventArgs e)
        {
            frmUsers prd = new frmUsers();
            prd.Show();
            this.Close();
        }
    }
}
