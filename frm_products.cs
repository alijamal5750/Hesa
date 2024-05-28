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
    public partial class frm_products : DevExpress.XtraEditors.XtraForm
    {

        int USER_ID = 0;

        //for supplier adding button 
        private static frm_products  frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static frm_products GetForm
        {

            get
            {
                if (frm == null)
                {
                    frm = new frm_products();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        public frm_products()
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
        DataTable reload = new DataTable();

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

 
        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            //Random n = new Random();
            //int x = n.Next(1,1000000000);

            int y = 1;
            tbl.Clear();
            tbl = db.readData("select Max(Pro_ID) from Products ", "");

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

            try
            {
                if (Properties.Settings.Default.Taxes == true)
                {
                    cheackTaxes.Checked = true;
                }
                else { cheackTaxes.Checked = false; }

                txtBarcode.Clear();
                txtProName.Clear();
                txtSearch.Clear();
                NudGomlaPrice.Value = 1;
                NudSalePrice.Value = 1;
                NudAllQty.Value = 0;
                NudMiniQty.Value = 0;
                NudMaxDiscount.Value = 0;
                NudQtyStore.Value = 1;
                NudBuyPriceStore.Value = 1;
                NudUnitPrice.Value = 1;
                NudQtyInMain.Value = 1;
                
                cpxProduct.SelectedIndex = 0;

                if(DgvStore.Rows.Count >= 1)
                {
                    DgvStore.Rows.Clear();
                }
                if (DgvUnit.Rows.Count >=1)
                {
                    DgvUnit.Rows.Clear();
                }
               
               
                cpxMainUnit.SelectedIndex = 0;
                cpxUnitSale.SelectedIndex = 0;
                cpxUnitBuy.SelectedIndex = 0;
                cpxGroup.SelectedIndex = 0;
                cpxStore.SelectedIndex = 0;

                FillPro();
            }
            catch (Exception) { }

            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;
            btnPrintBarcode.Enabled = false;
        }


        //function to the arrows
        int row;
        private void show()
        {
            txtBarcode.Clear();
            tbl.Clear();
            tbl = db.readData("select * from Products", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لاتوجد بيانات في هذه الشاشة");
            }

            else
            {
                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtProName.Text = tbl.Rows[row][1].ToString();
                    NudAllQty.Value = Convert.ToDecimal(tbl.Rows[row][2]);
                    NudGomlaPrice.Value = Convert.ToDecimal(tbl.Rows[row][3]);
                    NudSalePrice.Value = Convert.ToDecimal(tbl.Rows[row][4]);
                    NudTax.Value = Convert.ToDecimal(tbl.Rows[row][5]);
                    txtSalePriceTax.Text = tbl.Rows[row][6].ToString();
                    txtBarcode.Text = tbl.Rows[row][7].ToString();
                    NudMiniQty.Value = Convert.ToDecimal(tbl.Rows[row][8]);
                    NudMaxDiscount.Value = Convert.ToDecimal(tbl.Rows[row][9]);

                    // for the is_tax column !
                    if (tbl.Rows[row][10].ToString() == "خاضع للضريبة")
                    {
                        cheackTaxes.Checked = true;
                    }
                    else if (tbl.Rows[row][10].ToString() == "غير خاضع للضريبة")
                    {
                        cheackTaxes.Checked = false;
                    }

                    cpxGroup.SelectedValue = Convert.ToInt32(tbl.Rows[row][11]);
                    cpxMainUnit.SelectedValue = Convert.ToInt32(tbl.Rows[row][13]);
                    cpxUnitSale.SelectedValue = Convert.ToInt32(tbl.Rows[row][15]);
                    cpxUnitBuy.SelectedValue = Convert.ToInt32(tbl.Rows[row][17]);

                }
                catch (Exception) { }
            }

            try
            {
                DataTable tblstore = new DataTable();
                tblstore.Clear();
                tblstore = db.readData("select * from Products_Qty where Pro_ID=" + txtID.Text + " ", "");
                DgvStore.Rows.Clear();
                if (tblstore.Rows.Count >= 1)
                {
                    // cuz it not a single coulumn we use for or foreach ! 

                    foreach (DataRow row in tblstore.Rows)
                    {

                        DgvStore.Rows.Add(1);

                        int indexrow = DgvStore.Rows.Count - 1;

                        DgvStore.Rows[indexrow].Cells[0].Value = row[2];
                        DgvStore.Rows[indexrow].Cells[1].Value = row[3];
                        DgvStore.Rows[indexrow].Cells[2].Value = row[4];
                    }
                }
            }
            catch (Exception) { }

            try
            {
                DataTable tblunit = new DataTable();
                tblunit.Clear();
                tblunit = db.readData("select * from Products_Unit where Pro_ID=" + txtID.Text + " ", "");
                DgvUnit.Rows.Clear();
                if (tblunit.Rows.Count >= 1)
                {

                    for (int i = 0; i <= tblunit.Rows.Count - 1; i++)
                  {
                        DgvUnit.Rows.Add(1);

                        int indexrow = DgvUnit.Rows.Count - 1;

                        DgvUnit.Rows[indexrow].Cells[0].Value = tblunit.Rows[i][2];
                        DgvUnit.Rows[indexrow].Cells[1].Value =tblunit.Rows[i][3];
                        DgvUnit.Rows[indexrow].Cells[2].Value = tblunit.Rows[i][4];
                        
                        } 
                }
            }
            catch (Exception) { }

            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
            btnPrintBarcode.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_products_Load(object sender, EventArgs e)
        {
            
            try
            {
                 USER_ID = Convert.ToInt32(db.readData("select * from Users where User_Name=N'" + Properties.Settings.Default.Defualt_USERNAME + "'", "").Rows[0][0]);
                AutoNumber();
                FillPro();
                FillUnit();
                FillGroup();
                FillStore();
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            show();
        }

        public void FillUnit()
        {
            cpxMainUnit.DataSource = db.readData("select * from Units ", "");
            cpxMainUnit.DisplayMember = "Unit_Name";
            cpxMainUnit.ValueMember = "Unit_ID";

            cpxUnitSale.DataSource = db.readData("select * from Units ", "");
            cpxUnitSale.DisplayMember = "Unit_Name";
            cpxUnitSale.ValueMember = "Unit_ID";

            cpxUnitBuy.DataSource = db.readData("select * from Units ", "");
            cpxUnitBuy.DisplayMember = "Unit_Name";
            cpxUnitBuy.ValueMember = "Unit_ID";

            cpxUnit.DataSource = db.readData("select * from Units ", "");
            cpxUnit.DisplayMember = "Unit_Name";
            cpxUnit.ValueMember = "Unit_ID";
        }

        public void FillPro()
        {
            cpxProduct.DataSource = db.readData("select * from Products ", "");
            cpxProduct.DisplayMember = "Pro_Name";
            cpxProduct.ValueMember = "Pro_ID";
        }

        public void FillGroup()
        {
            cpxGroup.DataSource = db.readData("select * from Products_Group ", "");
            cpxGroup.DisplayMember = "Group_Name";
            cpxGroup.ValueMember = "Group_ID";
        }

        public void FillStore()
        {
            cpxStore.DataSource = db.readData("select * from Store ", "");
            cpxStore.DisplayMember = "Store_Name";
            cpxStore.ValueMember = "Store_ID";
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Pro_ID) from Products", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }

            else
            {
                row--;
                show();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Pro_ID) from Products", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
            {
                row = 0;
                show();
            }
            else
            {
                row++;
                show();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Pro_ID) from Products", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        // we do this kind of validation cuz its the best to stop the executional of the conditions !
        // do the validation when user addes information !
        private bool Validation()
        {

            if (DgvStore.Rows.Count <= 0)
            {
                MessageBox.Show("قم بادخال اسم المخزن مع الكميات الخاصة بالمنتج");
                return false;
            }

            if (cpxMainUnit.Items.Count <=0)
            {
                MessageBox.Show("الرجاء ادخال اسم الفئة الكبرى الخاصة بالمنتج");
                return false;
            }

            if (cpxStore.Items.Count <=0)
            {
                MessageBox.Show("الرجاء ادخال اسم المخزن و الكمية الخاصة بالمنتج");
                return false;
            }

            if (cpxGroup.Items.Count <=0)
            {
                MessageBox.Show("الرجاء ادخال فئة المنتج");
                return false;
            }

            if (txtProName.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم المنتج");
                return false;
            }

            if (NudGomlaPrice.Value <= 0)
            {
                MessageBox.Show("لايمكن ان يكون سعر الشراء اقل من 1");
                return false;
            }

            if (NudSalePrice.Value <= 0)
            {
                MessageBox.Show("لايمكن ان يكون سعر البيع اقل من 1");
                return false;
            }

            if (NudMaxDiscount.Value >= NudSalePrice.Value)
            {
                MessageBox.Show("لايمكن ان يكون الخصم المسموح اكبر من سعر البيع");
                return false;
            }

            if (NudGomlaPrice.Value > NudSalePrice.Value)
            {

                MessageBox.Show("لايمكن ان يكون سعر الشراء اكبر من سعر البيع");
                return false;
            }

            if (NudAllQty.Value <= 0)
            {
                MessageBox.Show("لايمكن ان تكون الكمية لمضافة للمنتج اقل من 1");
                return false;
            }

            //DataTable barcode = new DataTable();
            //barcode.Clear();
            //barcode = db.readData("select * from products where Barcode=N'" + txtBarcode.Text + "' ", "");
            //if (barcode.Rows.Count >= 1) { MessageBox.Show("الباركود مستخدم سابقاً"); return false; }

            return true;
            //if (NudMiniQty.Value > NudAllQty.Value)
            //{

            //    MessageBox.Show("لايمكن ان يكون حد الطلب اكبر من الكمية المخزنة");
            //    return;
            //}
        }

        public bool Number()
        {
            DataTable number = new DataTable();
            number.Clear();
           

            number = db.readData("select * from Products","");
            
            if (number.Rows.Count == 2500)
            {
                MessageBox.Show("لقد بلغت المنتجات الحد الاقصى و هو 2500 يرجى الاتصال بمطور البرنامج لزيادة العدد","تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            DataTable barcode = new DataTable();
            barcode.Clear();
            barcode = db.readData("select * from products where Barcode=N'" + txtBarcode.Text + "' ", "");
            if (barcode.Rows.Count >= 1) { MessageBox.Show("الباركود مستخدم سابقاً"); return false; }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool num = false;
            num = Number();
            if (num == true)
            {
                bool check = false;
                check = Validation();
                if (check == true)
                {

                    string is_Tax = "";
                    if (cheackTaxes.Checked == true)
                    {
                        is_Tax = "خاضع للضريبة";
                    }

                    else if (cheackTaxes.Checked == false)
                    {
                        is_Tax = "غير خاضع للضريبة";
                    }

                    db.executedata("insert into Products Values (" + txtID.Text + ",N'" + txtProName.Text + "'," + NudAllQty.Value + "," + NudGomlaPrice.Value + "," + NudSalePrice.Value + "," + NudTax.Value + "," + txtSalePriceTax.Text + ",N'" + txtBarcode.Text + "'," + NudMiniQty.Value + "," + NudMaxDiscount.Value + ",N'" + is_Tax + "'," + cpxGroup.SelectedValue + ",N'" + cpxMainUnit.Text + "'," + cpxMainUnit.SelectedValue + ",N'" + cpxUnitSale.Text + "'," + cpxUnitSale.SelectedValue + ",N'" + cpxUnitBuy.Text + "'," + cpxUnitBuy.SelectedValue + " ) ", "");

                    //add the qty from the dgv store to the Products_Qty Table 
                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        // bring me the store_id from the Store_name for each store cuz we dont have one store all the time !
                        int Store_ID = 0;
                        try
                        {
                            Store_ID = Convert.ToInt32(db.readData("select * from Store where Store_Name=N'" + DgvStore.Rows[i].Cells[0].Value + "' ", "").Rows[0][0]);
                        }
                        catch (Exception) { }
                        db.executedata("insert into Products_Qty values (" + txtID.Text + "," + Store_ID + ",N'" + DgvStore.Rows[i].Cells[0].Value + "'," + DgvStore.Rows[i].Cells[1].Value + "," + DgvStore.Rows[i].Cells[2].Value + "," + txtSalePriceTax.Text + ") ", "");
                    }

                    //add the qty from the dgv unit to the Products_Unit Table 
                    for (int i = 0; i <= DgvUnit.Rows.Count - 1; i++)
                    {
                        // bring me the unit_id from the unit_name for each unit cuz we dont have one unit all the time !
                        int Unit_ID = 0;
                        try
                        {
                            Unit_ID = Convert.ToInt32(db.readData("select * from Units where Unit_Name=N'" + DgvUnit.Rows[i].Cells[0].Value + "' ", "").Rows[0][0]);

                            db.executedata("insert into Products_Unit values (" + txtID.Text + "," + Unit_ID + ",N'" + DgvUnit.Rows[i].Cells[0].Value + "'," + DgvUnit.Rows[i].Cells[1].Value + "," + DgvUnit.Rows[i].Cells[2].Value + "," + txtSalePriceTax.Text + ") ", "");
                        }
                        catch (Exception) { }

                    }

                    // بعد اضافة الوحدات الصغيرة مثل العلبة قم بأضافة الكرتونة بشكل كامل و اللي تكون الوحدة الكبيرة 
                    // after adding the small items from the cpx unit (small_items) add the big items from the cpxmainunit to have the big unit item price and the rest of small items and their prices!
                    db.executedata("insert into Products_Unit values (" + txtID.Text + "," + cpxMainUnit.SelectedValue + ",N'" + cpxMainUnit.Text + "' ,1, " + txtSalePriceTax.Text + "," + txtSalePriceTax.Text + ") ", "");
                    MessageBox.Show("تمت الاضافة بنجاح", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tr.TrackerInsert("شاشة المنتجات", "اضافة منتج",txtProName.Text);
                    AutoNumber();

                   // for the page nor reload after insert the first product : 
                    reload.Clear();
                    reload = db.readData("select * from Products", ""); if(reload.Rows.Count == 1) { AutoNumber(); frm_products_Load(null, null); }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = false;
            check = Validation();
            if (check == true)
            {

                string is_Tax = "";
                if (cheackTaxes.Checked == true)
                {
                    is_Tax = "خاضع للضريبة";
                }

                else if (cheackTaxes.Checked == false)
                {
                    is_Tax = "غير خاضع للضريبة";
                }

                db.executedata("update Products set Pro_Name=N'" + txtProName.Text + "',Qty=" + NudAllQty.Value + ",Gomla_Price=" + NudGomlaPrice.Value + ",Sale_Price=" + NudSalePrice.Value + ",Tax_Value=" + NudTax.Value + ",Sale_PriceTax=" + txtSalePriceTax.Text + ",Barcode=N'" + txtBarcode.Text + "',MinyQty=" + NudMiniQty.Value + ",MaxDiscount=" + NudMaxDiscount.Value + ",IS_Tax=N'" + is_Tax + "',Group_ID=" + cpxGroup.SelectedValue + ",Main_UnitName=N'" + cpxMainUnit.Text + "',Main_UnitId=" + cpxMainUnit.SelectedValue + ",Sale_UnitName=N'" + cpxUnitSale.Text + "',Sale_UnitID=" + cpxUnitSale.SelectedValue + ",Buy_UnitName=N'" + cpxUnitBuy.Text + "',Buy_UnitID=" + cpxUnitBuy.SelectedValue + " where Pro_ID=" + txtID.Text + " ", "");

                // delete the qty then add the new one ! 
                db.executedata("delete from Products_Qty where Pro_ID= "+txtID.Text+" ", "");
                
                
                //add the qty from the dgv store to the Products_Qty Table before doing the autonumber ! 
                for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                {
                    // bring me the store_id from the Store_name for each store cuz we dont have one store all the time !
                    int Store_ID = 0;
                    try
                    {
                        Store_ID = Convert.ToInt32(db.readData("select * from Store where Store_Name=N'" + DgvStore.Rows[i].Cells[0].Value + "' ", "").Rows[0][0]);
                    }
                    catch (Exception) { }
                    db.executedata("insert into Products_Qty values (" + txtID.Text + "," + Store_ID + ",N'" + DgvStore.Rows[i].Cells[0].Value + "'," + DgvStore.Rows[i].Cells[1].Value + "," + DgvStore.Rows[i].Cells[2].Value + "," + txtSalePriceTax.Text + ") ", "");
                }

                // delete the units and then add the new before doing the autonumber ! 
                db.executedata("delete from Products_Unit where Pro_ID= " + txtID.Text + " ", "");

                //add the qty from the dgv unit to the Products_Unit Table 
                for (int i = 0; i <= DgvUnit.Rows.Count - 1; i++)
                {
                    // bring me the store_id from the Store_name for each store cuz we dont have one store all the time !
                    int Unit_ID = 0;
                    try
                    {
                        Unit_ID = Convert.ToInt32(db.readData("select * from Units where Unit_Name=N'" + DgvUnit.Rows[i].Cells[0].Value + "' ", "").Rows[0][0]);

                        db.executedata("insert into Products_Unit values (" + txtID.Text + "," + Unit_ID + ",N'" + DgvUnit.Rows[i].Cells[0].Value + "'," + DgvUnit.Rows[i].Cells[1].Value + "," + DgvUnit.Rows[i].Cells[2].Value + "," + txtSalePriceTax.Text + ") ", "");
                    }
                    catch (Exception) { }

                }

                // validation for the main unit if its exiest do the edit and stop the program
                string unit_name = cpxMainUnit.Text;
                for (int i = 0; i <= DgvUnit.Rows.Count - 1; i++)
                {
                    if (unit_name == DgvUnit.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tr.TrackerInsert("شاشة المنتجات", "تعديل منتج", txtProName.Text);
                        AutoNumber();
                        return;
                    }
                }
                    // بعد اضافة الوحدات الصغيرة مثل العلبة قم بأضافة الكرتونة بشكل كامل و اللي تكون الوحدة الكبيرة 
                    // after adding the small items from the cpx unit (small_items) add the big items from the cpxmainunit to have the big unit item price and the rest of small items and their prices!
                    db.executedata("insert into Products_Unit values (" + txtID.Text + "," + cpxMainUnit.SelectedValue + ",N'" + cpxMainUnit.Text + "' ,1, " + txtSalePriceTax.Text + "," + txtSalePriceTax.Text + ") ", "");
                MessageBox.Show("تم التعديل بنجاح", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tr.TrackerInsert("شاشة المنتجات", "تعديل منتج", txtProName.Text);
                AutoNumber();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المنتج؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products_Qty where Pro_ID= " + txtID.Text + " ", "");
                db.readData("delete from Products_Unit where Pro_ID= " + txtID.Text + " ", "");
                db.readData("delete from Products where Pro_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة المنتجات", "حذف منتج", txtProName.Text);
                AutoNumber();
                FillPro();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف كل المنتجات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products_Qty  ", "");
                db.readData("delete from Products_Unit  ", "");
                db.readData("delete from Products  ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة المنتجات", "حذف كل المنتجات", "");
                AutoNumber();
                FillPro();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                DataTable tblsearch = new DataTable();
                tblsearch.Clear();

                tblsearch = db.readData("select * from Products where Pro_Name + Barcode like '%" + txtSearch.Text + "%'", "");

                if (tblsearch.Rows.Count <= 0)
                {
                    MessageBox.Show("لا توجد منتجات !");
                }

                else
                {
                    try
                    {
                        txtID.Text = tblsearch.Rows[0][0].ToString();
                        txtProName.Text = tblsearch.Rows[0][1].ToString();
                        NudAllQty.Value = Convert.ToDecimal(tblsearch.Rows[0][2]);
                        NudGomlaPrice.Value = Convert.ToDecimal(tblsearch.Rows[0][3]);
                        NudSalePrice.Value = Convert.ToDecimal(tblsearch.Rows[0][4]);
                        NudTax.Value = Convert.ToDecimal(tblsearch.Rows[0][5]);
                        txtSalePriceTax.Text = tblsearch.Rows[0][6].ToString();
                        txtBarcode.Text = tblsearch.Rows[0][7].ToString();
                        NudMiniQty.Value = Convert.ToDecimal(tblsearch.Rows[0][8]);
                        NudMaxDiscount.Value = Convert.ToDecimal(tblsearch.Rows[0][9]);

                        // for the is_tax column !
                        if (tblsearch.Rows[0][10].ToString() == "خاضع للضريبة")
                        {
                            cheackTaxes.Checked = true;
                        }
                        else if (tblsearch.Rows[0][10].ToString() == "غير خاضع للضريبة")
                        {
                            cheackTaxes.Checked = false;
                        }

                        cpxGroup.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][11]);
                        cpxMainUnit.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][13]);
                        cpxUnitSale.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][15]);
                        cpxUnitBuy.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][17]);

                    }
                    catch (Exception) { }


                    try
                    {
                        DataTable tblstore = new DataTable();
                        tblstore.Clear();
                        tblstore = db.readData("select * from Products_Qty where Pro_ID=" + txtID.Text + " ", "");
                        DgvStore.Rows.Clear();
                        if (tblstore.Rows.Count >= 1)
                        {
                            // cuz it not a single coulumn we use for or foreach ! 

                            foreach (DataRow row in tblstore.Rows)
                            {

                                DgvStore.Rows.Add(1);

                                int indexrow = DgvStore.Rows.Count - 1;

                                DgvStore.Rows[indexrow].Cells[0].Value = row[2];
                                DgvStore.Rows[indexrow].Cells[1].Value = row[3];
                                DgvStore.Rows[indexrow].Cells[2].Value = row[4];
                            }
                        }
                    }
                    catch (Exception) { }

                    try
                    {
                        DataTable tblunit = new DataTable();
                        tblunit.Clear();
                        tblunit = db.readData("select * from Products_Unit where Pro_ID=" + txtID.Text + " ", "");
                        DgvUnit.Rows.Clear();
                        if (tblunit.Rows.Count >= 1)
                        {

                            foreach (DataRow row in tblunit.Rows)
                            {
                                DgvUnit.Rows.Add(1);

                                int indexrow = DgvUnit.Rows.Count - 1;

                                DgvUnit.Rows[indexrow].Cells[0].Value = row[2];
                                DgvUnit.Rows[indexrow].Cells[1].Value = row[3];
                                DgvUnit.Rows[indexrow].Cells[2].Value = row[4];
                            }
                        }
                    }
                    catch (Exception) { }

                    btnAdd.Enabled = false;
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDeleteAll.Enabled = true;
                    btnSave.Enabled = true;
                    btnPrintBarcode.Enabled = true;
                }

            }
        }



        private void cpxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cpxProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtBarcode.Clear(); 

            if (cpxProduct.Items.Count >= 1)
            {
                DataTable tblsearch = new DataTable();
                tblsearch.Clear();



                {
                    tblsearch = db.readData("select * from Products where Pro_ID=" + cpxProduct.SelectedValue + "", "");

                    if (tblsearch.Rows.Count <= 0)
                    {
                        // METHODE TO NOTHING 
                    }

                    else
                    {
                        try
                        {
                            txtID.Text = tblsearch.Rows[0][0].ToString();
                            txtProName.Text = tblsearch.Rows[0][1].ToString();
                            NudAllQty.Value = Convert.ToDecimal(tblsearch.Rows[0][2]);
                            NudGomlaPrice.Value = Convert.ToDecimal(tblsearch.Rows[0][3]);
                            NudSalePrice.Value = Convert.ToDecimal(tblsearch.Rows[0][4]);
                            NudTax.Value = Convert.ToDecimal(tblsearch.Rows[0][5]);
                            txtSalePriceTax.Text = tblsearch.Rows[0][6].ToString();
                            txtBarcode.Text = tblsearch.Rows[0][7].ToString();
                            NudMiniQty.Value = Convert.ToDecimal(tblsearch.Rows[0][8]);
                            NudMaxDiscount.Value = Convert.ToDecimal(tblsearch.Rows[0][9]);

                            // for the is_tax column !
                            if (tblsearch.Rows[0][10].ToString() == "خاضع للضريبة")
                            {
                                cheackTaxes.Checked = true;
                            }
                            else if (tblsearch.Rows[0][10].ToString() == "غير خاضع للضريبة")
                            {
                                cheackTaxes.Checked = false;
                            }

                            cpxGroup.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][11]);
                            cpxMainUnit.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][13]);
                            cpxUnitSale.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][15]);
                            cpxUnitBuy.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][17]);

                        }
                        catch (Exception) { }


                        try
                        {
                            DataTable tblstore = new DataTable();
                            tblstore.Clear();
                            tblstore = db.readData("select * from Products_Qty where Pro_ID=" + txtID.Text + " ", "");
                            DgvStore.Rows.Clear();
                            if (tblstore.Rows.Count >= 1)
                            {
                                // cuz it not a single coulumn we use for or foreach ! 

                                foreach (DataRow row in tblstore.Rows)
                                {

                                    DgvStore.Rows.Add(1);

                                    int indexrow = DgvStore.Rows.Count - 1;

                                    DgvStore.Rows[indexrow].Cells[0].Value = row[2];
                                    DgvStore.Rows[indexrow].Cells[1].Value = row[3];
                                    DgvStore.Rows[indexrow].Cells[2].Value = row[4];
                                }
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            DataTable tblunit = new DataTable();
                            tblunit.Clear();
                            tblunit = db.readData("select * from Products_Unit where Pro_ID=" + txtID.Text + " ", "");
                            DgvUnit.Rows.Clear();
                            if (tblunit.Rows.Count >= 1)
                            {

                                foreach (DataRow row in tblunit.Rows)
                                {
                                    DgvUnit.Rows.Add(1);

                                    int indexrow = DgvUnit.Rows.Count - 1;

                                    DgvUnit.Rows[indexrow].Cells[0].Value = row[2];
                                    DgvUnit.Rows[indexrow].Cells[1].Value = row[3];
                                    DgvUnit.Rows[indexrow].Cells[2].Value = row[4];
                                }
                            }
                        }
                        catch (Exception) { }

                        btnAdd.Enabled = false;
                        btnNew.Enabled = true;
                        btnDelete.Enabled = true;
                        btnDeleteAll.Enabled = true;
                        btnSave.Enabled = true;
                        btnPrintBarcode.Enabled = true;
                    }

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void NudSalePrice_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal taxVal = 0; decimal SalePrice = 0;

                SalePrice = NudSalePrice.Value;

                taxVal = (SalePrice / 100) * NudTax.Value;

                if (cheackTaxes.Checked == true)
                {
                    txtSalePriceTax.Text = (SalePrice + taxVal).ToString();
                }

                else if (cheackTaxes.Checked == false)
                {
                    txtSalePriceTax.Text = (SalePrice + taxVal).ToString();
                }
            }
            catch (Exception) { }
        }

        private void NudTax_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal taxVal = 0; decimal SalePrice = 0;

                SalePrice = NudSalePrice.Value;

                taxVal = (SalePrice / 100) * NudTax.Value;

                if (cheackTaxes.Checked == true)
                {
                    txtSalePriceTax.Text = (SalePrice + taxVal).ToString();
                }

                else if (cheackTaxes.Checked == false)
                {
                    txtSalePriceTax.Text = (SalePrice + taxVal).ToString();
                }
            }
            catch (Exception) { }
        }

        private void cheackTaxes_CheckedChanged(object sender, EventArgs e)
        {
            if (cheackTaxes.Checked == true)
            {
                NudTax.Value = 5;
            }
            else
            {
                NudTax.Value = 0;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            for(int i=0;i<=DgvStore.Rows.Count -1;i++)
            {
                if(cpxStore.Text == (DgvStore.Rows[i].Cells[0].Value).ToString())
                {
                    MessageBox.Show("المخزن موجود مسبقاً");
                    return;
                }
            }

            if (cpxStore.Items.Count >= 1)
            {
                if (NudBuyPriceStore.Value <= 0 || NudQtyStore.Value <= 0)
                {
                    {
                        MessageBox.Show("رجاءا ادخل الكمية و سعر الشراء");
                        return;
                    }
                }

                DgvStore.Rows.Add(1);

                int indexrow = DgvStore.Rows.Count - 1;

                DgvStore.Rows[indexrow].Cells[0].Value = cpxStore.Text;
                DgvStore.Rows[indexrow].Cells[1].Value = NudQtyStore.Value;
                DgvStore.Rows[indexrow].Cells[2].Value = NudBuyPriceStore.Value;

                // add the qty to the total qty 
                decimal Total = 0;
                for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                {
                    Total += Convert.ToDecimal(DgvStore.Rows[i].Cells[1].Value);
                }

                NudAllQty.Value = Total;

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (DgvStore.Rows.Count >= 1)
            {
                DgvStore.Rows.RemoveAt(DgvStore.CurrentCell.RowIndex);

                // Re_calculate the qty to add it to the total qty 
                decimal Total = 0;
                for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                {
                    Total += Convert.ToDecimal(DgvStore.Rows[i].Cells[1].Value);
                }

                NudAllQty.Value = Total;

            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (cpxUnit.Items.Count >= 1)
            {
                if (NudQtyInMain.Value <= 0 || NudUnitPrice.Value <= 0)
                {
                    {
                        MessageBox.Show("رجاءا ادخل الكمية و سعر الشراء");
                        return;
                    }
                }

                // validation if the cpxmainunit value is equail to cpxunit value do not add !
                if (Convert.ToInt32(cpxUnit.SelectedValue) == Convert.ToInt32(cpxMainUnit.SelectedValue))
                {
                    MessageBox.Show("لايمكن ان تكون الوحدة الصغرى تساوي الوحدة الكبرى");
                    return;
                }

                // validation if the unit was added to the grid so in the second time if the user try to add it show him a message and stop the program ! 
                string unit_name = cpxUnit.Text;

                for (int i = 0; i <= DgvUnit.Rows.Count - 1; i++)
                {
                    if (unit_name == DgvUnit.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("الوحدة موجودة مسبقاً");
                        return;
                    }
                }
                DgvUnit.Rows.Add(1);

                int indexrow = DgvUnit.Rows.Count - 1;

                DgvUnit.Rows[indexrow].Cells[0].Value = cpxUnit.Text;
                DgvUnit.Rows[indexrow].Cells[1].Value = NudQtyInMain.Value;
                DgvUnit.Rows[indexrow].Cells[2].Value = NudUnitPrice.Value;

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (DgvUnit.Rows.Count >= 1)
            {
                DgvUnit.Rows.RemoveAt(DgvUnit.CurrentCell.RowIndex);

            }
        }

        private void NudQtyInMain_ValueChanged(object sender, EventArgs e)
        {
            // divid the unit qty on salepricetax to add it to the buy_price unit !
            try
            {
                NudUnitPrice.Value = Convert.ToDecimal(txtSalePriceTax.Text) / NudQtyInMain.Value;
            }
            catch (Exception) { }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTSEARCH2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (TXTSEARCH2.Text != "")
                {
                    DataTable tblsearch = new DataTable();
                    tblsearch.Clear();

                    tblsearch = db.readData("select * from Products where Barcode=N'" + TXTSEARCH2.Text + "'", "");

                    if (tblsearch.Rows.Count <= 0)
                    {
                        MessageBox.Show("لا توجد منتجات !");
                    }

                    else
                    {
                        try
                        {
                            txtID.Text = tblsearch.Rows[0][0].ToString();
                            txtProName.Text = tblsearch.Rows[0][1].ToString();
                            NudAllQty.Value = Convert.ToDecimal(tblsearch.Rows[0][2]);
                            NudGomlaPrice.Value = Convert.ToDecimal(tblsearch.Rows[0][3]);
                            NudSalePrice.Value = Convert.ToDecimal(tblsearch.Rows[0][4]);
                            NudTax.Value = Convert.ToDecimal(tblsearch.Rows[0][5]);
                            txtSalePriceTax.Text = tblsearch.Rows[0][6].ToString();
                            txtBarcode.Text = tblsearch.Rows[0][7].ToString();
                            NudMiniQty.Value = Convert.ToDecimal(tblsearch.Rows[0][8]);
                            NudMaxDiscount.Value = Convert.ToDecimal(tblsearch.Rows[0][9]);

                            // for the is_tax column !
                            if (tblsearch.Rows[0][10].ToString() == "خاضع للضريبة")
                            {
                                cheackTaxes.Checked = true;
                            }
                            else if (tblsearch.Rows[0][10].ToString() == "غير خاضع للضريبة")
                            {
                                cheackTaxes.Checked = false;
                            }

                            cpxGroup.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][11]);
                            cpxMainUnit.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][13]);
                            cpxUnitSale.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][15]);
                            cpxUnitBuy.SelectedValue = Convert.ToInt32(tblsearch.Rows[0][17]);

                        }
                        catch (Exception) { }


                        try
                        {
                            DataTable tblstore = new DataTable();
                            tblstore.Clear();
                            tblstore = db.readData("select * from Products_Qty where Pro_ID=" + txtID.Text + " ", "");
                            DgvStore.Rows.Clear();
                            if (tblstore.Rows.Count >= 1)
                            {
                                // cuz it not a single coulumn we use for or foreach ! 

                                foreach (DataRow row in tblstore.Rows)
                                {

                                    DgvStore.Rows.Add(1);

                                    int indexrow = DgvStore.Rows.Count - 1;

                                    DgvStore.Rows[indexrow].Cells[0].Value = row[2];
                                    DgvStore.Rows[indexrow].Cells[1].Value = row[3];
                                    DgvStore.Rows[indexrow].Cells[2].Value = row[4];
                                }
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            DataTable tblunit = new DataTable();
                            tblunit.Clear();
                            tblunit = db.readData("select * from Products_Unit where Pro_ID=" + txtID.Text + " ", "");
                            DgvUnit.Rows.Clear();
                            if (tblunit.Rows.Count >= 1)
                            {

                                foreach (DataRow row in tblunit.Rows)
                                {
                                    DgvUnit.Rows.Add(1);

                                    int indexrow = DgvUnit.Rows.Count - 1;

                                    DgvUnit.Rows[indexrow].Cells[0].Value = row[2];
                                    DgvUnit.Rows[indexrow].Cells[1].Value = row[3];
                                    DgvUnit.Rows[indexrow].Cells[2].Value = row[4];
                                }
                            }
                        }
                        catch (Exception) { }

                        btnAdd.Enabled = false;
                        btnNew.Enabled = true;
                        btnDelete.Enabled = true;
                        btnDeleteAll.Enabled = true;
                        btnSave.Enabled = true;
                        btnPrintBarcode.Enabled = true;
                    }

                }
            }
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Pro_Name = txtProName.Text;
                Properties.Settings.Default.Pro_Barcode = txtBarcode.Text;
                Properties.Settings.Default.Pro_Price = Convert.ToDecimal(txtSalePriceTax.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception) { }

            frm_PrintBarcode frm = new frm_PrintBarcode();
            frm.ShowDialog(); 

            // add the barcode if its new or not after closing the form to the txtbarcode  !
            txtBarcode.Text = Properties.Settings.Default.Pro_Barcode;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = checkuser("Item_Group", "User_Settings");
                if (check == true)
                {
                    frm_ProductsGroup frm = new frm_ProductsGroup();
                    frm.ShowDialog();

                    FillGroup();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = checkuser("Unit", "User_Settings");
                if (check == true)
                {
                    frm_Units frm = new Sales_Management.frm_Units();
                    frm.ShowDialog();

                    FillUnit();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Pro_ID) from Products", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }

            else
            {
                row--;
                show();
            }
        }

        private void btnLast_Click_1(object sender, EventArgs e)
        {
            
            tbl.Clear();
            tbl = db.readData("select count (Pro_ID) from Products", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
            {
                row = 0;
                show();
            }
            else
            {
                row++;
                show();
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Pro_ID) from Products", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void btnPre_Click_1(object sender, EventArgs e)
        {
            row = 0;
            show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=FP35klZwgHk&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=4");
        }
    }
}