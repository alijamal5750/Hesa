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
    public partial class frm_BuyQty : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tblPrice = new DataTable();
        DataTable tblUnit = new DataTable();

        public frm_BuyQty()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_BuyQty_Load(object sender, EventArgs e)
        {
            //  show the varabile that cames form frm_buy and stored them in the system.properties to the textboxes of this form frm_updateqty
            txtQty.Text = (Properties.Settings.Default.item_Qty).ToString();
            txtBuyPrice.Text = (Properties.Settings.Default.item_BuyPrice).ToString();
            txtDiscount.Text = (Properties.Settings.Default.item_Discount).ToString();

            try
            {
                // bring me the units of the selected_product !
                cpxUnit.DataSource = db.readData("select * from Products_Unit where Pro_ID=" + Properties.Settings.Default.Pro_ID + "", "");
                cpxUnit.DisplayMember = "Unit_Name";
                cpxUnit.ValueMember = "Unit_ID";
            }
            catch (Exception) { }

            cpxUnit.Text = (Properties.Settings.Default.Pro_Unit).ToString();
            txtQty.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
                if (txtQty.Text == "") { MessageBox.Show("رجاءا قم بإدخال الكمية"); return; }
                if (txtBuyPrice.Text == "") { MessageBox.Show("رجاءا قم بإدخال سعر الشراء"); return; }
                if (txtDiscount.Text == "") { MessageBox.Show("رجاءا قم بإدخال الخصم"); return; }

                // to edit the variables

                Properties.Settings.Default.item_Qty = Convert.ToDecimal(txtQty.Text);
                Properties.Settings.Default.item_BuyPrice = Convert.ToDecimal(txtBuyPrice.Text);
                Properties.Settings.Default.item_Discount = Convert.ToDecimal(txtDiscount.Text);
                Properties.Settings.Default.Pro_Unit = Convert.ToString(cpxUnit.Text);
                Properties.Settings.Default.Save();

                this.Close();
                                                                                                                                                                              
        }

        private void frm_BuyQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQty.Text == "") { MessageBox.Show("رجاءا قم بإدخال الكمية"); return; }
                if (txtBuyPrice.Text == "") { MessageBox.Show("رجاءا قم بإدخال سعر الشراء"); return; }
                if (txtDiscount.Text == "") { MessageBox.Show("رجاءا قم بإدخال الخصم"); return; }

                // to edit the variables

                Properties.Settings.Default.item_Qty = Convert.ToDecimal(txtQty.Text);
                Properties.Settings.Default.item_BuyPrice = Convert.ToDecimal(txtBuyPrice.Text);
                Properties.Settings.Default.item_Discount = Convert.ToDecimal(txtDiscount.Text);
                Properties.Settings.Default.Pro_Unit = Convert.ToString(cpxUnit.Text);
                Properties.Settings.Default.Save();

                this.Close();
            }
        }

        private void frm_BuyQty_FormClosing(object sender, FormClosingEventArgs e)
        {
                try
                {
                    // select the current row that selected in datagridview
                    int index = frm_Buy.GetForm.DgvBuy.SelectedRows[0].Index;
                    frm_Buy.GetForm.DgvBuy.Rows[index].Cells[2].Value = Properties.Settings.Default.Pro_Unit;
                    frm_Buy.GetForm.DgvBuy.Rows[index].Cells[3].Value = Properties.Settings.Default.item_Qty;
                    frm_Buy.GetForm.DgvBuy.Rows[index].Cells[4].Value = Properties.Settings.Default.item_BuyPrice;
                    frm_Buy.GetForm.DgvBuy.Rows[index].Cells[5].Value = Properties.Settings.Default.item_Discount;
                }
                catch (Exception) { }
        }

        private void cpxUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // to cheack the qty of the selected product ! 
            try
            {
                // countQty its for the number of the rows (qty) of the same product and the -1 to give me the modern price of the qty of the same product ! cuz its diffrent from date to date!
                int countQty = 0;
               
                try
                {
                    countQty = Convert.ToInt32(db.readData("select Count(Pro_ID) from Products_Qty where Pro_ID=" + Properties.Settings.Default.Pro_ID + " ", "").Rows[0][0]);
                }
                catch (Exception) { }

                // to retrun the buy price of the qty
                tblPrice = db.readData("select * from Products_Qty where Pro_ID=" + Properties.Settings.Default.Pro_ID + " ", "");

                string Product_Price = tblPrice.Rows[countQty-1][4].ToString();

                // give me the the qty of the unit to cheack if it is small or lagre to check the price of the unit !
                tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + Properties.Settings.Default.Pro_ID + " and Unit_ID=N'" + cpxUnit.SelectedValue + "' ", "");

                decimal realPrice = 0;
                try
                {
                    realPrice = Convert.ToDecimal(Product_Price) / Convert.ToDecimal(tblUnit.Rows[0][3]);
                }
                catch (Exception) { }

                txtBuyPrice.Text = Math.Round(realPrice,2) + "";
            }
            catch (Exception) { }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}