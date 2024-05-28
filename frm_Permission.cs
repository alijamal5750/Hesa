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
    public partial class frm_Permission : DevExpress.XtraEditors.XtraForm
    {
        tracker tr = new tracker();
        Database db = new Database();
        DataTable tbl = new DataTable();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            // another datatable for select the Users and Show them in the datagridview !
            DataTable tblgrid = new DataTable();
            tblgrid.Clear();
            tblgrid = db.readData("SELECT [User_ID]as 'معرف المستخدم',[USer_Name] as 'اسم المستخدم',[Type] as 'نوع المستخدم',Stock_Name as 'خزنة المستخدم',[Rb7h] as 'نسبة الربح من الخزنة'FROM [Sales_System].[dbo].[Users],[Stock_Data] where users.Stock_ID=Stock_Data.Stock_ID", "");
            DgvStore.DataSource = tblgrid;

            tbl.Clear();
            tbl = db.readData("select max(User_ID) from Users", "");

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
                FillUsers();
                txtUserName.Clear();
                txtPassword.Clear();
                NudRb7h.Value = 1;
                cpxStock.SelectedIndex = 0;
                cpxUser.SelectedIndex = 0;
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
            catch (Exception) { }
        }


        //function to the arrows
        int row;
        private void show()
        {

            tbl.Clear();
            tbl = db.readData("select * from Users", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لاتوجد بيانات في هذه الشاشة");
                return;
            }

            else
            {
                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtUserName.Text = tbl.Rows[row][1].ToString();
                    txtPassword.Text = tbl.Rows[row][2].ToString();
                    cpxUser.Text = tbl.Rows[row][3].ToString();
                    cpxStock.SelectedValue = tbl.Rows[row][4].ToString();
                    NudRb7h.Value = Convert.ToDecimal(tbl.Rows[row][5]);
                }
                catch (Exception) { }
            }


            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;

        }


        private void FillStock()
        {
            cpxStock.DataSource = db.readData("select * from Stock_Data", "");
            cpxStock.DisplayMember = "Stock_Name";
            cpxStock.ValueMember = "Stock_ID";

        }

        private void FillUsers()
        {
            cpxUser1.DataSource = db.readData("select * from Users", "");
            cpxUser1.DisplayMember = "User_Name";
            cpxUser1.ValueMember = "User_ID";

            cpxUser2.DataSource = db.readData("select * from Users", "");
            cpxUser2.DisplayMember = "User_Name";
            cpxUser2.ValueMember = "User_ID";

            cpxUser3.DataSource = db.readData("select * from Users", "");
            cpxUser3.DisplayMember = "User_Name";
            cpxUser3.ValueMember = "User_ID";

            cpxUser4.DataSource = db.readData("select * from Users", "");
            cpxUser4.DisplayMember = "User_Name";
            cpxUser4.ValueMember = "User_ID";

            cpxUser5.DataSource = db.readData("select * from Users", "");
            cpxUser5.DisplayMember = "User_Name";
            cpxUser5.ValueMember = "User_ID";

            cpxUser6.DataSource = db.readData("select * from Users", "");
            cpxUser6.DisplayMember = "User_Name";
            cpxUser6.ValueMember = "User_ID";

            cpxUser8.DataSource = db.readData("select * from Users", "");
            cpxUser8.DisplayMember = "User_Name";
            cpxUser8.ValueMember = "User_ID";

            cpxUser7.DataSource = db.readData("select * from Users", "");
            cpxUser7.DisplayMember = "User_Name";
            cpxUser7.ValueMember = "User_ID";

            cpxUser9.DataSource = db.readData("select * from Users", "");
            cpxUser9.DisplayMember = "User_Name";
            cpxUser9.ValueMember = "User_ID";

            cpxUser10.DataSource = db.readData("select * from Users", "");
            cpxUser10.DisplayMember = "User_Name";
            cpxUser10.ValueMember = "User_ID";

            cpxUser11.DataSource = db.readData("select * from Users", "");
            cpxUser11.DisplayMember = "User_Name";
            cpxUser11.ValueMember = "User_ID";
        }

        public frm_Permission()
        {
            InitializeComponent();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void frm_Permission_Load(object sender, EventArgs e)
        {
            try
            {
                FillStock();
                AutoNumber();
                //DgvStore.Columns[2].Visible = false;
                cpxUser1_SelectionChangeCommitted(null,null);
                cpxUser2_SelectionChangeCommitted(null, null);
                cpxUser3_SelectionChangeCommitted(null, null);
                cpxUser4_SelectionChangeCommitted(null, null);
                cpxUser5_SelectionChangeCommitted(null, null);
                cpxUser6_SelectionChangeCommitted(null, null);
                cpxUser7_SelectionChangeCommitted(null, null);
                cpxUser8_SelectionChangeCommitted(null, null);
                cpxUser9_SelectionChangeCommitted(null, null);
                cpxUser10_SelectionChangeCommitted(null, null);
                cpxUser11_SelectionChangeCommitted(null, null);
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            show();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count(User_ID) from Users", "");
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
            tbl = db.readData("select count(User_ID) from Users", "");
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
            tbl = db.readData("select count(User_ID) from Users", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("رجاءاً قم بادخال الاسم و كلمة السر", "تنبيه !");
                return;
            }

            db.executedata("insert into Users values (" + txtID.Text + ",N'" + txtUserName.Text + "',N'" + Hash_Password.hashPassword(txtPassword.Text.Trim()) + "',N'" + cpxUser.Text + "'," + cpxStock.SelectedValue + "," + NudRb7h.Value + ") ", "تمت الاضافة بنجاح !");
            db.executedata("insert into User_Settings values (" + txtID.Text + ",0,0,0,0,0,0,0) ", "");
            db.executedata("insert into User_Customer values (" + txtID.Text + ",0,0,0) ", "");
            db.executedata("insert into User_Supplier values (" + txtID.Text + ",0,0,0) ", "");
            db.executedata("insert into User_Buy values (" + txtID.Text + ",0,0) ", "");
            db.executedata("insert into User_Sale values (" + txtID.Text + ",0,0,0) ", "");
            db.executedata("insert into User_Return values (" + txtID.Text + ",0,0) ", "");
            db.executedata("insert into User_StockBank values (" + txtID.Text + ",0,0,0,0,0,0,0,0,0) ", "");
            db.executedata("insert into User_Emploeey values (" + txtID.Text + ",0,0,0,0,0,0,0) ", "");
            db.executedata("insert into User_Deserved values (" + txtID.Text + ",0,0,0,0,0,0) ", "");
            db.executedata("insert into User_report values (" + txtID.Text + ",0,0,0,0,0,0) ", "");
            db.executedata("insert into User_Backup values (" + txtID.Text + ",0,0) ", "");
            tr.TrackerInsert("شاشة الصلاحيات", "اضافة مستخدم",txtUserName.Text);
            AutoNumber();
        }

        private void DgvStore_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable tb = new DataTable();
            tb.Clear();
            tb = db.readData("select * from Users where User_ID= " + DgvStore.CurrentRow.Cells[0].Value + " ", "");
            try
            {
                txtID.Text = tb.Rows[0][0].ToString();
                txtUserName.Text = tb.Rows[0][1].ToString();
                cpxUser.Text = tb.Rows[0][3].ToString();
                cpxStock.SelectedValue = Convert.ToInt32(tb.Rows[0][4]);
                NudRb7h.Value = Convert.ToDecimal(tb.Rows[0][5]);

                btnAdd.Enabled = false;
                btnNew.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            }
            catch (Exception) { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                db.executedata("update Users set User_Name=N'" + txtUserName.Text + "',User_Password=N'" + Hash_Password.hashPassword(txtPassword.Text.Trim()) + "',Type=N'" + cpxUser.Text + "',Stock_ID=" + cpxStock.SelectedValue + ",Rb7h=" + NudRb7h.Value + " where User_ID=" + txtID.Text + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل مستخدم مع كلمة السر", txtUserName.Text);
            }

            if(txtPassword.Text == "")
            {
                db.executedata("update Users set User_Name=N'" + txtUserName.Text + "',Type=N'" + cpxUser.Text + "',Stock_ID=" + cpxStock.SelectedValue + ",Rb7h=" + NudRb7h.Value + " where User_ID=" + txtID.Text + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل مستخدم بدون تغيير كلمة السر", txtUserName.Text);
            }
            AutoNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المستخدم؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                db.readData("delete from Users where User_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                AutoNumber();

                // add d defualt user after the all users has been deleted ! 
                DataTable tbluser = new DataTable();
                tbluser.Clear();
                tbluser = db.readData("select * from Users", "");

                if (tbluser.Rows.Count <= 0)
                {
                    // we cannot add N'مدير' to the query cuz of arabic language ! so we create a variable for that issue ! 
                    string type = "مدير";
                    db.executedata("insert into Users values (1,N'1234',N'cRDtpNCeBiql5KOQsKVyrA0sAiA=',N'" + type + "', 1,0) ", "تم اضافة مستخدم افتراضي 1234 !");
                    db.executedata("insert into User_Settings values (1,1,1,1,1,1,1,1) ", "");
                    db.executedata("insert into User_Customer values (1,1,1,1) ", "");
                    db.executedata("insert into User_Supplier values (1,1,1,1) ", "");
                    db.executedata("insert into User_Buy values (1,1,1) ", "");
                    db.executedata("insert into User_Sale values (1,1,1,1) ", "");
                    db.executedata("insert into User_Return values (1,1,1) ", "");
                    db.executedata("insert into User_StockBank values (1,1,1,1,1,1,1,1,1,1) ", "");
                    db.executedata("insert into User_Emploeey values (1,1,1,1,1,1,1,1) ", "");
                    db.executedata("insert into User_Deserved values (1,1,1,1,1,1,1) ", "");
                    db.executedata("insert into User_report values (1,1,1,1,1,1,1) ", "");
                    db.executedata("insert into User_Backup values (1,1,1) ", "");
                    MessageBox.Show("تم اضافة المستخدم الافتراضي يرجى غلق البرنامج ثم اعادة تشغيله","");
                    tr.TrackerInsert("شاشة الصلاحيات", "حذف مستخدم", txtUserName.Text);
                }
                AutoNumber();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        DataTable tblSearch = new DataTable();
        private void cpxUser1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Settings where User_ID=" + cpxUser1.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkUnit.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkUnit.Checked = false;
                    }

                    // ---------------------------------

                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkPermission.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkPermission.Checked = false;
                    }

                    // ---------------------------------

                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkShowItems.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkShowItems.Checked = false;
                    }

                    // ---------------------------------

                    if (Convert.ToInt32(tblSearch.Rows[0][4]) == 1)
                    {
                        checkSetting.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][4]) == 0)
                    {
                        checkSetting.Checked = false;
                    }

                    // ---------------------------------

                    if (Convert.ToInt32(tblSearch.Rows[0][5]) == 1)
                    {
                        checkAddItems.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][5]) == 0)
                    {
                        checkAddItems.Checked = false;
                    }

                    // ---------------------------------

                    if (Convert.ToInt32(tblSearch.Rows[0][6]) == 1)
                    {
                        checkGroup.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][6]) == 0)
                    {
                        checkGroup.Checked = false;
                    }

                    // ---------------------------------

                    if (Convert.ToInt32(tblSearch.Rows[0][7]) == 1)
                    {
                        checkAddStore.Checked = true;
                    }
                    else if (Convert.ToInt32(tblSearch.Rows[0][7]) == 0)
                    {
                        checkAddStore.Checked = false;
                    }
                }
            }
            catch (Exception) { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // update the check boxes ! 

                int unit = 0, setting = 0, userpermission = 0, itemsview = 0, additems = 0, itemsgroups = 0, addstore = 0;

                if (checkUnit.Checked == true)
                {
                    unit = 1;
                }

                else if (checkUnit.Checked == false)
                {
                    unit = 0;
                }

                //-----------------------------------
                if (checkSetting.Checked == true)
                {
                    setting = 1;
                }

                else if (checkSetting.Checked == false)
                {
                    setting = 0;
                }

                //-----------------------------------
                if (checkPermission.Checked == true)
                {
                    userpermission = 1;
                }

                else if (checkPermission.Checked == false)
                {
                    userpermission = 0;
                }

                //-----------------------------------
                if (checkShowItems.Checked == true)
                {
                    itemsview = 1;
                }

                else if (checkShowItems.Checked == false)
                {
                    itemsview = 0;
                }

                //-----------------------------------
                if (checkAddItems.Checked == true)
                {
                    additems = 1;
                }

                else if (checkAddItems.Checked == false)
                {
                    additems = 0;
                }

                //-----------------------------------
                if (checkGroup.Checked == true)
                {
                    itemsgroups = 1;
                }

                else if (checkGroup.Checked == false)
                {
                    itemsgroups = 0;
                }

                //-----------------------------------
                if (checkAddStore.Checked == true)
                {
                    addstore = 1;
                }

                else if (checkAddStore.Checked == false)
                {
                    addstore = 0;
                }

                db.executedata("update User_Settings set Unit=" + unit + ",User_Permission=" + userpermission + ",Item_View=" + itemsview + ",Setting=" + setting + ",Items_Add=" + additems + ",Item_Group=" + itemsgroups + ",Store_Add=" + addstore + " where User_ID=" + cpxUser1.SelectedValue + "  ", "تم التعديل بنجاح!");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم الاعدادات", cpxUser1.Text);
                cpxUser1.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void cpxUser2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Customer where User_ID=" + cpxUser2.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkCustomer.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkCustomer.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkCustomerMoney.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkCustomerMoney.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkCustomerReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkCustomerReport.Checked = false;
                    }
                }
            }
            catch (Exception) { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int customer = 0, customermoney = 0, customerreport = 0;

                if (checkCustomer.Checked == true)
                {
                    customer = 1;
                }
                else if (checkCustomer.Checked == false)
                {
                    customer = 0;
                }

                //------------------------------
                if (checkCustomerMoney.Checked == true)
                {
                    customermoney = 1;
                }
                else if (checkCustomerMoney.Checked == false)
                {
                    customermoney = 0;
                }

                //---------------------------
                if (checkCustomerReport.Checked == true)
                {
                    customerreport = 1;
                }
                else if (checkCustomerReport.Checked == false)
                {
                    customerreport = 0;
                }

                db.executedata("update User_Customer set Customer=" + customer + ",CustomerMoney=" + customermoney + ",CustomerReport=" + customerreport + " where User_ID=" + cpxUser2.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم العملاء", cpxUser2.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Supplier where User_ID=" + cpxUser3.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkSupplier.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkSupplier.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkSupplierMoney.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkSupplierMoney.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkSupplierReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkSupplierReport.Checked = false;
                    }
                }
            }
            catch (Exception) { }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int supplier = 0, supplierrmoney = 0, supplierreport = 0;

                if (checkSupplier.Checked == true)
                {
                    supplier = 1;
                }
                else if (checkSupplier.Checked == false)
                {
                    supplier = 0;
                }

                //------------------------------
                if (checkSupplierMoney.Checked == true)
                {
                    supplierrmoney = 1;
                }
                else if (checkSupplierMoney.Checked == false)
                {
                    supplierrmoney = 0;
                }

                //---------------------------
                if (checkSupplierReport.Checked == true)
                {
                    supplierreport = 1;
                }
                else if (checkSupplierReport.Checked == false)
                {
                    supplierreport = 0;
                }

                db.executedata("update User_Supplier set Supp_Data=" + supplier + ",Sup_Money=" + supplierrmoney + ",Supp_Report=" + supplierreport + " where User_ID=" + cpxUser3.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم الموردين", cpxUser3.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Buy where User_ID=" + cpxUser4.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkBuy.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkBuy.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkBuyReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkBuyReport.Checked = false;
                    }

                }
            }
            catch (Exception) { }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                int Buy = 0, BuyReport = 0;

                if (checkBuy.Checked == true)
                {
                    Buy = 1;
                }
                else if (checkBuy.Checked == false)
                {
                    Buy = 0;
                }

                //------------------------------
                if (checkBuyReport.Checked == true)
                {
                    BuyReport = 1;
                }
                else if (checkBuyReport.Checked == false)
                {
                    BuyReport = 0;
                }


                db.executedata("update User_Buy set Buy=" + Buy + ",Buy_Report=" + BuyReport + " where User_ID=" + cpxUser4.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم المشتريات", cpxUser4.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Sale where User_ID=" + cpxUser5.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkSales.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkSales.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkSalesReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkSalesReport.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkSalesRb7h.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkSalesRb7h.Checked = false;
                    }

                }
            }
            catch (Exception) { }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                int Sale = 0, SaleReport = 0, SaleRb7h = 0;

                if (checkSales.Checked == true)
                {
                    Sale = 1;
                }
                else if (checkSales.Checked == false)
                {
                    Sale = 0;
                }

                //------------------------------
                if (checkSalesReport.Checked == true)
                {
                    SaleReport = 1;
                }
                else if (checkSalesReport.Checked == false)
                {
                    SaleReport = 0;
                }

                //------------------------------
                if (checkSalesRb7h.Checked == true)
                {
                    SaleRb7h = 1;
                }
                else if (checkSalesRb7h.Checked == false)
                {
                    SaleRb7h = 0;
                }

                db.executedata("update User_Sale set Sale=" + Sale + ",SaleReport=" + SaleReport + ",SaleRb7h=" + SaleRb7h + "  where User_ID=" + cpxUser5.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم المبيعات", cpxUser5.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Return where User_ID=" + cpxUser6.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkRetrun.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkRetrun.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkReturnReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkReturnReport.Checked = false;
                    }

                }
            }
            catch (Exception) { }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int Return_ = 0, ReturnReport = 0;

                if (checkRetrun.Checked == true)
                {
                    Return_ = 1;
                }
                else if (checkRetrun.Checked == false)
                {
                    Return_ = 0;
                }

                //------------------------------
                if (checkReturnReport.Checked == true)
                {
                    ReturnReport = 1;
                }
                else if (checkReturnReport.Checked == false)
                {
                    ReturnReport = 0;
                }

                db.executedata("update User_Return set Return_=" + Return_ + ",Return_Report=" + ReturnReport + "  where User_ID=" + cpxUser6.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم المرتجعات", cpxUser6.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser7_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_StockBank where User_ID=" + cpxUser7.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkAddStock.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkAddStock.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkStockInsert.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkStockInsert.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkBankInsert.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkBankInsert.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][4]) == 1)
                    {
                        checkStockPull.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][4]) == 0)
                    {
                        checkStockPull.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][5]) == 1)
                    {
                        checkBankPull.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][5]) == 0)
                    {
                        checkBankPull.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][6]) == 1)
                    {
                        checkTransferMoney.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][6]) == 0)
                    {
                        checkTransferMoney.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][7]) == 1)
                    {
                        checkTRansferStockBank.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][7]) == 0)
                    {
                        checkTRansferStockBank.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][8]) == 1)
                    {
                        checkCurrentMoney.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][8]) == 0)
                    {
                        checkCurrentMoney.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][9]) == 1)
                    {
                        checkStockBankReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][9]) == 0)
                    {
                        checkStockBankReport.Checked = false;
                    }

                }
            }
            catch (Exception) { }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                int addstock = 0, stockinsert = 0, bankinsert = 0, stockpull = 0, bankpull = 0, transfermoney = 0, transferstockbankmoney = 0, currentmoney = 0, stockbankreport = 0;

                if (checkAddStock.Checked == true)
                {
                    addstock = 1;
                }
                else if (checkAddStock.Checked == false)
                {
                    addstock = 0;
                }

                //------------------------------
                if (checkStockInsert.Checked == true)
                {
                    stockinsert = 1;
                }
                else if (checkStockInsert.Checked == false)
                {
                    stockinsert = 0;
                }

                //------------------------------
                if (checkBankInsert.Checked == true)
                {
                    bankinsert = 1;
                }
                else if (checkBankInsert.Checked == false)
                {
                    bankinsert = 0;
                }

                //------------------------------
                if (checkStockPull.Checked == true)
                {
                    stockpull = 1;
                }
                else if (checkStockPull.Checked == false)
                {
                    stockpull = 0;
                }

                //------------------------------
                if (checkBankPull.Checked == true)
                {
                    bankpull = 1;
                }
                else if (checkBankPull.Checked == false)
                {
                    bankpull = 0;
                }

                //------------------------------
                if (checkTransferMoney.Checked == true)
                {
                    transfermoney = 1;
                }
                else if (checkTransferMoney.Checked == false)
                {
                    transfermoney = 0;
                }

                //------------------------------
                if (checkTRansferStockBank.Checked == true)
                {
                    transferstockbankmoney = 1;
                }
                else if (checkTRansferStockBank.Checked == false)
                {
                    transferstockbankmoney = 0;
                }

                //------------------------------
                if (checkCurrentMoney.Checked == true)
                {
                    currentmoney = 1;
                }
                else if (checkCurrentMoney.Checked == false)
                {
                    currentmoney = 0;
                }

                //------------------------------
                if (checkStockBankReport.Checked == true)
                {
                    stockbankreport = 1;
                }
                else if (checkStockBankReport.Checked == false)
                {
                    stockbankreport = 0;
                }


                db.executedata("update User_StockBank set Add_Stock=" + addstock + ",Stock_Insert=" + stockinsert + ",Bank_Insert=" + bankinsert + ",Stock_Pull=" + stockpull + ",Bank_Pull=" + bankpull + ",TRansfer_Stock=" + transfermoney + ",Transfer_BankStock=" + transferstockbankmoney + ",Current_Money=" + currentmoney + ",Stock_BankReport=" + stockbankreport + "  where User_ID=" + cpxUser7.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم الخزنة", cpxUser7.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser8_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Emploeey where User_ID=" + cpxUser8.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkAddEmployee.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkAddEmployee.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkEmplooeypull.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkEmplooeypull.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkGiveMoney.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkGiveMoney.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][4]) == 1)
                    {
                        checkEmploeyymoney.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][4]) == 0)
                    {
                        checkEmploeyymoney.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][5]) == 1)
                    {
                        checkEmploeyyMoneyReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][5]) == 0)
                    {
                        checkEmploeyyMoneyReport.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][6]) == 1)
                    {
                        checkEmploeeypullReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][6]) == 0)
                    {
                        checkEmploeeypullReport.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][7]) == 1)
                    {
                        checkGiveMoneyReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][7]) == 0)
                    {
                        checkGiveMoneyReport.Checked = false;
                    }


                }
            }
            catch (Exception) { }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                int addemp = 0, pull = 0, give = 0, money = 0, moneyreport = 0, pullreport = 0, givereport = 0;

                if (checkAddEmployee.Checked == true)
                {
                    addemp = 1;
                }
                else if (checkAddEmployee.Checked == false)
                {
                    addemp = 0;
                }

                //------------------------------
                if (checkEmplooeypull.Checked == true)
                {
                    pull = 1;
                }
                else if (checkEmplooeypull.Checked == false)
                {
                    pull = 0;
                }

                //------------------------------
                if (checkGiveMoney.Checked == true)
                {
                    give = 1;
                }
                else if (checkGiveMoney.Checked == false)
                {
                    give = 0;
                }

                //------------------------------
                if (checkEmploeyymoney.Checked == true)
                {
                    money = 1;
                }
                else if (checkEmploeyymoney.Checked == false)
                {
                    money = 0;
                }

                //------------------------------
                if (checkEmploeyyMoneyReport.Checked == true)
                {
                    moneyreport = 1;
                }
                else if (checkEmploeyyMoneyReport.Checked == false)
                {
                    moneyreport = 0;
                }

                //------------------------------
                if (checkEmploeeypullReport.Checked == true)
                {
                    pullreport = 1;
                }
                else if (checkEmploeeypullReport.Checked == false)
                {
                    pullreport = 0;
                }

                //------------------------------
                if (checkGiveMoneyReport.Checked == true)
                {
                    givereport = 1;
                }
                else if (checkGiveMoneyReport.Checked == false)
                {
                    givereport = 0;
                }

                db.executedata("update User_Emploeey set Add_Emploeey=" + addemp + ",Pull_Money=" + pull + ",Give_Money=" + give + ",Emploeyey_Money=" + money + ",Emploeey_MoneyReport=" + moneyreport + ",Emploeey_PullReport=" + pullreport + ",Emploeey_GiveReport=" + givereport + "  where User_ID=" + cpxUser8.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم شؤون الموظفين", cpxUser8.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser9_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Deserved where User_ID=" + cpxUser9.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkType.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkType.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkDes.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkDes.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkDesReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkDesReport.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][4]) == 1)
                    {
                        checkSanadKabd.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][4]) == 0)
                    {
                        checkSanadKabd.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][5]) == 1)
                    {
                        checkSanadSarf.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][5]) == 0)
                    {
                        checkSanadSarf.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][6]) == 1)
                    {
                        checkKabdSarfReport.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][6]) == 0)
                    {
                        checkKabdSarfReport.Checked = false;
                    }


                }
            }
            catch (Exception) { }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                int type = 0, des = 0, desreport = 0, sanadkabd = 0, sanadsarf = 0, kabdsarfreport = 0;

                if (checkType.Checked == true)
                {
                    type = 1;
                }
                else if (checkType.Checked == false)
                {
                    type = 0;
                }

                //------------------------------
                if (checkDes.Checked == true)
                {
                    des = 1;
                }
                else if (checkDes.Checked == false)
                {
                    des = 0;
                }

                //------------------------------
                if (checkDesReport.Checked == true)
                {
                    desreport = 1;
                }
                else if (checkDesReport.Checked == false)
                {
                    desreport = 0;
                }

                //------------------------------
                if (checkSanadKabd.Checked == true)
                {
                    sanadkabd = 1;
                }
                else if (checkSanadKabd.Checked == false)
                {
                    sanadkabd = 0;
                }

                //------------------------------
                if (checkSanadSarf.Checked == true)
                {
                    sanadsarf = 1;
                }
                else if (checkSanadSarf.Checked == false)
                {
                    sanadsarf = 0;
                }

                //------------------------------
                if (checkKabdSarfReport.Checked== true)
                {
                    kabdsarfreport = 1;
                }
                else if (checkKabdSarfReport.Checked == false)
                {
                    kabdsarfreport = 0;
                }


                db.executedata("update User_Deserved set Type=" + type + ",Des=" + des + ",Des_Report=" + desreport + ",Sanad_Kabd=" + sanadkabd + ",Sanad_Sarf=" + sanadsarf + ",Kabd_SarfReport=" + kabdsarfreport + "  where User_ID=" + cpxUser9.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم مصروفات و ضرائب", cpxUser9.Text);
            }
            catch (Exception) { }
        }

        private void cpxUser10_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_report where User_ID=" + cpxUser10.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkCust.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkCust.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkSupp.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkSupp.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][3]) == 1)
                    {
                        checkBuys.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][3]) == 0)
                    {
                        checkBuys.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][4]) == 1)
                    {
                        checkSale.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][4]) == 0)
                    {
                        checkSale.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][5]) == 1)
                    {
                        checkretur.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][5]) == 0)
                    {
                        checkretur.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][6]) == 1)
                    {
                        checkDeserved.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][6]) == 0)
                    {
                        checkDeserved.Checked = false;
                    }


                }
            }
            catch (Exception) { }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                int cust = 0, supp = 0, buy = 0, sale = 0, re = 0, des = 0;

                if (checkCust.Checked == true)
                {
                    cust = 1;
                }
                else if (checkCust.Checked == false)
                {
                    cust = 0;
                }

                //------------------------------
                if (checkSupp.Checked== true)
                {
                    supp = 1;
                }
                else if (checkSupp.Checked == false)
                {
                    supp = 0;
                }

                //------------------------------
                if (checkBuys.Checked == true)
                {
                    buy = 1;
                }
                else if (checkBuys.Checked == false)
                {
                    buy = 0;
                }

                //------------------------------
                if (checkSale.Checked == true)
                {
                    sale = 1;
                }
                else if (checkSale.Checked == false)
                {
                    sale = 0;
                }

                //------------------------------
                if (checkretur.Checked == true)
                {
                    re = 1;
                }
                else if (checkretur.Checked == false)
                {
                    re = 0;
                }

                //------------------------------
                if (checkDeserved.Checked == true)
                {
                    des = 1;
                }
                else if (checkDeserved.Checked == false)
                {
                    des = 0;
                }


                db.executedata("update User_report set cust=" + cust + ",supp=" + supp + ",buy=" + buy + ",sale=" + sale + ",return_=" + re + ",Des=" + des + "  where User_ID=" + cpxUser10.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم التقارير", cpxUser10.Text);
            }
            catch (Exception) { }
        }


  private void cpxUser11_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tblSearch.Clear();
                tblSearch = db.readData("select * from User_Backup where User_ID=" + cpxUser11.SelectedValue + " ", "");
                if (tblSearch.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(tblSearch.Rows[0][1]) == 1)
                    {
                        checkcre.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][1]) == 0)
                    {
                        checkcre.Checked = false;
                    }

                    //--------------------------------------
                    if (Convert.ToInt32(tblSearch.Rows[0][2]) == 1)
                    {
                        checkre.Checked = true;
                    }

                    else if (Convert.ToInt32(tblSearch.Rows[0][2]) == 0)
                    {
                        checkre.Checked = false;
                    }

                }
            }
            catch (Exception) { }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            try
            {
                int cre = 0, re = 0;

                if (checkcre.Checked == true)
                {
                    cre = 1;
                }
                else if (checkcre.Checked == false)
                {
                    cre = 0;
                }

                //------------------------------
                if (checkre.Checked == true)
                {
                    re = 1;
                }
                else if (checkre.Checked == false)
                {
                    re = 0;
                }

                //------------------------------

                db.executedata("update User_Backup set cre=" + cre + ",re=" + re + " where User_ID=" + cpxUser11.SelectedValue + " ", "تم التعديل بنجاح !");
                tr.TrackerInsert("شاشة الصلاحيات", "تعديل صلاحيات مستخدم قسم النسخ الاحتياطية", cpxUser11.Text);
            }
            catch (Exception) { }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=HW1L1I6Sctw&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=3");
        }
    }
}