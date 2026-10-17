using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthCAPTCHAImportCSV
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            SelectOrderForm order = new SelectOrderForm();
            order.ShowDialog();
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            using (var f = new SelectProductForm()) f.ShowDialog();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            using (var f = new DecorationOrderForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    // заказ сохранён — можно обновить список заказов,
                    // если окно открыто параллельно
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            using (var f = new OrderProcessingForm()) f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var user = new SelectUserForm()) user.ShowDialog();
        }
    }
}
