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
    public partial class frm_usertree : DevExpress.XtraEditors.XtraForm
    {
        DataTable tbl = new DataTable();
        Database db = new Database();
        public frm_usertree()
        {
            InitializeComponent();
        }

        public void getusers()
        {
            cpxusers.DataSource = db.readData("select * from Users","");
            cpxusers.DisplayMember = "USer_Name";
            cpxusers.ValueMember = "User_ID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void frm_usertree_Load(object sender, EventArgs e)
        {
            getusers();
        }

        public void search()
        {
            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            string unit="" , permission="" ,category="",stores="",products="",customers="",suppliers="",storetransfer="",stock="",stockinsert="",stockpull="",deservetype="",deserved="",sanadkabd="",sanadsarf="",employies="",employiespull="",selfa="",salary="",buy="",sales="",returns="",backup="",restore="",customermoney="",suppliermoney="";

            if(checkunit.Checked==true)
            {
                unit = "شاشة الوحدات";
            }
            else if(checkunit.Checked==false)
                {
                unit = "";
            }
            ///////////////////////////////////////////////////////////////////////////
            if (checkpermission.Checked == true) { permission = "شاشة الصلاحيات"; }
            else if (checkpermission.Checked == false) { permission = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkcategory.Checked == true) { category = "شاشة الاصناف"; }
            else if (checkcategory.Checked == false) { category = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkstore.Checked == true) { stores = "شاشة المخازن"; }
            else if (checkstore.Checked == false) { stores = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkproducts.Checked == true) { products = "شاشة المنتجات"; }
            else if (checkproducts.Checked == false) { products = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkcustomers.Checked == true) { customers = "شاشة العملاء"; }
            else if (checkcustomers.Checked == false) { customers = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checksuppliers.Checked == true) { suppliers = "شاشة الموردين"; }
            else if (checksuppliers.Checked == false) { suppliers = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkstoretransfer.Checked == true) { storetransfer = "شاشة تحويل المنتجات بين المخازن"; }
            else if (checkstoretransfer.Checked == false) { storetransfer = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkstock.Checked == true) { stock = "شاشة الخزنات"; }
            else if (checkstock.Checked == false) { stock = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkstockinsert.Checked == true) { stockinsert = "شاشة ايداع الخزنات"; }
            else if (checkstockinsert.Checked == false) { stockinsert = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkstockpull.Checked == true) { stockpull = "شاشة سحوبات الخزنات"; }
            else if (checkstockpull.Checked == false) { stockpull = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkdeservedtype.Checked == true) { deservetype = "شاشة نوع المصروفات"; }
            else if (checkdeservedtype.Checked == false) { deservetype = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkdeserved.Checked == true) { deserved = "شاشة المصروفات"; }
            else if (checkdeserved.Checked == false) { deserved = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checksanadkabd.Checked == true) { sanadkabd = "سند قبض"; }
            else if (checksanadkabd.Checked == false) { sanadkabd = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checksanadsarf.Checked == true) { sanadsarf = "سند صرف"; }
            else if (checksanadsarf.Checked == false) { sanadsarf = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkemployies.Checked == true) { employies = "شاشة الموظفين"; }
            else if (checkemployies.Checked == false) { employies = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkemployiespull.Checked == true) { employiespull = "سحوبات الموظفين"; }
            else if (checkemployiespull.Checked == false) { employiespull = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkselfa.Checked == true) { selfa = "شاشة السلف"; }
            else if (checkselfa.Checked == false) { selfa = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checksalary.Checked == true) { salary = "شاشة الرواتب"; }
            else if (checksalary.Checked == false) { salary = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkbuy.Checked == true) { buy = "شاشة المشتريات"; }
            else if (checkbuy.Checked == false) { buy = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checksales.Checked == true) { sales = "شاشة المبيعات"; }
            else if (checksales.Checked == false) { sales = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkreturns.Checked == true) { returns = "شاشة المرتجعات"; }
            else if (checkreturns.Checked == false) { returns= ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkbackup.Checked == true) { backup = "نسخ احتياطي"; }
            else if (checkbackup.Checked == false) { backup = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkrestore.Checked == true) { restore = "استرجاع نسخ احتياطي"; }
            else if (checkrestore.Checked == false) { restore = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checkcustomermoney.Checked == true) { customermoney = "تسديد العملاء"; }
            else if (checkcustomermoney.Checked == false) { customermoney = ""; }
            ///////////////////////////////////////////////////////////////////////////
            if (checksuppliermoney.Checked == true) { suppliermoney = "تسديد الموردين"; }
            else if (checksuppliermoney.Checked == false) { suppliermoney = ""; }

            if (rbtnAll.Checked==true)
            {
                tbl = db.readData("SELECT [Frm] as 'اسم الشاشة',[Notes] as 'نوع النشاط',[Ord] as 'اسم او رقم النشاط',[Date_Added] as 'التاريخ',[Ti] as 'الوقت',[USer_Name] as 'اسم المستخدم'FROM [Sales_System].[dbo].[Tra],[Users] where Users.User_ID=Tra.User_ID and Convert(date,[Date_Added],105) between N'"+date1+"' and N'"+date2+ "' and [Frm] in (N'"+unit+ "',N'"+permission+ "',N'"+category+ "',N'"+stores+ "',N'"+products+ "',N'"+customers+ "',N'"+suppliers+ "',N'"+storetransfer+ "',N'"+stock+ "',N'"+stockinsert+ "',N'"+stockpull+ "',N'"+deservetype+ "',N'"+deserved+ "',N'"+sanadkabd+ "',N'"+sanadsarf+ "',N'"+employies+ "',N'"+employiespull+ "',N'"+selfa+ "',N'"+salary+ "',N'"+buy+ "',N'"+sales+ "',N'"+returns+ "',N'"+backup+ "',N'"+restore+ "',N'"+customermoney+ "',N'"+suppliermoney+"') ", "");
                DgvSearch.DataSource = tbl;
            }

            else if(rbtnSingle.Checked==true)
            {
                tbl = db.readData("SELECT [Frm] as 'اسم الشاشة',[Notes] as 'نوع النشاط',[Ord] as 'اسم او رقم النشاط',[Date_Added] as 'التاريخ',[Ti] as 'الوقت',[USer_Name] as 'اسم المستخدم'FROM [Sales_System].[dbo].[Tra],[Users] where Users.User_ID=Tra.User_ID and Convert(date,[Date_Added],105) between N'" + date1 + "' and N'" + date2 + "' and [Tra].[User_ID]=" + cpxusers.SelectedValue+" and[Frm] in (N'" + unit + "',N'" + permission + "',N'" + category + "',N'" + stores + "',N'" + products + "',N'" + customers + "',N'" + suppliers + "',N'" + storetransfer + "',N'" + stock + "',N'" + stockinsert + "',N'" + stockpull + "',N'" + deservetype + "',N'" + deserved + "',N'" + sanadkabd + "',N'" + sanadsarf + "',N'" + employies + "',N'" + employiespull + "',N'" + selfa + "',N'" + salary + "',N'" + buy + "',N'" + sales + "',N'" + returns + "',N'" + backup + "',N'" + restore + "',N'" + customermoney + "',N'" + suppliermoney + "') ", "");
                DgvSearch.DataSource = tbl;
            }

            txttotal.Text = DgvSearch.Rows.Count +"";

            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            checkunit.Checked = true;
            checkpermission.Checked = true;
            checkcategory.Checked = true;
            checkstore.Checked = true;
            checkcustomers.Checked = true;
            checkcustomermoney.Checked = true;
            checksuppliers.Checked = true;
            checksuppliermoney.Checked = true;
            checkstock.Checked = true;
            checkstockinsert.Checked = true;
            checkstockpull.Checked = true;
            checkdeservedtype.Checked = true;
            checkdeserved.Checked = true;
            checksanadkabd.Checked = true;
            checksanadsarf.Checked = true;
            checkemployies.Checked = true;
            checkselfa.Checked = true;
            checksalary.Checked = true;
            checkbuy.Checked = true;
            checksales.Checked = true;
            checkreturns.Checked = true;
            checkproducts.Checked = true;
            checkbackup.Checked = true;
            checkrestore.Checked = true;
            checkstoretransfer.Checked = true;
            checkemployiespull.Checked = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            checkunit.Checked = false;
            checkpermission.Checked = false;
            checkcategory.Checked = false;
            checkstore.Checked = false;
            checkcustomers.Checked = false;
            checkcustomermoney.Checked = false;
            checksuppliers.Checked = false;
            checksuppliermoney.Checked = false;
            checkstock.Checked = false;
            checkstockinsert.Checked = false;
            checkstockpull.Checked = false;
            checkdeservedtype.Checked = false;
            checkdeserved.Checked = false;
            checksanadkabd.Checked = false;
            checksanadsarf.Checked = false;
            checkemployies.Checked = false;
            checkselfa.Checked = false;
            checksalary.Checked = false;
            checkbuy.Checked = false;
            checksales.Checked = false;
            checkreturns.Checked = false;
            checkproducts.Checked = false;
            checkbackup.Checked = false;
            checkrestore.Checked = false;
            checkstoretransfer.Checked = false;
            checkemployiespull.Checked = false;
        }
    }
}