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
    public partial class frm_notif : DevExpress.XtraEditors.XtraForm
    {
        public frm_notif()
        {
            InitializeComponent();
        }

        // for the buy_sale_order_dates Agel orders : 
        public void Get_Dates_Sales()
        {
            try
            {
                Database db = new Database();
                DataTable today = new DataTable();
                DataTable before = new DataTable();
                DataTable after = new DataTable();
                today.Clear();
                before.Clear();
                after.Clear();

                DataTable todaybuy = new DataTable();
                DataTable beforebuy = new DataTable();
                DataTable afterbuy = new DataTable();
                todaybuy.Clear();
                beforebuy.Clear();
                afterbuy.Clear();

                DataTable selfatoday = new DataTable();
                DataTable selfabefore = new DataTable();
                DataTable selfaafter = new DataTable();
                selfatoday.Clear();
                selfabefore.Clear();
                selfaafter.Clear();

                today = db.readData("select * from Customer_Money where Convert(date,Reminder_Date,105) = N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lbltoday.Text = today.Rows.Count + "";


                before = db.readData("select * from Customer_Money where Convert(date,Reminder_Date,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblbefore.Text = before.Rows.Count + "";


                after = db.readData("select * from Customer_Money where Convert(date,Reminder_Date,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblafter.Text = after.Rows.Count + "";

                //--------------------------------------------------------------------------------------------------------------------------------------------------

                todaybuy = db.readData("select * from Supplier_Money where Convert(date,Reminder_Date,105) = N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lbltodaybuy.Text = todaybuy.Rows.Count + "";

                beforebuy = db.readData("select * from Supplier_Money where Convert(date,Reminder_Date,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblbeforebuy.Text = beforebuy.Rows.Count + "";

                afterbuy = db.readData("select * from Supplier_Money where Convert(date,Reminder_Date,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblafterbuy.Text = afterbuy.Rows.Count + "";

                //--------------------------------------------------------------------------------------------------------------------------------------------------

                selfatoday = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) = N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblselfatoday.Text = selfatoday.Rows.Count + "";

                selfabefore = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblselfabefore.Text = selfabefore.Rows.Count + "";

                selfaafter = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
                lblselfaafter.Text = selfaafter.Rows.Count + "";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try { Get_Dates_Sales(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frm_notif_Load(object sender, EventArgs e)
        {
            try
            {
                Get_Dates_Sales();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_sale_date_today frm = new frm_sale_date_today();
            frm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_sale_date_before frm = new frm_sale_date_before();
            frm.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm_sale_date_after frm = new frm_sale_date_after();
            frm.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frm_buy_date_now frm = new frm_buy_date_now();
            frm.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frm_buy_date_before frm = new frm_buy_date_before();
            frm.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frm_buy_date_after frm = new frm_buy_date_after();
            frm.ShowDialog();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            frm_selfa_date_today frm = new frm_selfa_date_today();
            frm.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frm_selfa_date_before frm = new frm_selfa_date_before();
            frm.ShowDialog();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            frm_selfa_date_after frm = new frm_selfa_date_after();
            frm.ShowDialog();
        }
    }
}