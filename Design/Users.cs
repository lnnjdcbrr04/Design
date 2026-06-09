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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            frmProducts usr = new frmProducts();
            usr.Show();
            this.Close();
        }

        private void btnUsrDsh_Click(object sender, EventArgs e)
        {
            frmDb usr = new frmDb();
            usr.Show();
            this.Close();
        }

        private void btnUsrStocks_Click(object sender, EventArgs e)
        {
            frmStocks usr = new frmStocks();
            usr.Show();
            this.Close();
        }

        private void btnUsrTrans_Click(object sender, EventArgs e)
        {
            frmTransaction usr = new frmTransaction();
            usr.Show();
            this.Close();
        }

        private void btnUsrOrders_Click(object sender, EventArgs e)
        {
            frmOrders usr = new frmOrders();
            usr.Show();
            this.Close();
        }
    }
}
