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
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void btnTransDsh_Click(object sender, EventArgs e)
        {
            frmDb trans= new frmDb();
            trans.Show();
            this.Close();
        }

        private void btnTransProd_Click(object sender, EventArgs e)
        {
            frmProducts trans = new frmProducts();
            trans.Show();
            this.Close();
        }

        private void btnTransStocks_Click(object sender, EventArgs e)
        {
            frmStocks trans = new frmStocks();
            trans.Show();
            this.Close();
        }

        private void btnTransOrders_Click(object sender, EventArgs e)
        {
            frmOrders trans = new frmOrders();
            trans.Show();
            this.Close();
        }

        private void btnTransUsers_Click(object sender, EventArgs e)
        {
            frmUsers trans = new frmUsers();
            trans.Show();
            this.Close();
        }
    }
}
