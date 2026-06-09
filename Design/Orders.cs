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
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdDsh_Click(object sender, EventArgs e)
        {
            frmDb ord = new frmDb();
            ord.Show();
            this.Close();
        }

        private void btnOrdProd_Click(object sender, EventArgs e)
        {
            frmProducts ord = new frmProducts();
            ord.Show();
            this.Close();
        }

        private void btnOrdStocks_Click(object sender, EventArgs e)
        {
            frmStocks ord = new frmStocks();
            ord.Show();
            this.Close();
        }

        private void btnOrdTrans_Click(object sender, EventArgs e)
        {
            frmTransaction ord = new frmTransaction();
            ord.Show();
            this.Close();
        }

        private void btnOrdLogout_Click(object sender, EventArgs e)
        {
            frmDb ord = new frmDb();
            ord.Show();
            this.Close();
        }

        private void btnOrdUsers_Click(object sender, EventArgs e)
        {
            frmUsers ord = new frmUsers();
            ord.Show();
            this.Close();
        }
    }
}
