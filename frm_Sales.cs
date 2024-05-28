using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
namespace Sales_Management
{
    public partial class frm_Sales : DevExpress.XtraEditors.XtraForm
    {


        //for supplier adding button 
        private static frm_Sales frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static frm_Sales GetForm
        {

            get
            {
                if (frm == null)
                {
                    frm = new frm_Sales();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        Database db = new Database();
        DataTable tbl = new DataTable();

        public void FillItems()
        {
            cbxItems.DataSource = db.readData("select * from Products ", "");
            cbxItems.DisplayMember = "Pro_Name";
            cbxItems.ValueMember = "Pro_ID";
        }

        public void FillCustomers()
        {
            CpxCustomers.DataSource = db.readData("select * from Customers ", "");
            CpxCustomers.DisplayMember = "Cust_Name";
            CpxCustomers.ValueMember = "Cust_ID";

            CpxCustomers2.DataSource = db.readData("select * from Customers ", "");
            CpxCustomers2.DisplayMember = "Cust_Name";
            CpxCustomers2.ValueMember = "Cust_ID";
        }

        public frm_Sales()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        int USER_ID = 0;
        private void frm_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                USER_ID = Convert.ToInt32(db.readData("select * from Users where User_Name=N'" + Properties.Settings.Default.Defualt_USERNAME + "'", "").Rows[0][0]);
                Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
                DtpDateReminder.Text = DateTime.Now.ToShortDateString();
                DtpDate.Text = DateTime.Now.ToShortDateString();
                FillItems();
                FillCustomers();
                rbtnCustNakdy_CheckedChanged(null, null);
            }
            catch (Exception) { }

            try
            {
                AutoNumber();
            }
            catch (Exception) { }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void rbtnCustNakdy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CpxCustomers.Enabled = false;
                CpxCustomers2.Enabled = false;
                btnCustomersBrowse.Enabled = false;
                DtpDateReminder.Enabled = false;
                btn2.Enabled = false;

            }
            catch (Exception) { }
        }

        private void rbtnCustAagel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CpxCustomers.Enabled = true;
                CpxCustomers2.Enabled = false;
                btnCustomersBrowse.Enabled = true;
                DtpDateReminder.Enabled = true;
                btn2.Enabled = false;
            }
            catch (Exception) { }
        }

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select MAX(Order_ID) from Sales", "");

                //if customers table are null
                if ((tbl.Rows[0][0].ToString() == DBNull.Value.ToString()))
                {
                    txtID.Text = "1";
                }

                //if data available in the table bring them and add 1 to adding information
                else
                {
                    txtID.Text = (Convert.ToInt32(tbl.Rows[0][0]) + 1).ToString();
                }

                DtpDate.Text = DateTime.Now.ToShortDateString();
                DtpDateReminder.Text = DateTime.Now.ToShortDateString();

                try
                {
                    cbxItems.SelectedIndex = 0;
                    CpxCustomers.SelectedIndex = 0;
                }
                catch (Exception) { }
                cbxItems.Text = "اختر منتج";
                CpxCustomers.Text = "اختر عميل";
                DgvSale.Rows.Clear();
                rbtnCustNakdy.Checked = true;
                rbtnnakdyname.Checked = false;
                rbtnCustAagel.Checked = false;
                txtBarcode.Clear();
                txtBarcode.Focus();
                txtTotal.Clear();
            }
            catch (Exception) { }
        }

        private bool checkuser(string filed, string table)
        {
            DataTable tblsearch = new DataTable();
            tblsearch = db.readData("select " + filed + " from " + table + " where User_ID=" + USER_ID + "", "");
            if (Convert.ToDecimal(tblsearch.Rows[0][0]) == 0)
            {
                MessageBox.Show("انت لا تملك صلاحية الدخول لهذه الشاشة", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void btnCustomersBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = checkuser("Customer", "User_Customer");
                if (check == true)
                {
                    frm_Customer frm = new frm_Customer();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            FillCustomers();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
            {
                if (cbxItems.Text == (DgvSale.Rows[i].Cells[1].Value.ToString)())
                {
                    MessageBox.Show("المنتج موجود مسبقاً في الفاتورة !");
                    return;
                }
            }

            if (cbxItems.Text == "اختر منتج")
            {

                MessageBox.Show("الرجاء اختيار المنتج");
                return;
            }

            if (cbxItems.Items.Count <= 0)
            {
                MessageBox.Show("من فضلك قم بإضافة منتجات");
                return;
            }
            DataTable tblItems = new DataTable();
            DataTable tblUnit = new DataTable();
            DataTable tblunitcheck = new DataTable();
            DataTable qtycheck = new DataTable();
            tblItems.Clear();
            tblUnit.Clear();
            tblunitcheck.Clear();
            qtycheck.Clear();

            tblItems = db.readData("select * from Products where Pro_ID=" + cbxItems.SelectedValue + "  ", "");

            //to add the product information then add them in datagridview
            if (tblItems.Rows.Count >= 1)
            {
                try
                {

                    string Product_ID = tblItems.Rows[0][0].ToString();
                    string Product_Name = tblItems.Rows[0][1].ToString();
                    string Product_Qty = "1";
                    string Product_Price = "0";
                    decimal Discount = 0;
                    string Product_Unit = tblItems.Rows[0][14].ToString();

                    qtycheck = db.readData("select Qty From Products Where Pro_ID=" + Product_ID + " ", "");

                    tblunitcheck = db.readData("select * from Products_Unit where Pro_ID=" + Product_ID + " and Unit_Name=N'" + Product_Unit + "'", "");

                    decimal realqty = Convert.ToDecimal(Product_Qty) / Convert.ToDecimal(tblunitcheck.Rows[0][3]);
                    if (realqty > Convert.ToDecimal(qtycheck.Rows[0][0]))
                    {
                        MessageBox.Show("قم بأضافة كمية لهذا المنتج لكي تتم عملية البيع", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //add row to datagridview
                    DgvSale.Rows.Add(1);

                    // number of the rows in the datagridview to show me where am i in any row of the rows
                    int rowindex = DgvSale.Rows.Count - 1;

                    //bring me the last row to add information to this row

                    DgvSale.Rows[rowindex].Cells[0].Value = Product_ID;
                    DgvSale.Rows[rowindex].Cells[1].Value = Product_Name;
                    DgvSale.Rows[rowindex].Cells[3].Value = Product_Qty;
                    DgvSale.Rows[rowindex].Cells[2].Value = Product_Unit;



                    tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + Product_ID + " and Unit_Name=N'" + Product_Unit + "' ", "");
                    decimal realPrice = 0;

                    try
                    {
                        realPrice = Convert.ToDecimal(tblUnit.Rows[0][4]);
                    }
                    catch (Exception) { }


                    DgvSale.Rows[rowindex].Cells[4].Value = realPrice;
                    decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(realPrice);
                    DgvSale.Rows[rowindex].Cells[5].Value = Discount;

                    DgvSale.Rows[rowindex].Cells[6].Value = total;
                }
                catch (Exception) { }

                //for the total textbox sum addtion 
                try
                {
                    decimal TotalOrder = 0;

                    for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                    {
                        TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[6].Value);

                        //to select the row after add it in the grid to edit the qty of the product
                        //DgvBuy.ClearSelection();
                        //DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                        //DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;
                    }

                    txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

                    //to evalute the number of products in the datagridview
                    lblItemsCount.Text = (DgvSale.Rows.Count).ToString();
                }
                catch (Exception) { }

            }
        }

        private void frm_Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnItems_Click(null, null);
            }

            else if (e.KeyCode == Keys.F1)
            {
                txtBarcode.Clear();
                txtBarcode.Focus();
            }

            else if (e.KeyCode == Keys.F11)
            {
                UpdateQty();

                try
                {
                    // select the current row that selected in datagridview
                    int index = DgvSale.SelectedRows[0].Index;
                    DgvSale.Rows[index].Cells[2].Value = Properties.Settings.Default.Pro_Unit;
                    DgvSale.Rows[index].Cells[3].Value = Properties.Settings.Default.item_Qty;
                    DgvSale.Rows[index].Cells[4].Value = Properties.Settings.Default.item_SalePrice;
                    DgvSale.Rows[index].Cells[5].Value = Properties.Settings.Default.item_Discount;
                }
                catch (Exception) { }
            }

            else if (e.KeyCode == Keys.F12 || e.KeyCode == Keys.F)
            {
                if (DgvSale.Rows.Count >= 1)
                {

                    if (rbtnCustNakdy.Checked == true || rbtnnakdyname.Checked == true)
                    {
                        PayOrderNakdy();
                    }

                    if (rbtnCustAagel.Checked == true)
                    {
                        PayOrder();
                    }
                }
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                DataTable tblitem = new DataTable();
                tblitem.Clear();

                tblitem = db.readData("select * from Products where Barcode=N'" + txtBarcode.Text + "' ", "");

                if (tblitem.Rows.Count >= 1)
                {
                    for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                    {
                        if ((tblitem.Rows[0][1]).ToString() == (DgvSale.Rows[i].Cells[1].Value.ToString)())
                        {
                            MessageBox.Show("المنتج موجود مسبقاً في الفاتورة !");
                            return;
                        }
                    }
                }

                DataTable tblItems = new DataTable();
                tblItems.Clear();

                DataTable tblUnit = new DataTable();
                tblUnit.Clear();

                DataTable tblunitcheck = new DataTable();
                DataTable qtycheck = new DataTable();
                tblunitcheck.Clear();
                qtycheck.Clear();


                tblItems = db.readData("select * from Products where Barcode=N'" + txtBarcode.Text + "'  ", "");

                //to add the product information then add them in datagridview
                if (tblItems.Rows.Count >= 1)
                {
                    try
                    {
                        cbxItems.SelectedValue = Convert.ToInt32(tblItems.Rows[0][0]);
                        string Product_ID = tblItems.Rows[0][0].ToString();
                        string Product_Name = tblItems.Rows[0][1].ToString();
                        string Product_Qty = "1";
                        string Product_Price = "0";
                        decimal Discount = 0;
                        string Product_Unit = tblItems.Rows[0][14].ToString();

                        qtycheck = db.readData("select Qty From Products Where Pro_ID=" + Product_ID + " ", "");

                        tblunitcheck = db.readData("select * from Products_Unit where Pro_ID=" + Product_ID + " and Unit_Name=N'" + Product_Unit + "'", "");

                        decimal realqty = Convert.ToDecimal(Product_Qty) / Convert.ToDecimal(tblunitcheck.Rows[0][3]);
                        if (realqty > Convert.ToDecimal(qtycheck.Rows[0][0]))
                        {
                            MessageBox.Show("قم بأضافة كمية لهذا المنتج لكي تتم عملية البيع", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        //add row to datagridview
                        DgvSale.Rows.Add(1);

                        // number of the rows in the datagridview to show me where am i in any row of the rows
                        int rowindex = DgvSale.Rows.Count - 1;



                        //bring me the last row to add information to this row

                        DgvSale.Rows[rowindex].Cells[0].Value = Product_ID;
                        DgvSale.Rows[rowindex].Cells[1].Value = Product_Name;
                        DgvSale.Rows[rowindex].Cells[3].Value = Product_Qty;
                        DgvSale.Rows[rowindex].Cells[2].Value = Product_Unit;

                        tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + Product_ID + " and Unit_Name=N'" + Product_Unit + "' ", "");
                        decimal realPrice = 0;

                        try
                        {
                            realPrice = Convert.ToDecimal(tblUnit.Rows[0][4]);
                        }
                        catch (Exception) { }


                        DgvSale.Rows[rowindex].Cells[4].Value = realPrice;
                        decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(realPrice);
                        DgvSale.Rows[rowindex].Cells[5].Value = Discount;

                        DgvSale.Rows[rowindex].Cells[6].Value = total;
                    }
                    catch (Exception) { }

                    //for the total textbox sum addtion 
                    try
                    {
                        decimal TotalOrder = 0;

                        for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                        {
                            TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[6].Value);

                            //to select the row after add it in the grid to edit the qty of the product
                            //DgvBuy.ClearSelection();
                            //DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                            //DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;
                        }

                        txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

                        //to evalute the number of products in the datagridview
                        lblItemsCount.Text = (DgvSale.Rows.Count).ToString();

                    }
                    catch (Exception) { }
                }


                else if (tblitem.Rows.Count <= 0)
                {
                    MessageBox.Show("المنتج غير داخل في النظام", "تنبيه!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                    txtBarcode.Clear();
                    txtBarcode.Focus();
                }



            }
        }

        private void btnDeleteItems_Click(object sender, EventArgs e)
        {
            if (DgvSale.Rows.Count >= 1)
            {
                // bring me the value of the row iam selected 
                int index = DgvSale.SelectedRows[0].Index;
                DgvSale.Rows.RemoveAt(index);

                if (DgvSale.Rows.Count <= 0)
                {
                    txtTotal.Text = "0";
                }


                //to update the total box after the product is deleted
                try
                {

                    decimal TotalOrder = 0;

                    for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                    {
                        TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[6].Value);

                        // select the last row after the product is deleted from the datagridview to also delete it without touch the row
                        DgvSale.ClearSelection();
                        DgvSale.FirstDisplayedScrollingRowIndex = DgvSale.Rows.Count - 1;
                        DgvSale.Rows[DgvSale.Rows.Count - 1].Selected = true;

                    }
                    txtTotal.Text = Math.Round(TotalOrder, 3).ToString();

                    //to evalute the number of products in the datagridview
                    lblItemsCount.Text = (DgvSale.Rows.Count).ToString();
                }
                catch (Exception) { }

            }
        }

        public void UpdateQty()
        {

            if (DgvSale.Rows.Count >= 1)
            {
                // variables from system.properties 
                Properties.Settings.Default.Pro_Unit = Convert.ToString(DgvSale.CurrentRow.Cells[2].Value);
                Properties.Settings.Default.item_Qty = Convert.ToDecimal(DgvSale.CurrentRow.Cells[3].Value);
                Properties.Settings.Default.item_SalePrice = Convert.ToDecimal(DgvSale.CurrentRow.Cells[4].Value);
                Properties.Settings.Default.item_Discount = Convert.ToDecimal(DgvSale.CurrentRow.Cells[5].Value);
                Properties.Settings.Default.Pro_ID = Convert.ToInt32(DgvSale.CurrentRow.Cells[0].Value);

                // save this variables
                Properties.Settings.Default.Save();

                frm_SaleQty frm = new frm_SaleQty();
                frm.ShowDialog();

            }


        }

        private void DgvSale_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // to find the eqaution of the function sum after the qty of the product changed by user

            decimal Item_Qty = 0, Item_SalePrice = 0, Item_Discount = 0;

            try
            {
                // to bring us the row that we need to use the sum function on

                int index = DgvSale.SelectedRows[0].Index;

                Item_Qty = Convert.ToDecimal(DgvSale.Rows[index].Cells[3].Value);
                Item_SalePrice = Convert.ToDecimal(DgvSale.Rows[index].Cells[4].Value);
                Item_Discount = Convert.ToDecimal(DgvSale.Rows[index].Cells[5].Value);

                decimal Total = 0;
                Total = (Item_Qty * Item_SalePrice) - Item_Discount;

                //to display the total in the datagridview

                DgvSale.Rows[index].Cells[6].Value = Total;

                // for the total of the textbox

                decimal TotalOrder = 0;

                for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                {
                    TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[6].Value);
                }

                txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

                //to evalute the number of products in the datagridview
                lblItemsCount.Text = (DgvSale.Rows.Count).ToString();

            }
            catch (Exception) { }
        }

        // to insert data into sales table and update qty in store ! 
        private void updateQtyInStore(int Pro_ID, decimal realQty, int X, decimal PriceBeforeTax, decimal TaxValue, int unit_id)
        {
            DataTable tblqty = new DataTable();

            DataTable pr = new DataTable();

            decimal QtyInStoreFirstRow = 0;

            // delete any qty that = 0 ! 
            db.executedata("delete from Products_Qty where Qty <= 0", "");

            // give me the number of the rows of the products that i need to negative the qty from it to do the negative proccess by the number of the qty that i need to erase it ! 
            int countQty = 0;
            try
            {
                countQty = Convert.ToInt32(db.readData("select count(Pro_ID) from Products_Qty where Pro_ID=" + Pro_ID + "", "").Rows[0][0]);
            }
            catch (Exception) { }

            // for stop the loop and fix error there is no row at position 0 ! 
            // currentqty to know the number of the qty after delete from it !
            decimal CurrentQty = realQty;

            decimal unit_Qty = 0;

            for (int i = 0; i <= countQty - 1; i++)
            {
                // if there are more than 2 qty in alot of store to the same product , if the nudqty is more than each store_qty then do the operation by delete the other qty from other stores !

                // top 1 * , its to check the first row if the nudqty is less than qty in store do the delete from the first row , if its not do the delete of the rest qty from the other qty in the same store ! 
                try
                {
                    tblqty.Clear(); pr.Clear();
                    tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + "", "");
                    pr = db.readData("select * from Products_Unit where Pro_ID= " + Pro_ID + " and Unit_ID=" + unit_id + " ", "");

                    QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                    if (QtyInStoreFirstRow - realQty >= 1)
                    {
                        db.executedata("update Products_Qty set Qty= Qty - " + realQty + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");

                        unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                        InsertSalesRb7h(X, PriceBeforeTax, TaxValue, realQty, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);

                        // if currentrow = 0 (below that) stop the program (return) ! 
                        CurrentQty -= realQty;

                        return;
                    }

                    else if (QtyInStoreFirstRow - realQty == 0)
                    {
                        db.executedata("update Products_Qty set Qty= Qty - " + realQty + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                        db.executedata("delete Products_Qty where Qty <= 0 ", "");
                        unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                        InsertSalesRb7h(X, PriceBeforeTax, TaxValue, realQty, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);


                        // if currentrow = 0 (below that) stop the program (return) ! 
                        CurrentQty -= realQty;

                        return;
                    }

                    //-----------------------------------------------------------------------------------

                    else if (QtyInStoreFirstRow - realQty < 0)
                    {
                        // in the qty in the table we cannor set it to negative value 100-101=-1 so we do the operation by delete the same qty in table to do it 0 and delete it and the rest will delete by the another qty of the same store_id !

                        db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + "", "");
                        db.executedata("delete Products_Qty where Qty <= 0 ", "");
                        unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                        InsertSalesRb7h(X, PriceBeforeTax, TaxValue, QtyInStoreFirstRow, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);


                        // if currentrow = 0 (below that) 
                        CurrentQty -= QtyInStoreFirstRow;

                        decimal baky = Math.Abs(QtyInStoreFirstRow - realQty);

                        tblqty.Clear();
                        tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + "  ", "");
                        pr.Clear();
                        pr = db.readData("select * from Products_Unit where Pro_ID= " + Pro_ID + " and Unit_ID=" + unit_id + " ", "");


                        QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                        if (QtyInStoreFirstRow - baky >= 0)
                        {
                            db.executedata("update Products_Qty set Qty= Qty - " + baky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                            db.executedata("delete Products_Qty where Qty <= 0 ", "");
                            unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                            InsertSalesRb7h(X, PriceBeforeTax, TaxValue, baky, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);


                            return;
                        }


                        else if (QtyInStoreFirstRow - baky < 0)
                        {
                            decimal secondbaky = Math.Abs(QtyInStoreFirstRow - baky);

                            db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + "", "");
                            db.executedata("delete Products_Qty where Qty <= 0 ", "");
                            unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                            InsertSalesRb7h(X, PriceBeforeTax, TaxValue, QtyInStoreFirstRow, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);


                            CurrentQty -= QtyInStoreFirstRow;

                            tblqty.Clear();
                            tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " ", "");
                            pr.Clear();
                            pr = db.readData("select * from Products_Unit where Pro_ID= " + Pro_ID + " and Unit_ID=" + unit_id + " ", "");

                            QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                            if (QtyInStoreFirstRow - secondbaky >= 0)
                            {
                                db.executedata("update Products_Qty set Qty= Qty - " + secondbaky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + "", "");
                                db.executedata("delete Products_Qty where Qty <= 0 ", "");
                                unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                                InsertSalesRb7h(X, PriceBeforeTax, TaxValue, secondbaky, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);


                                return;
                            }

                            // -----------------------------------------------------------------------------------

                            else if (QtyInStoreFirstRow - secondbaky < 0)
                            {
                                decimal thirdbaky = Math.Abs(QtyInStoreFirstRow - secondbaky);

                                db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + "", "");
                                db.executedata("delete Products_Qty where Qty <= 0 ", "");
                                unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                                InsertSalesRb7h(X, PriceBeforeTax, TaxValue, QtyInStoreFirstRow, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);


                                CurrentQty -= QtyInStoreFirstRow;

                                tblqty.Clear();
                                tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + " ", "");
                                pr.Clear();
                                pr = db.readData("select * from Products_Unit where Pro_ID= " + Pro_ID + " and Unit_ID=" + unit_id + " ", "");

                                QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                                if (QtyInStoreFirstRow - thirdbaky >= 0)
                                {
                                    db.executedata("update Products_Qty set Qty= Qty - " + thirdbaky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + "and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                                    db.executedata("delete Products_Qty where Qty <= 0 ", "");
                                    unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                                    InsertSalesRb7h(X, PriceBeforeTax, TaxValue, thirdbaky, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);

                                    return;
                                }
                                // -----------------------------------------------------------------------------------
                                else if (QtyInStoreFirstRow - thirdbaky < 0)
                                {
                                    decimal fourbaky = Math.Abs(QtyInStoreFirstRow - thirdbaky);
                                    db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + " ", "");
                                    db.executedata("delete Products_Qty where Qty <= 0 ", "");
                                    unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                                    InsertSalesRb7h(X, PriceBeforeTax, TaxValue, QtyInStoreFirstRow, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);

                                    CurrentQty -= QtyInStoreFirstRow;

                                    tblqty.Clear();
                                    tblqty = db.readData("select Top 1 * from Products_Qty where Pro_ID=" + Pro_ID + "", "");
                                    pr.Clear();
                                    pr = db.readData("select * from Products_Unit where Pro_ID= " + Pro_ID + " and Unit_ID=" + unit_id + " ", "");


                                    QtyInStoreFirstRow = Convert.ToDecimal(tblqty.Rows[0][3]);

                                    if (QtyInStoreFirstRow - fourbaky >= 0)
                                    {
                                        db.executedata("update Products_Qty set Qty= Qty - " + fourbaky + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + "", "");
                                        db.executedata("delete Products_Qty where Qty <= 0 ", "");
                                        unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                                        InsertSalesRb7h(X, PriceBeforeTax, TaxValue, fourbaky, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);

                                        return;
                                    }

                                    else if (QtyInStoreFirstRow - fourbaky < 0)
                                    {
                                        db.executedata("update Products_Qty set Qty= Qty - " + QtyInStoreFirstRow + " where Pro_ID=" + Pro_ID + " and Store_ID= " + Convert.ToDecimal(tblqty.Rows[0][1]) + " and Qty=" + QtyInStoreFirstRow + " and Buy_Price=" + Convert.ToDecimal(tblqty.Rows[0][4]) + "", "");
                                        db.executedata("delete Products_Qty where Qty <= 0 ", "");
                                        unit_Qty = Convert.ToDecimal(pr.Rows[0][3]);
                                        InsertSalesRb7h(X, PriceBeforeTax, TaxValue, QtyInStoreFirstRow, Convert.ToDecimal(tblqty.Rows[0][4]) / unit_Qty);
                                        CurrentQty -= QtyInStoreFirstRow;
                                        realQty = CurrentQty;
                                    }

                                }


                            }
                        }


                    }

                    if (CurrentQty <= 0)
                    { return; }

                }
                catch (Exception) { }



            }
        }


        private void insertDataInSalesandUpdateStoreQty()
        {
            if (DgvSale.Rows.Count >= 1)
            {
                string d = DtpDate.Value.ToString("dd/MM/yyyy");
                string Cust_Name = "";

                // for Cust_Name
                if (rbtnCustNakdy.Checked == true)
                {
                    Cust_Name = "عميل نقدي";
                }
                if (rbtnnakdyname.Checked == true) { Cust_Name = CpxCustomers2.Text; }
                if (rbtnCustAagel.Checked == true) { Cust_Name = CpxCustomers.Text; }

                decimal PriceBeforeTax = 0, TaxValue = 0, QtyinMain = 0, realQty = 0, TotalTax = 0;
                DataTable tblPro = new DataTable();
                tblPro.Clear();

                DataTable tblQty = new DataTable();
                tblQty.Clear();

                for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                {

                    // to select all the info from products table !
                    tblPro = db.readData("select * from Products where Pro_ID=" + DgvSale.Rows[i].Cells[0].Value + " ", "");

                    // to select all the info from the products_unit table ! 
                    tblQty = db.readData("select * from Products_Unit where Pro_ID=" + DgvSale.Rows[i].Cells[0].Value + " and Unit_Name=N'" + DgvSale.Rows[i].Cells[2].Value + "'", "");

                    // to definate the qty in the proudcts_unit table ! 

                    QtyinMain = Convert.ToDecimal(tblQty.Rows[0][3]);

                    // tax_value = sale_price - buy_price divide by qty in the products_unit table ! 

                    TaxValue = (Convert.ToDecimal(tblPro.Rows[0][6]) - Convert.ToDecimal(tblPro.Rows[0][4])) / QtyinMain;

                    TotalTax += TaxValue * Convert.ToDecimal(DgvSale.Rows[i].Cells[3].Value);

                    PriceBeforeTax = Convert.ToDecimal(tblPro.Rows[0][4]);


                    // real qty to give me the number of small item and convert it to large item to do the process ! 
                    realQty = Convert.ToDecimal(DgvSale.Rows[i].Cells[3].Value) / QtyinMain;

                    // check the qty before do the process ! 
                    if (Convert.ToDecimal(tblPro.Rows[0][2]) - realQty < 0)
                    {
                        MessageBox.Show("الكمية الموجودة في المخزن غير كافية للبيع", "تنبيه !");
                        return;
                    }

                    db.executedata("insert into Sales values(" + txtID.Text + ",N'" + d + "',N'" + Cust_Name + "')", "");

                    db.executedata("insert into Sales_Details values (" + txtID.Text + ",N'" + Cust_Name + "'," + DgvSale.Rows[i].Cells[0].Value + ",N'" + d + "'," + DgvSale.Rows[i].Cells[3].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + PriceBeforeTax + "," + DgvSale.Rows[i].Cells[5].Value + "," + DgvSale.Rows[i].Cells[6].Value + "," + Properties.Settings.Default.TotalOrder + "," + Properties.Settings.Default.Madfou3 + "," + Properties.Settings.Default.Bakey + ",N'" + DgvSale.Rows[i].Cells[2].Value + "'," + TaxValue + "," + DgvSale.Rows[i].Cells[4].Value + ",N'" + dtp.Text + "') ", "");

                    // to add the qty to the qty of the product table
                    db.executedata("update Products set Qty=Qty - " + realQty + " where Pro_ID=" + DgvSale.Rows[i].Cells[0].Value + " ", "");

                    int unit_id = 0; unit_id = Convert.ToInt32(db.readData("select * from Products_Unit where Unit_Name=N'" + DgvSale.Rows[i].Cells[2].Value + "' ", "").Rows[0][1]);
                    int pro_id = 0; pro_id = Convert.ToInt32(db.readData("select * from Products where Pro_Name=N'" + DgvSale.Rows[i].Cells[1].Value + "' ", "").Rows[0][0]);

                    updateQtyInStore(pro_id, realQty, i, PriceBeforeTax, TaxValue, unit_id);
                }
                decimal totalBeforeTax = 0;
                totalBeforeTax = Convert.ToDecimal(txtTotal.Text) - TotalTax;
                db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + txtID.Text + ",N'فاتورة مبيعات',N'قيمة مضافة',N'لايوجد',N'" + Cust_Name + "'," + totalBeforeTax + "," + TotalTax + "," + txtTotal.Text + ",N'" + d + "') ", "");
            }
        }


        // to insert the the data in the sales_rb7h table in the database !

        private void InsertSalesRb7h(int i, decimal PriceBeforeTax, decimal TaxValue, decimal realQty, decimal BuyPrice)
        {
            string Cust_Name = "";

            // for Cust_Name
            if (rbtnCustNakdy.Checked == true)
            {
                Cust_Name = "عميل نقدي";
            }
            if (rbtnnakdyname.Checked == true) { Cust_Name = CpxCustomers2.Text; }
            if (rbtnCustAagel.Checked == true) { Cust_Name = CpxCustomers.Text; }

            string d = DtpDate.Value.ToString("dd/MM/yyyy");
            db.executedata("insert into Sales_Rb7h values (" + txtID.Text + ",N'" + Cust_Name + "'," + DgvSale.Rows[i].Cells[0].Value + ",N'" + d + "'," + realQty + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + PriceBeforeTax + "," + DgvSale.Rows[i].Cells[5].Value + "," + DgvSale.Rows[i].Cells[6].Value + "," + Properties.Settings.Default.TotalOrder + "," + Properties.Settings.Default.Madfou3 + "," + Properties.Settings.Default.Bakey + ",N'" + DgvSale.Rows[i].Cells[2].Value + "'," + TaxValue + "," + DgvSale.Rows[i].Cells[4].Value + ",N'" + dtp.Text + "'," + BuyPrice + ") ", "");

        }

        public void PayOrderNakdy()
        {
            string Cust_Name = "";
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            // for Cust_Name
            if (rbtnCustNakdy.Checked == true)
            {
                Cust_Name = "عميل نقدي";
            }
            if (rbtnnakdyname.Checked == true) { Cust_Name = CpxCustomers2.Text; }
            if (rbtnCustAagel.Checked == true) { Cust_Name = CpxCustomers.Text; }

            // to set send the  parameters to the system.propertirs 

            Properties.Settings.Default.TotalOrder = Convert.ToDecimal(txtTotal.Text);
            Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtTotal.Text);
            Properties.Settings.Default.Bakey = 0;
            Properties.Settings.Default.CheckButton = true;
            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.CheckButton == true)
            {

                try
                {

                    insertDataInSalesandUpdateStoreQty();

                    // for  nakdy and aagel

                    if (rbtnCustNakdy.Checked == true || rbtnnakdyname.Checked == true)
                    {

                        db.executedata("insert into Customer_Report values(" + txtID.Text + "," + Properties.Settings.Default.Madfou3 + ",N'" + d + "',N'" + Cust_Name + "') ", "");
                    }


                    // if the user active the print of buy form from setting form do the print !
                    if (Properties.Settings.Default.SalesPrint == true)
                    {
                        // data var its for checking if there are any info in the setting table !
                        int data = 0;

                        if (Properties.Settings.Default.PrinterName == "")
                        {
                            MessageBox.Show("من فضلك حدد اسم الطابعة من شاشة اعدادات البرنامج", "تنبيه !");

                        }

                        try
                        {
                            data = Convert.ToInt32(db.readData("select count(Name) from Order_PrintData", "").Rows[0][0]);
                        }
                        catch (Exception) { }

                        if (data >= 1)
                        {

                        }

                        else if (data <= 0)
                        {
                            MessageBox.Show("من فضلك قم بإدخال البيانات في شاشة اعدادات الفاتورة من شاشة اعدادات", "تنبيه !");

                        }

                        // if the number of the order in the setting more than 1 print !
                        for (int i = 0; i <= Properties.Settings.Default.SalesPrintNum - 1; i++)
                        {
                            Print();
                        }
                    }


                    InsertMoneyIntoStock();
                    AutoNumber();
                }
                catch (Exception) { }

            }
        }


        private void PayOrder()
        {

            string Cust_Name = "";
            string d = DtpDate.Value.ToString("dd/MM/yyyy");


            // for rbtnAagel
            if (rbtnCustAagel.Checked == true)
            {

                Cust_Name = CpxCustomers.Text;
            }


            // to set send the  parameters to the system.propertirs 

            Properties.Settings.Default.TotalOrder = Convert.ToDecimal(txtTotal.Text);
            Properties.Settings.Default.Madfou3 = 0;
            Properties.Settings.Default.Bakey = 0;
            Properties.Settings.Default.Save();


            frm_PaySale frm = new frm_PaySale();
            frm.ShowDialog();





            if (Properties.Settings.Default.CheckButton == true)
            {

                try
                {

                    insertDataInSalesandUpdateStoreQty();

                    // for  nakdy and aagel


                    if (rbtnCustAagel.Checked == true)
                    {
                        string dorder = DtpDate.Value.ToString("dd/MM/yyyy");
                        string dreminder = DtpDateReminder.Value.ToString("dd/MM/yyyy");

                        db.executedata("insert into Customer_Money values(" + txtID.Text + ",N'" + Cust_Name + "'," + Properties.Settings.Default.Bakey + ",N'" + dorder + "',N'" + dreminder + "') ", "");

                        if (Properties.Settings.Default.Madfou3 >= 1)
                        {
                            db.executedata("insert into Customer_Report values(" + txtID.Text + "," + Properties.Settings.Default.Madfou3 + ",N'" + d + "',N'" + Cust_Name + "') ", "");
                        }
                    }

                    // if the user active the print of buy form from setting form do the print !
                    if (Properties.Settings.Default.SalesPrint == true)
                    {
                        // data var its for checking if there are any info in the setting table !
                        int data = 0;

                        if (Properties.Settings.Default.PrinterName == "")
                        {
                            MessageBox.Show("من فضلك حدد اسم الطابعة من شاشة اعدادات البرنامج", "تنبيه !");

                        }

                        try
                        {
                            data = Convert.ToInt32(db.readData("select count(Name) from Order_PrintData", "").Rows[0][0]);
                        }
                        catch (Exception) { }

                        if (data >= 1)
                        {

                        }

                        else if (data <= 0)
                        {
                            MessageBox.Show("من فضلك قم بإدخال البيانات في شاشة اعدادات الفاتورة من شاشة اعدادات", "تنبيه !");
                        }

                        // if the number of the order in the setting more than 1 print !
                        for (int i = 0; i <= Properties.Settings.Default.SalesPrintNum - 1; i++)
                        {
                            Print();
                        }
                    }


                    InsertMoneyIntoStock();
                    AutoNumber();
                }
                catch (Exception) { }

            }

        }

        // methode to print 8 cm order
        private void Print()
        {
            // the same order id of the order 

            int id = Convert.ToInt32(txtID.Text);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير' ,[Price] as 'سعر المنتج',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID   and Order_ID=" + id + "", "");

            frm_Printing frm = new frm_Printing();


            frm.crystalReportViewer1.RefreshReport();

            if (Properties.Settings.Default.SalePrintKind == "8CM")
            {
                rpt_OrderSales rpt = new rpt_OrderSales();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                rpt.PrintToPrinter(1, true, 0, 0);

                //frm.ShowDialog();
            }

            else if (Properties.Settings.Default.SalePrintKind == "A4")
            {
                RptOrderSaleA4 rpt = new RptOrderSaleA4();

                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                rpt.PrintToPrinter(1, true, 0, 0);

                //frm.ShowDialog();
            }


        }


        // to Insert the money in the stock ! 
        string Stock_ID = "";
        private void InsertMoneyIntoStock()
        {
            DataTable tblstock = new DataTable();
            tblstock.Clear();

            if (Properties.Settings.Default.Pay_Visa == false)
            {

                string date1 = DtpDate.Value.ToString("dd/MM/yyyy");

                db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + Properties.Settings.Default.Madfou3 + ",N'" + date1 + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'عملية بيع',N'.') ", "");

                db.executedata("update Stock set Money=Money + " + Properties.Settings.Default.Madfou3 + " where Stock_ID=" + Stock_ID + "  ", "");
            }
            else
            {
                string date1 = DtpDate.Value.ToString("dd/MM/yyyy");

                db.executedata("insert into Bank_Insert (Money,Date,Name,Type,Reason) values (" + Properties.Settings.Default.Madfou3 + ",N'" + date1 + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'عملية بيع',N'.') ", "");

                db.executedata("update Bank set Money=Money + " + Properties.Settings.Default.Madfou3 + " ", "");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=s7hryp5JROI&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=6");
        }

        private void DgvSale_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (DgvSale.Rows.Count >= 1)
                {
                    // variables from system.properties 
                    Properties.Settings.Default.Pro_Unit = Convert.ToString(DgvSale.CurrentRow.Cells[2].Value);
                    Properties.Settings.Default.item_Qty = Convert.ToDecimal(DgvSale.CurrentRow.Cells[3].Value);
                    Properties.Settings.Default.item_SalePrice = Convert.ToDecimal(DgvSale.CurrentRow.Cells[4].Value);
                    Properties.Settings.Default.item_Discount = Convert.ToDecimal(DgvSale.CurrentRow.Cells[5].Value);
                    Properties.Settings.Default.Pro_ID = Convert.ToInt32(DgvSale.CurrentRow.Cells[0].Value);

                    // save this variables
                    Properties.Settings.Default.Save();

                    frm_SaleQty frm = new frm_SaleQty();
                    frm.ShowDialog();

                    // select the current row that selected in datagridview
                    int index = DgvSale.SelectedRows[0].Index;
                    DgvSale.Rows[index].Cells[2].Value = Properties.Settings.Default.Pro_Unit;
                    DgvSale.Rows[index].Cells[3].Value = Properties.Settings.Default.item_Qty;
                    DgvSale.Rows[index].Cells[4].Value = Properties.Settings.Default.item_SalePrice;
                    DgvSale.Rows[index].Cells[5].Value = Properties.Settings.Default.item_Discount;
                }
            }
            catch (Exception) { }
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool check = checkuser("Customer", "User_Customer");
                if (check == true)
                {
                    frm_Customer frm = new frm_Customer();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            FillCustomers();
        }

        private void rbtnnakdyname_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CpxCustomers.Enabled = false;
                CpxCustomers2.Enabled = true;
                btnCustomersBrowse.Enabled = false;
                DtpDateReminder.Enabled = false;
                btn2.Enabled = true;
            }
            catch (Exception) { }
        }
    }


}