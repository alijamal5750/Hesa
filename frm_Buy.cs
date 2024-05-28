using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System.Diagnostics;
namespace Sales_Management
{

    public partial class frm_Buy : DevExpress.XtraEditors.XtraForm
    {

        //for supplier adding button 
        private static frm_Buy frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static frm_Buy GetForm
        {

            get
            {
                if (frm == null)
                {
                    frm = new frm_Buy();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }

        }

        public frm_Buy()
        {
            InitializeComponent();
            if (frm == null)
            {
                frm = this;
            }
        }

        tracker tr = new tracker();
        Database db = new Database();
        DataTable tbl = new DataTable();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select MAX(Order_ID) from Buy", "");

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
                DtpAagel.Text = DateTime.Now.ToShortDateString();

                try
                {
                    cbxItems.SelectedIndex = 0;
                    cpxSupplier.SelectedIndex = 0;
                    cpxStore.SelectedIndex = 0;
                }
                catch (Exception) { }
                cbxItems.Text = "اختر منتج";
                cpxSupplier.Text = "اختر مورد";
                DgvBuy.Rows.Clear();
                rbtnCash.Checked = true;
                rbtnAagel.Checked = false;
                txtBarcode.Clear();
                txtBarcode.Focus();
                txtTotal.Clear();
            }
            catch (Exception) { }
        }

        int USER_ID = 0;
        private void frm_Buy_Load(object sender, EventArgs e)
        {
            try
            {
                USER_ID = Convert.ToInt32(db.readData("select * from Users where User_Name=N'" + Properties.Settings.Default.Defualt_USERNAME + "'", "").Rows[0][0]);
                Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
                FillItems();
                FillSupplier();
                FillStore();
            }
            catch (Exception) { }
            try
            {
                AutoNumber();
            }
            catch (Exception) { }
        }


        private void FillStore()
        {
            cpxStore.DataSource = db.readData("select * from Store ", "");
            cpxStore.DisplayMember = "Store_Name";
            cpxStore.ValueMember = "Store_ID";
        }


        private void FillItems()
        {
            cbxItems.DataSource = db.readData("select * from Products ", "");
            cbxItems.DisplayMember = "Pro_Name";
            cbxItems.ValueMember = "Pro_ID";
        }

        public void FillSupplier()
        {
            cpxSupplier.DataSource = db.readData("select * from Suppliers ", "");
            cpxSupplier.DisplayMember = "Sup_Name";
            cpxSupplier.ValueMember = "Sup_ID";
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

        private void btnSupplierBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = checkuser("Supp_Data", "User_Supplier");
                if (check == true)
                {
                    frm_supplier frm = new frm_supplier();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }

            FillSupplier();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
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
            tblItems.Clear();

            DataTable tblPrice = new DataTable();
            tblPrice.Clear();

            DataTable tblUnit = new DataTable();
            tblUnit.Clear();

            DataTable tblcehck = new DataTable();
            tblcehck.Clear();

            tblcehck = db.readData("select * from Products_Qty where Pro_ID=" + cbxItems.SelectedValue + "", "");
            if (tblcehck.Rows.Count <= 0)
            {
                MessageBox.Show("يبدو ان المنتج المحدد ليس له كميات و لا سعر شراء خاص بالكميات ادخل سعر الشراء في الشاشة التالية");
                decimal qty = 0;
                string buyprice = Microsoft.VisualBasic.Interaction.InputBox("ادخل سعر للمنتج" + (cbxItems.Text), "سعر الشراء", "من فضلك ادخل السعر هنا", 1, 1);
                decimal sale_price = Convert.ToDecimal(db.readData("select * from Products where Pro_ID=" + cpxStore.SelectedValue + "", "").Rows[0][6]);
                db.executedata("insert into Products_Qty values (" + cbxItems.SelectedValue + "," + cpxStore.SelectedValue + ",N'" + cpxStore.Text + "'," + qty + "," + buyprice + "," + sale_price + ")", "");
                MessageBox.Show("تمت عملية الاضافة اللآن يمكنك اضافة المنتج الى الفاتورة");
            }

            tblItems = db.readData("select * from Products where Pro_ID=" + cbxItems.SelectedValue + "  ", "");

            //to add the product information then add them in datagridview
            if (tblItems.Rows.Count >= 1)
            {

                // to cheack the qty of the selected product ! 
                try
                {
                    int countQty = 0;
                    try
                    {
                        countQty = Convert.ToInt32(db.readData("select Count(Pro_ID) from Products_Qty where Pro_ID=" + cbxItems.SelectedValue + " ", "").Rows[0][0]);
                    } catch (Exception) { }

                    // to retrun the buy price of the qty
                    tblPrice = db.readData("select * from Products_Qty where Pro_ID=" + cbxItems.SelectedValue + " ", "");



                    string Product_ID = tblItems.Rows[0][0].ToString();
                    string Product_Name = tblItems.Rows[0][1].ToString();
                    string Product_Qty = "1";

                    // countQty its for the number of the rows (qty) of the same product and the -1 to give me the modern price of the qty of the same product ! cuz its diffrent from date to date!
                    string Product_Price = tblPrice.Rows[countQty - 1][4].ToString();
                    decimal Discount = 0;
                    string Product_Unit = tblItems.Rows[0][16].ToString();


                    //add row to datagridview
                    DgvBuy.Rows.Add(1);

                    // number of the rows in the datagridview to show me where am i in any row of the rows
                    int rowindex = DgvBuy.Rows.Count - 1;

                    //bring me the last row to add information to this row
                    DgvBuy.Rows[rowindex].Cells[0].Value = Product_ID;
                    DgvBuy.Rows[rowindex].Cells[1].Value = Product_Name;
                    DgvBuy.Rows[rowindex].Cells[2].Value = Product_Unit;
                    DgvBuy.Rows[rowindex].Cells[3].Value = Product_Qty;

                    // give me the the qty of the unit to cheack if it is small or lagre to check the price of the unit !
                    tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + DgvBuy.CurrentRow.Cells[0].Value + " and Unit_Name=N'" + DgvBuy.CurrentRow.Cells[2].Value + "' ", "");

                    decimal realPrice = 0;
                    try
                    {
                        realPrice = Convert.ToDecimal(Product_Price) / Convert.ToDecimal(tblUnit.Rows[0][3]);
                    }
                    catch (Exception) { }

                    decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(realPrice);

                    DgvBuy.Rows[rowindex].Cells[4].Value = Math.Round(realPrice, 2);
                    DgvBuy.Rows[rowindex].Cells[5].Value = Discount;
                    DgvBuy.Rows[rowindex].Cells[6].Value = Math.Round(total, 2);
                }
                catch (Exception) { }

                //for the total textbox sum addtion 
                try
                {
                    decimal TotalOrder = 0;

                    for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                    {
                        TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[6].Value);

                        //to select the row after add it in the grid to edit the qty of the product
                        //DgvBuy.ClearSelection();
                        //DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                        //DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;
                    }
                    txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

                    //to evalute the number of products in the datagridview
                    lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();
                }
                catch (Exception) { }

            }


        }

        private void btnDeleteItems_Click(object sender, EventArgs e)
        {
            if (DgvBuy.Rows.Count >= 1)
            {
                // bring me the value of the row iam selected 
                int index = DgvBuy.SelectedRows[0].Index;
                DgvBuy.Rows.RemoveAt(index);

                if (DgvBuy.Rows.Count <= 0)
                {
                    txtTotal.Text = "0";
                }


                //to update the total box after the product is deleted
                try
                {

                    decimal TotalOrder = 0;

                    for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                    {
                        TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);

                        //to select the row after add it in the grid to edit the qty of the product
                        DgvBuy.ClearSelection();
                        DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                        DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;

                    }
                    txtTotal.Text = Math.Round(TotalOrder, 3).ToString();

                    //to evalute the number of products in the datagridview
                    lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();
                }
                catch (Exception) { }

            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                DataTable tblItems = new DataTable();
                tblItems.Clear();

                DataTable tblPrice = new DataTable();
                tblPrice.Clear();

                DataTable tblUnit = new DataTable();
                tblUnit.Clear();

                tblItems = db.readData("select * from Products where Barcode=N'" + txtBarcode.Text + "'", "");

                if (tblItems.Rows.Count >= 1)
                {
                    DataTable tblcehck = new DataTable();
                    tblcehck.Clear();

                    tblcehck = db.readData("select * from Products_Qty where Pro_ID=" + tblItems.Rows[0][0] + "", "");
                    if (tblcehck.Rows.Count <= 0)
                    {
                        MessageBox.Show("يبدو ان المنتج المحدد ليس له كميات و لا سعر شراء خاص بالكميات ادخل سعر الشراء في الشاشة التالية");
                        decimal qty = 0;
                        string buyprice = Microsoft.VisualBasic.Interaction.InputBox("ادخل سعر للمنتج" + (cbxItems.Text), "سعر الشراء", "من فضلك ادخل السعر هنا", 1, 1);
                        decimal sale_price = Convert.ToDecimal(db.readData("select * from Products where Pro_ID=" + cpxStore.SelectedValue + "", "").Rows[0][6]);
                        db.executedata("insert into Products_Qty values (" + cbxItems.SelectedValue + "," + cpxStore.SelectedValue + ",N'" + cpxStore.Text + "'," + qty + "," + buyprice + "," + sale_price + ")", "");
                        MessageBox.Show("تمت عملية الاضافة اللآن يمكنك اضافة المنتج الى الفاتورة");
                    }
                }

                //to add the product information then add them in datagridview
                if (tblItems.Rows.Count >= 1)
                {

                    // add the product that entered in the barcode to the cpxitems ! 
                    try
                    {
                        cbxItems.SelectedValue = Convert.ToDecimal(tblItems.Rows[0][0]);
                    }
                    catch (Exception) { }

                    // to cheack the qty of the selected product ! 
                    try
                    {
                        int countQty = 0;
                        try
                        {
                            countQty = Convert.ToInt32(db.readData("select Count(Pro_ID) from Products_Qty where Pro_ID=" + cbxItems.SelectedValue + " ", "").Rows[0][0]);
                        }
                        catch (Exception) { }

                        // to retrun the buy price of the qty
                        tblPrice = db.readData("select * from Products_Qty where Pro_ID=" + cbxItems.SelectedValue + " ", "");



                        string Product_ID = tblItems.Rows[0][0].ToString();
                        string Product_Name = tblItems.Rows[0][1].ToString();
                        string Product_Qty = "1";

                        // countQty its for the number of the rows (qty) of the same product and the -1 to give me the modern price of the qty of the same product ! cuz its diffrent from date to date!
                        string Product_Price = tblPrice.Rows[countQty - 1][4].ToString();
                        decimal Discount = 0;
                        string Product_Unit = tblItems.Rows[0][16].ToString();


                        //add row to datagridview
                        DgvBuy.Rows.Add(1);

                        // number of the rows in the datagridview to show me where am i in any row of the rows
                        int rowindex = DgvBuy.Rows.Count - 1;

                        //bring me the last row to add information to this row
                        DgvBuy.Rows[rowindex].Cells[0].Value = Product_ID;
                        DgvBuy.Rows[rowindex].Cells[1].Value = Product_Name;
                        DgvBuy.Rows[rowindex].Cells[2].Value = Product_Unit;
                        DgvBuy.Rows[rowindex].Cells[3].Value = Product_Qty;

                        // give me the the qty of the unit to cheack if it is small or lagre to check the price of the unit !
                        tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + DgvBuy.CurrentRow.Cells[0].Value + " and Unit_Name=N'" + DgvBuy.CurrentRow.Cells[2].Value + "' ", "");

                        decimal realPrice = 0;
                        try
                        {
                            realPrice = Convert.ToDecimal(Product_Price) / Convert.ToDecimal(tblUnit.Rows[0][3]);
                        }
                        catch (Exception) { }

                        decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(realPrice);

                        DgvBuy.Rows[rowindex].Cells[4].Value = Math.Round(realPrice, 2);
                        DgvBuy.Rows[rowindex].Cells[5].Value = Discount;
                        DgvBuy.Rows[rowindex].Cells[6].Value = Math.Round(total, 2);
                    }
                    catch (Exception) { }

                    //for the total textbox sum addtion 
                    try
                    {
                        decimal TotalOrder = 0;

                        for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                        {
                            TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[6].Value);

                            //to select the row after add it in the grid to edit the qty of the product
                            //DgvBuy.ClearSelection();
                            //DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                            //DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;
                        }
                        txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

                        //to evalute the number of products in the datagridview
                        lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();
                    }
                    catch (Exception) { }

                }

            }
        }

        public void UpdateQty()
        {
                if (DgvBuy.Rows.Count >= 1)
                {
                    // variables from system.properties 
                    Properties.Settings.Default.Pro_Unit = Convert.ToString(DgvBuy.CurrentRow.Cells[2].Value);
                    Properties.Settings.Default.item_Qty = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[3].Value);
                    Properties.Settings.Default.item_BuyPrice = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[4].Value);
                    Properties.Settings.Default.item_Discount = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[5].Value);
                    Properties.Settings.Default.Pro_ID = Convert.ToInt32(DgvBuy.CurrentRow.Cells[0].Value);

                    // save this variables
                    Properties.Settings.Default.Save();

                    frm_BuyQty frm = new frm_BuyQty();
                    frm.ShowDialog();

                }
        }


        private void InsertAndUpdateData()
        {

            DataTable tblUnit = new DataTable();
            tblUnit.Clear();

            DataTable tblQty = new DataTable();
            tblQty.Clear();

            string d = DtpDate.Value.ToString("dd/MM/yyyy");
            db.executedata("insert into Buy values (" + txtID.Text + ",N'" + d + "'," + cpxSupplier.SelectedValue + ")", "");

            // to give me the tax value before and after to each product !
            decimal taxvalue = 0, taxpersent = 0, priceBeforeTax = 0, qtyInMain = 0, realQty = 0, TotalTax = 0;
            for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
            {
                try
                {
                    taxpersent = Convert.ToDecimal(db.readData("select * from Products where Pro_ID=" + DgvBuy.Rows[i].Cells[0].Value + " ", "").Rows[0][5]);
                }
                catch (Exception) { }

                taxvalue = (Convert.ToDecimal(DgvBuy.Rows[i].Cells[4].Value) / 100) * taxpersent;
                TotalTax += taxvalue * Convert.ToDecimal(DgvBuy.Rows[i].Cells[3].Value);

                priceBeforeTax = Convert.ToDecimal(DgvBuy.Rows[i].Cells[4].Value) - taxvalue;

                db.executedata("insert into Buy_Destails values (" + txtID.Text + "," + cpxSupplier.SelectedValue + "," + DgvBuy.Rows[i].Cells[0].Value + ",'" + d + "'," + DgvBuy.Rows[i].Cells[3].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + priceBeforeTax + "," + DgvBuy.Rows[i].Cells[5].Value + "," + DgvBuy.Rows[i].Cells[6].Value + "," + txtTotal.Text + "," + Properties.Settings.Default.Madfou3 + "," + Properties.Settings.Default.Bakey + "," + taxvalue + "," + DgvBuy.Rows[i].Cells[4].Value + ",N'" + date.Text + "',N'" + DgvBuy.Rows[i].Cells[2].Value + "') ", "");

                // to give me the qty of the item and his unit if its small or large , to add the qty to it !
                tblUnit = db.readData("select * from Products_Unit where Pro_ID=" + DgvBuy.Rows[i].Cells[0].Value + " and Unit_Name=N'" + DgvBuy.Rows[i].Cells[2].Value + "' ", "");
                qtyInMain = Convert.ToDecimal(tblUnit.Rows[0][3]);

                realQty = Convert.ToDecimal(DgvBuy.Rows[i].Cells[3].Value) / qtyInMain;

                // to add the qty to the qty of the product table
                db.executedata("update Products set Qty=Qty + " + realQty + " where Pro_ID=" + DgvBuy.Rows[i].Cells[0].Value + " ", "");

                // check if there are a qty of the product in the same price of the store update it , if its not insert it !
                tblQty = db.readData("select * from Products_Qty where Pro_ID=" + DgvBuy.Rows[i].Cells[0].Value + " and Store_ID=" + cpxStore.SelectedValue + " and Buy_Price=" + DgvBuy.Rows[i].Cells[4].Value + " ", "");

                if (tblQty.Rows.Count >= 1)
                {
                    db.executedata("update Products_Qty set Qty=Qty + " + realQty + " where Pro_ID=" + DgvBuy.Rows[i].Cells[0].Value + " and Store_ID=" + cpxStore.SelectedValue + " and Buy_Price=" + DgvBuy.Rows[i].Cells[4].Value + " ", "");
                }

                else
                {
                    decimal SalePrice = 0;

                    try
                    {
                        SalePrice = Convert.ToDecimal(db.readData("select * from Products where Pro_ID=" + DgvBuy.Rows[i].Cells[0].Value + "", "").Rows[0][6]);
                    }
                    catch (Exception) { }
                    db.executedata("insert into Products_Qty values (" + DgvBuy.Rows[i].Cells[0].Value + "," + cpxStore.SelectedValue + ",N'" + cpxStore.Text + "'," + realQty + "," + DgvBuy.Rows[i].Cells[4].Value + "," + SalePrice + ") ", "");
                }
            }
            decimal totalBeforeTax = 0;
            totalBeforeTax = Convert.ToDecimal(txtTotal.Text) - TotalTax;
            db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + txtID.Text + ",N'فاتورة مشتريات',N'قيمة مضافة',N'" + cpxSupplier.Text + "',N'لايوجد'," + totalBeforeTax + "," + TotalTax + "," + txtTotal.Text + ",N'" + d + "') ", "");
        }

        string Stock_ID = "";
        private bool CheckIfTheMoneyExist()
        {
            DataTable tblstock = new DataTable();
            tblstock.Clear();

            decimal Stock_Money = 0;

            tblstock = db.readData("select * from Stock where Stock_ID=" + Stock_ID + " ", "");

            Stock_Money = Convert.ToDecimal(tblstock.Rows[0][1]);

            if (Convert.ToDecimal(Properties.Settings.Default.Madfou3) > Stock_Money)
            {
                MessageBox.Show("المبلغ المدفوع غير موجود في الخزنة ", "تنبيه !");
                return false;
            }

            string date1 = DtpDate.Value.ToString("dd/MM/yyyy");

            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + Properties.Settings.Default.Madfou3 + ",N'" + date1 + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'عملية شراء',N'.') ", "");

            db.executedata("update Stock set Money=Money - " + Properties.Settings.Default.Madfou3 + " where Stock_ID=" + Stock_ID + "  ", "");
            return true;

        }

        public void PayOrderCash()
        {
            if (DgvBuy.Rows.Count >= 1)
            {
                if (cpxSupplier.Text == "اختر مورد") { MessageBox.Show("من فضلك اختر مورد "); return; }
                if (cpxStore.Items.Count <= 0) { MessageBox.Show("من فضلك قم بإضافة مخازن "); return; }


                try
                {

                    if (DgvBuy.Rows.Count >= 1)
                    {
                        // to set send the  parameters to the system.propertirs 

                        Properties.Settings.Default.TotalOrder = Convert.ToDecimal(txtTotal.Text);
                        Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtTotal.Text);
                        Properties.Settings.Default.Bakey = 0;
                        Properties.Settings.Default.CheckButton = true;
                        Properties.Settings.Default.Save();
                    }

                    // to cheack of the system.properties.cheackbutton if its true to save the order or false to close the form and not saving the order

                    if (Properties.Settings.Default.CheckButton == true)
                    {
                        bool check = CheckIfTheMoneyExist();
                        if (check == false)
                        {
                            return;
                        }

                        // do ther payment !
                        InsertAndUpdateData();
                        // for cash and aagel

                        if (rbtnCash.Checked == true)
                        {
                            string d = DtpDate.Value.ToString("dd/MM/yyyy");
                            db.executedata("insert into Supplier_Report values(" + txtID.Text + "," + Properties.Settings.Default.Madfou3 + ",N'" + d + "'," + cpxSupplier.SelectedValue + ") ", "");
                        }

                        else if (rbtnAagel.Checked == true)
                        {
                            string dorder = DtpDate.Value.ToString("dd/MM/yyyy");
                            string dreminder = DtpAagel.Value.ToString("dd/MM/yyyy");
                            db.executedata("insert into Supplier_Money values(" + txtID.Text + "," + cpxSupplier.SelectedValue + "," + Properties.Settings.Default.Bakey + ",N'" + dorder + "',N'" + dreminder + "') ", "");

                            if (Properties.Settings.Default.Madfou3 >= 1)
                            {
                                string d = DtpDate.Value.ToString("dd/MM/yyyy");
                                db.executedata("insert into Supplier_Report values(" + txtID.Text + "," + Properties.Settings.Default.Madfou3 + ",N'" + d + "'," + cpxSupplier.SelectedValue + ") ", "");

                            }
                        }

                        // if the user active the print of buy form from setting form do the print !
                        if (Properties.Settings.Default.BuyPrint == true)
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
                            for (int i = 0; i <= Properties.Settings.Default.BuyPrintNum - 1; i++)
                            {
                                Print();
                            }
                        }
                        tr.TrackerInsert("شاشة المشتريات", "تسديد نقدي , رقم الفاتورة",txtID.Text);
                        AutoNumber();

                    }


                }

                catch (Exception) { }
            }
        }
    
        private void PayOrder()
        {


            if (DgvBuy.Rows.Count >= 1)
            {
                if (cpxSupplier.Text == "اختر مورد") { MessageBox.Show("من فضلك اختر مورد "); return; }
                if (cpxStore.Items.Count <= 0) { MessageBox.Show("من فضلك قم بإضافة مخازن "); return; }


                try
                {

                    if (DgvBuy.Rows.Count >= 1)
                    {
                        // to set send the  parameters to the system.propertirs 

                        Properties.Settings.Default.TotalOrder = Convert.ToDecimal(txtTotal.Text);
                        Properties.Settings.Default.Madfou3 = 0;
                        Properties.Settings.Default.Bakey = 0;
                        Properties.Settings.Default.Save();

                        frm_PayBuy frm = new frm_PayBuy();
                        frm.ShowDialog();
                    }

                    // to cheack of the system.properties.cheackbutton if its true to save the order or false to close the form and not saving the order

                    if (Properties.Settings.Default.CheckButton == true)
                    {
                        bool check = CheckIfTheMoneyExist();
                        if (check == false)
                        {
                            return;
                        }

                        // do ther payment !
                        InsertAndUpdateData();
                        // for cash and aagel

                        if (rbtnCash.Checked == true)
                        {
                            string d = DtpDate.Value.ToString("dd/MM/yyyy");
                            db.executedata("insert into Supplier_Report values(" + txtID.Text + "," + Properties.Settings.Default.Madfou3 + ",N'" + d + "'," + cpxSupplier.SelectedValue + ") ", "");
                        }

                        else if (rbtnAagel.Checked == true)
                        {
                            string dorder = DtpDate.Value.ToString("dd/MM/yyyy");
                            string dreminder = DtpAagel.Value.ToString("dd/MM/yyyy");
                            db.executedata("insert into Supplier_Money values(" + txtID.Text + "," + cpxSupplier.SelectedValue + "," + Properties.Settings.Default.Bakey + ",N'" + dorder + "',N'" + dreminder + "') ", "");

                            if (Properties.Settings.Default.Madfou3 >= 1)
                            {
                                string d = DtpDate.Value.ToString("dd/MM/yyyy");
                                db.executedata("insert into Supplier_Report values(" + txtID.Text + "," + Properties.Settings.Default.Madfou3 + ",N'" + d + "'," + cpxSupplier.SelectedValue + ") ", "");

                            }
                        }

                        // if the user active the print of buy form from setting form do the print !
                        if (Properties.Settings.Default.BuyPrint == true)
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
                            for (int i = 0; i <= Properties.Settings.Default.BuyPrintNum - 1; i++)
                            {
                                Print();
                            }
                        }
                        tr.TrackerInsert("شاشة المشتريات", "تسديد آجل , رقم الفاتورة", txtID.Text);
                        AutoNumber();

                    }


                }

                catch (Exception) { }
            }
        }

        // methode to print 8 cm order or A4
        private void Print()
        {
            // the same order id of the order 

            int id = Convert.ToInt32(txtID.Text);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + id + "", "");

            frm_Printing frm = new frm_Printing();



            frm.crystalReportViewer1.RefreshReport();

            if (Properties.Settings.Default.BuyPrintKind == "8CM")
            {
                RptOrderBuy rpt = new RptOrderBuy();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                //rpt.PrintToPrinter(1, true, 0, 0);

                frm.ShowDialog();
            }

            else if (Properties.Settings.Default.BuyPrintKind == "A4")
            {
                RptOrderBuyA4 rpt = new RptOrderBuyA4();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                //rpt.PrintToPrinter(1, true, 0, 0);

                frm.ShowDialog();
            }


        }

        private void frm_Buy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {

                if(rbtnCash.Checked==true)
                {
                    PayOrderCash();
                }

                if (rbtnAagel.Checked == true)
                {
                    PayOrder();
                }
            }

            else if (e.KeyCode == Keys.F11) {

                UpdateQty();

                // copy it from frm_buyqty sometimes after closing the frm_buy and opening it we cannot apply to edit the qty of the products
                try
                {
                    // select the current row that selected in datagridview
                    int index = DgvBuy.SelectedRows[0].Index;
                    DgvBuy.Rows[index].Cells[2].Value = Properties.Settings.Default.Pro_Unit;
                    DgvBuy.Rows[index].Cells[3].Value = Properties.Settings.Default.item_Qty;
                    DgvBuy.Rows[index].Cells[4].Value = Properties.Settings.Default.item_BuyPrice;
                    DgvBuy.Rows[index].Cells[5].Value = Properties.Settings.Default.item_Discount;
                }
                catch (Exception) { }

            }

            else if (e.KeyCode == Keys.F1)
            {
                txtBarcode.Clear();
                txtBarcode.Focus();
            }

            else if (e.KeyCode == Keys.F2)
            {
                btnItems_Click(null, null);
            }

            else if (e.KeyCode == Keys.X)
            {
                btnDeleteItems_Click(null, null);
            }

        }

        private void DgvBuy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // to find the eqaution of the function sum after the qty of the product changed by user

            decimal Item_Qty = 0, Item_BuyPrice = 0, Item_Discount = 0;

            try
            {
                // to bring us the row that we need to use the sum function on

                int index = DgvBuy.SelectedRows[0].Index;

                Item_Qty = Convert.ToDecimal(DgvBuy.Rows[index].Cells[3].Value);
                Item_BuyPrice = Convert.ToDecimal(DgvBuy.Rows[index].Cells[4].Value);
                Item_Discount = Convert.ToDecimal(DgvBuy.Rows[index].Cells[5].Value);

                decimal Total = 0;
                Total = (Item_Qty * Item_BuyPrice) - Item_Discount;

                //to display the total in the datagridview

                DgvBuy.Rows[index].Cells[6].Value = Total;

                // for the total of the textbox

                decimal TotalOrder = 0;

                for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                {
                    TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[6].Value);
                }

                txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

                //to evalute the number of products in the datagridview
                lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();

            }
            catch (Exception) { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=9KjLs9n-Soc&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=5");
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            DtpAagel.Enabled = false;
        }

        private void rbtnAagel_CheckedChanged(object sender, EventArgs e)
        {
            DtpAagel.Enabled = true;
        }

        private void DgvBuy_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (DgvBuy.Rows.Count >= 1)
                {
                    // variables from system.properties 
                    Properties.Settings.Default.Pro_Unit = Convert.ToString(DgvBuy.CurrentRow.Cells[2].Value);
                    Properties.Settings.Default.item_Qty = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[3].Value);
                    Properties.Settings.Default.item_BuyPrice = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[4].Value);
                    Properties.Settings.Default.item_Discount = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[5].Value);
                    Properties.Settings.Default.Pro_ID = Convert.ToInt32(DgvBuy.CurrentRow.Cells[0].Value);

                    // save this variables
                    Properties.Settings.Default.Save();

                    frm_BuyQty frm = new frm_BuyQty();
                    frm.ShowDialog();

                    // select the current row that selected in datagridview
                    int index = DgvBuy.SelectedRows[0].Index;
                    DgvBuy.Rows[index].Cells[2].Value = Properties.Settings.Default.Pro_Unit;
                    DgvBuy.Rows[index].Cells[3].Value = Properties.Settings.Default.item_Qty;
                    DgvBuy.Rows[index].Cells[4].Value = Properties.Settings.Default.item_BuyPrice;
                    DgvBuy.Rows[index].Cells[5].Value = Properties.Settings.Default.item_Discount;
                }
            }
            catch (Exception) { }
        }
    }

}

    
