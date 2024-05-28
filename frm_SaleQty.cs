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
    public partial class frm_SaleQty : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        public frm_SaleQty()
        {
            InitializeComponent();
        }

        private void frm_SaleQty_Load(object sender, EventArgs e)
        {
            //  show the varabile that cames form frm_buy and stored them in the system.properties to the textboxes of this form frm_updateqty
            txtQty.Text = (Properties.Settings.Default.item_Qty).ToString();
            txtSalePrice.Text = (Properties.Settings.Default.item_SalePrice).ToString();
            txtDiscount.Text = (Properties.Settings.Default.item_Discount).ToString();

            try
            {
                // bring me the units of the selected_product !
                cbxUnit.DataSource = db.readData("select * from Products_Unit where Pro_ID=" + Properties.Settings.Default.Pro_ID + "", "");
                cbxUnit.DisplayMember = "Unit_Name";
                cbxUnit.ValueMember = "Unit_ID";
            }
            catch (Exception) { }

            cbxUnit.Text = (Properties.Settings.Default.Pro_Unit).ToString();
            txtQty.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try {
                if (txtQty.Text == "") { MessageBox.Show("رجاءا قم بإدخال الكمية"); return; }
                if (txtSalePrice.Text == "") { MessageBox.Show("رجاءا قم بإدخال سعر البيع"); return; }
                if (txtDiscount.Text == "") { MessageBox.Show("رجاءا قم بإدخال الخصم"); return; }

                // to check the qty ! 
                DataTable check = new DataTable();
                DataTable unit = new DataTable();
                unit.Clear();
                check.Clear();

                check = db.readData("select Qty from Products where Pro_ID=" + Properties.Settings.Default.Pro_ID + " ", "");
                unit = db.readData("select * from Products_Unit where Pro_ID=" + Properties.Settings.Default.Pro_ID + " and Unit_ID=N'" + cbxUnit.SelectedValue + "' ", "");

                decimal checkQty = 0;
                decimal realqty = 0;
                decimal QtyInMain = 0;

                QtyInMain = Convert.ToDecimal(unit.Rows[0][3]);
                realqty = Convert.ToDecimal(txtQty.Text) / QtyInMain;
                checkQty = Convert.ToDecimal(check.Rows[0][0]);

                if (checkQty < Convert.ToDecimal(realqty))
                {
                    MessageBox.Show("الكمية غير متوفرة في المخزن", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // to edit the variables

                Properties.Settings.Default.item_Qty = Convert.ToDecimal(txtQty.Text);
                Properties.Settings.Default.item_SalePrice = Convert.ToDecimal(txtSalePrice.Text);

                Properties.Settings.Default.Pro_Unit = cbxUnit.Text;

                if (Properties.Settings.Default.SaleDiscountForCasher == true)
                {
                    try
                    {
                        if (Properties.Settings.Default.ItemDiscount == "Value")
                        {
                            Properties.Settings.Default.item_Discount = Convert.ToDecimal(txtDiscount.Text);
                            Properties.Settings.Default.Save();
                        }
                        else if (Properties.Settings.Default.ItemDiscount == "Present")
                        {
                            decimal PresentValue = 0;
                            PresentValue = (Convert.ToDecimal(txtSalePrice.Text) / 100) * Convert.ToDecimal(txtDiscount.Text);
                            Properties.Settings.Default.item_Discount = PresentValue;
                            Properties.Settings.Default.Save();
                        }
                    }
                    catch (Exception) { }
                }

                else
                {
                    if (Convert.ToDecimal(txtDiscount.Text) >= 1)
                    {
                        MessageBox.Show("غير مسموح لك بعمل خصم على الفواتير");
                        txtDiscount.Text = "0";
                        return;
                    }
                }

                Properties.Settings.Default.Save();

                this.Close();
            }
            catch (Exception) { }
            }
        private void frm_SaleQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtQty.Text == "") { MessageBox.Show("رجاءا قم بإدخال الكمية"); return; }
                    if (txtSalePrice.Text == "") { MessageBox.Show("رجاءا قم بإدخال سعر البيع"); return; }
                    if (txtDiscount.Text == "") { MessageBox.Show("رجاءا قم بإدخال الخصم"); return; }

                    // to check the qty ! 
                    DataTable check = new DataTable();
                    DataTable unit = new DataTable();
                    unit.Clear();
                    check.Clear();

                    check = db.readData("select Qty from Products where Pro_ID=" + Properties.Settings.Default.Pro_ID + " ", "");
                    unit = db.readData("select * from Products_Unit where Pro_ID=" + Properties.Settings.Default.Pro_ID + " and Unit_ID=N'" + cbxUnit.SelectedValue + "' ", "");

                    decimal checkQty = 0;
                    decimal realqty = 0;
                    decimal QtyInMain = 0;

                    QtyInMain = Convert.ToDecimal(unit.Rows[0][3]);
                    realqty = Convert.ToDecimal(txtQty.Text) / QtyInMain;
                    checkQty = Convert.ToDecimal(check.Rows[0][0]);

                    if (checkQty < Convert.ToDecimal(realqty))
                    {
                        MessageBox.Show("الكمية غير متوفرة في المخزن", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    // to edit the variables

                    Properties.Settings.Default.item_Qty = Convert.ToDecimal(txtQty.Text);
                    Properties.Settings.Default.item_SalePrice = Convert.ToDecimal(txtSalePrice.Text);

                    Properties.Settings.Default.Pro_Unit = cbxUnit.Text;

                    if (Properties.Settings.Default.SaleDiscountForCasher == true)
                    {
                        try
                        {
                            if (Properties.Settings.Default.ItemDiscount == "Value")
                            {
                                Properties.Settings.Default.item_Discount = Convert.ToDecimal(txtDiscount.Text);
                                Properties.Settings.Default.Save();
                            }
                            else if (Properties.Settings.Default.ItemDiscount == "Present")
                            {
                                decimal PresentValue = 0;
                                PresentValue = (Convert.ToDecimal(txtSalePrice.Text) / 100) * Convert.ToDecimal(txtDiscount.Text);
                                Properties.Settings.Default.item_Discount = PresentValue;
                                Properties.Settings.Default.Save();
                            }
                        }
                        catch (Exception) { }
                    }

                    else
                    {
                        if (Convert.ToDecimal(txtDiscount.Text) >= 1)
                        {
                            MessageBox.Show("غير مسموح لك بعمل خصم على الفواتير");
                            txtDiscount.Text = "0";
                            return;
                        }
                    }

                    Properties.Settings.Default.Save();

                    this.Close();
                }
                catch (Exception) { }
            }
        }

        private void frm_SaleQty_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // select the current row that selected in datagridview
                int index = frm_Sales.GetForm.DgvSale.SelectedRows[0].Index;
                frm_Sales.GetForm.DgvSale.Rows[index].Cells[2].Value = Properties.Settings.Default.Pro_Unit;
                frm_Sales.GetForm.DgvSale.Rows[index].Cells[3].Value = Properties.Settings.Default.item_Qty;
                frm_Sales.GetForm.DgvSale.Rows[index].Cells[4].Value = Properties.Settings.Default.item_SalePrice;
                frm_Sales.GetForm.DgvSale.Rows[index].Cells[5].Value = Properties.Settings.Default.item_Discount;
            }
            catch (Exception) { }
        }

        private void cbxUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {

            // to cheack the qty of the selected product ! 
            try
            {
                DataTable tblUnit = new DataTable();
                tblUnit.Clear();

                // give me the the qty of the unit to cheack if it is small or lagre to check the price of the unit !
                tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + Properties.Settings.Default.Pro_ID + " and Unit_ID=N'" + cbxUnit.SelectedValue + "' ", "");

                decimal realPrice = 0;
                try
                {
                     realPrice = Convert.ToDecimal(tblUnit.Rows[0][4]);
                }
                catch (Exception) { }

                txtSalePrice.Text = Math.Round(realPrice, 2) + "";
            }
            catch (Exception) { }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
           
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