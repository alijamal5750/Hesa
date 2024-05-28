using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sales_Management
{
    public partial class frm_PayBuy : DevExpress.XtraEditors.XtraForm
    {
        public frm_PayBuy()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {  

            // cheack button ist for the saving of the order cuz if we save it or not (press رجوع) it will save the order so we will fix it

                Properties.Settings.Default.CheckButton = false;
                Properties.Settings.Default.Save();

            Close();
        }

        private void frm_PayBuy_Load(object sender, EventArgs e)
        {
            try
            {
                txtMatloub.Text = Properties.Settings.Default.TotalOrder.ToString();

            }
            catch (Exception) { }
            txtMadfou3.Text = "";
            txtBakey.Text = "0";
            txtMadfou3.Focus();
        }
         

        // to evalute the equation of the baky_price 

        private void txtMadfou3_TextChanged(object sender, EventArgs e)
        {  
            try
            {
                decimal baky=Convert.ToDecimal(txtMatloub.Text) - Convert.ToDecimal(txtMadfou3.Text);

                txtBakey.Text = Math.Round(baky,3).ToString();
            }
            catch (Exception) { }
        }


        // to save the numbers into system.properties after entered  them in the textboxes 
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtMadfou3.Text == "") { MessageBox.Show("من فضلك ادخل المبلغ المدفوع"); return; }
            if (Convert.ToDecimal(txtBakey.Text) < 0) { MessageBox.Show("لا يمكن ان يكون السعر الباقي اكبر من سعر الفاتورة الاصلي"); return; }

            // cheack button ist for the saving of the order cuz if we save it or not (press رجوع) it will save the order so we will fix it

            Properties.Settings.Default.CheckButton = true;
            Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
            Properties.Settings.Default.Bakey = Convert.ToDecimal(txtBakey.Text);
            Properties.Settings.Default.Save();

            Close();
        }


        // to save the numbers into system.properties after entered  them in the textboxes 

        private void frm_PayBuy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMadfou3.Text == "") { MessageBox.Show("من فضلك ادخل المبلغ المدفوع"); return; }
                if (Convert.ToDecimal(txtBakey.Text) < 0) { MessageBox.Show("لا يمكن ان يكون السعر الباقي اكبر من سعر الفاتورة الاصلي"); return; }

                // cheack button ist for the saving of the order cuz if we save it or not (press رجوع) it will save the order so we will fix it

                Properties.Settings.Default.CheckButton = true;
                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDecimal(txtBakey.Text);
                Properties.Settings.Default.Save();

                Close();

            }

            else if (e.KeyCode == Keys.F12)
            {
                // cheack button ist for the saving of the order cuz if we save it or not (press رجوع) it will save the order so we will fix it

                Properties.Settings.Default.CheckButton = false;
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void txtMadfou3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBakey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}