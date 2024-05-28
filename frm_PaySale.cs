﻿using System;
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
    public partial class frm_PaySale : DevExpress.XtraEditors.XtraForm
    {
        public frm_PaySale()
        {
            InitializeComponent();
        }

        private void frm_PaySale_Load(object sender, EventArgs e)
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckButton = false;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtMadfou3.Text == "") { MessageBox.Show("من فضلك ادخل المبلغ المدفوع"); return; }
            if (Convert.ToDecimal(txtBakey.Text) < 0) { MessageBox.Show("لا يمكن ان يكون المبلغ الباقي اكبر من المبلغ الاصلي للفاتورة"); return; }

            // cheack button ist for the saving of the order cuz if we save it or not (press رجوع) it will save the order so we will fix it

            Properties.Settings.Default.CheckButton = true;
            Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
            Properties.Settings.Default.Bakey = Convert.ToDecimal(txtBakey.Text);

            if (checkVisa.Checked == true)
            {
                Properties.Settings.Default.Pay_Visa = true;
            }

            else if (checkVisa.Checked == false)
            {
                Properties.Settings.Default.Pay_Visa = false;
            }
            
            Properties.Settings.Default.Save();

            Close();
        }

        private void frm_PaySale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMadfou3.Text == "") { MessageBox.Show("من فضلك ادخل المبلغ المدفوع"); return; }
                if (Convert.ToDecimal(txtBakey.Text) < 0) { MessageBox.Show("لا يمكن ان يكون المبلغ الباقي اكبر من المبلغ الاصلي للفاتورة"); return; }

                // cheack button ist for the saving of the order cuz if we save it or not (press رجوع) it will save the order so we will fix it

                Properties.Settings.Default.CheckButton = true;
                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDecimal(txtBakey.Text);

                if (checkVisa.Checked == true)
                {
                    Properties.Settings.Default.Pay_Visa = true;
                }

                else if (checkVisa.Checked == false)
                {
                    Properties.Settings.Default.Pay_Visa = false;
                }

                Properties.Settings.Default.Save();

                Close();

            }

            else if (e.KeyCode == Keys.F12)
            {
                Properties.Settings.Default.CheckButton = false;
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void txtMadfou3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal baky = Convert.ToDecimal(txtMatloub.Text) - Convert.ToDecimal(txtMadfou3.Text);

                txtBakey.Text = Math.Round(baky, 3).ToString();
            }
            catch (Exception) { }
        }

        private void txtMadfou3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }
    }
}