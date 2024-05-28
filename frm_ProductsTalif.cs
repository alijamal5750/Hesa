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
    public partial class frm_ProductsTalif : DevExpress.XtraEditors.XtraForm
    {
        tracker tr = new tracker();
        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillStore()
        {
            cpxStore.DataSource = db.readData("select * from Store", "");
            cpxStore.DisplayMember = "Store_Name";
            cpxStore.ValueMember = "Store_ID";
        }

        private void FillProducts()
        {
            cpxProducts.DataSource = db.readData("select * from products", "");
            cpxProducts.DisplayMember = "Pro_Name";
            cpxProducts.ValueMember = "Pro_ID";
        }

        private void FillUnits()
        {
            cpxUnit.DataSource = db.readData("select * from Units", "");
            cpxUnit.DisplayMember = "Unit_Name";
            cpxUnit.ValueMember = "Unit_ID";
        }


        public frm_ProductsTalif()
        {
            InitializeComponent();
        }

        private void frm_ProductsTalif_Load(object sender, EventArgs e)
        {
            try
            {
                FillStore();
                FillProducts();
                DtpDate.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception) { }
        }

        private void cpxProducts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // bring me the units of the selected_product !
                cpxUnit.DataSource = db.readData("select * from Products_Unit where Pro_ID=" + cpxProducts.SelectedValue + "", "");
                cpxUnit.DisplayMember = "Unit_Name";
                cpxUnit.ValueMember = "Unit_ID";
            }
            catch (Exception) { }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtBarcode.Text != "")
                {
                    tbl.Clear();
                    tbl = db.readData("select * from Products where Barcode=N'" + txtBarcode.Text + "'", "");

                    if (tbl.Rows.Count >= 1)
                    {
                        cpxProducts.SelectedValue = Convert.ToInt32(tbl.Rows[0][0]);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cpxProducts.Items.Count >= 1)
            {
                if (cpxUnit.Items.Count >= 1)
                {
                    if (cpxStore.Items.Count >= 1)
                    {

                        DataTable tblunit = new DataTable();
                        tblunit.Clear();
                        decimal QtyInMain = 0, realQty = 0, TotalQtyInStore = 0;
                        try
                        {

                            int Pro_Id = Convert.ToInt32(cpxProducts.SelectedValue);

                            // bring me the mini qty in large qty , (single item) under (box) !

                            tblunit = db.readData("select * from Products_Unit where Pro_ID=" + Pro_Id + " and Unit_Name=N'" + cpxUnit.Text + "'  ", "");

                            try
                            {

                                QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
                            }
                            catch (Exception) { }

                            // for single item (small_item)
                            if (QtyInMain > 1)
                            {
                                realQty = NudQty.Value / QtyInMain;
                            }

                            else
                            {
                                realQty = NudQty.Value;
                            }

                            // add validation if the qty in nudqty is bigger that the actual qty in the table of each store that saved into ! 

                            try
                            {
                                TotalQtyInStore = Convert.ToDecimal(db.readData("select sum(Qty) from Products_Qty where Pro_ID= " + Pro_Id + " and Store_ID=" + cpxStore.SelectedValue + " ", "").Rows[0][0]);
                            }
                            catch (Exception) { }

                            if (TotalQtyInStore - realQty < 0)
                            {
                                MessageBox.Show("الكمية المراد اخراجها غير موجودة في المخزن حالياً", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            updateQtyInStore(Pro_Id, realQty);

                            InsertIntoProductOutStore();
                            MessageBox.Show("تم الاخراج بنجاح ", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tr.TrackerInsert("شاشة المنتجات التالفة", "اسم المنتج التالف",cpxProducts.Text);
                            AutoNumber();
                        }
                        catch (Exception) { }

                    }
                }
            }
        }

        private void AutoNumber()
        {
            try
            {
                cpxProducts.SelectedIndex = 0;
               
                cpxStore.SelectedIndex = 0;
                cpxUnit.SelectedIndex = 0;
               
                NudQty.Value = 1;
                txtName.Clear();
                txtReason.Clear();
                DtpDate.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception) { }
        }


        private void InsertIntoProductOutStore()
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            db.executedata("insert into Products_OutStore (Pro_ID,Pro_Name,Store_Name,Qty,Unit,Date,Name,Reason) values (" + cpxProducts.SelectedValue + ",N'" + cpxProducts.Text + "',N'" + cpxStore.Text + "'," + NudQty.Value + ",N'" + cpxUnit.Text + "',N'" + d + "',N'" + txtName.Text + "',N'" + txtReason.Text + "') ", "");
        }


        private void updateQtyInStore(int Pro_ID, decimal realQty)
        {
            DataTable tblqty = new DataTable();
            tblqty.Clear();
            decimal QtyInStoreFirstRow = 0;

            // delete any qty that = 0 ! 
            db.executedata("delete from Products_Qty where Qty <= 0", "");

            // if there are more than 2 qty in alot of store to the same product , if the nudqty is more than each store_qty then do the operation by delete the other qty from other stores !

            // top 1 * , its to check the first row if the nudqty is less than qty in store do the delete from the first row , if its not do the delete of the rest qty from the other qty in the same store ! 

            tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " and Store_ID=" + cpxStore.SelectedValue + " ", "");
            QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

            if (QtyInStoreFirstRow - realQty >= 1)
            {
                db.executedata("update Products_Qty set Qty= Qty - " + realQty + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");

            }

            else if (QtyInStoreFirstRow - realQty == 0)
            {
                db.executedata("update Products_Qty set Qty= Qty - " + realQty + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");

                db.executedata("delete Products_Qty where Qty <= 0 ", "");
            }

                //-----------------------------------------------------------------------------------

            else if (QtyInStoreFirstRow - realQty < 0)
            {
                // in the qty in the table we cannor set it to negative value 100-101=-1 so we do the operation by delete the same qty in table to do it 0 and delete it and the rest will delete by the another qty of the same store_id !

                db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                db.executedata("delete Products_Qty where Qty <= 0 ", "");

                decimal baky = Math.Abs(QtyInStoreFirstRow - realQty);

                tblqty.Clear();
                tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " and Store_ID=" + cpxStore.SelectedValue + " ", "");

                QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                if (QtyInStoreFirstRow - baky >= 0)
                {
                    db.executedata("update Products_Qty set Qty= Qty - " + baky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                    db.executedata("delete Products_Qty where Qty <= 0 ", "");
                }


                else if (QtyInStoreFirstRow - baky < 0)
                {
                    decimal secondbaky = Math.Abs(QtyInStoreFirstRow - baky);

                    db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                    db.executedata("delete Products_Qty where Qty <= 0 ", "");

                    tblqty.Clear();
                    tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " and Store_ID=" + cpxStore.SelectedValue + " ", "");

                    QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                    if (QtyInStoreFirstRow - secondbaky >= 0)
                    {
                        db.executedata("update Products_Qty set Qty= Qty - " + secondbaky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                        db.executedata("delete Products_Qty where Qty <= 0 ", "");
                    }

                    // -----------------------------------------------------------------------------------

                    else if (QtyInStoreFirstRow - secondbaky < 0)
                    {
                        decimal thirdbaky = Math.Abs(QtyInStoreFirstRow - secondbaky);

                        db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                        db.executedata("delete Products_Qty where Qty <= 0 ", "");

                        tblqty.Clear();
                        tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " and Store_ID=" + cpxStore.SelectedValue + " ", "");

                        QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                        if (QtyInStoreFirstRow - thirdbaky >= 0)
                        {
                            db.executedata("update Products_Qty set Qty= Qty - " + thirdbaky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                            db.executedata("delete Products_Qty where Qty <= 0 ", "");
                        }
                        // -----------------------------------------------------------------------------------
                        else if (QtyInStoreFirstRow - thirdbaky < 0)
                        {
                            decimal fourbaky = Math.Abs(QtyInStoreFirstRow - thirdbaky);
                            db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                            db.executedata("delete Products_Qty where Qty <= 0 ", "");

                            tblqty.Clear();
                            tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " and Store_ID=" + cpxStore.SelectedValue + " ", "");

                            QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                            if (QtyInStoreFirstRow - fourbaky >= 0)
                            {
                                db.executedata("update Products_Qty set Qty= Qty - " + fourbaky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                                db.executedata("delete Products_Qty where Qty <= 0 ", "");
                            }

                            else if (QtyInStoreFirstRow - fourbaky < 0)
                            {
                                db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + cpxStore.SelectedValue + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                                db.executedata("delete Products_Qty where Qty <= 0 ", "");
                            }

                        }


                    }
                }


            }
        }

    }
}