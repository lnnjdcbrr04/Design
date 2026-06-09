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
    public partial class frmStocks : Form
    {
        public frmStocks()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

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
    }
}
