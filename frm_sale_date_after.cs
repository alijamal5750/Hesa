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
    public partial class frm_sale_date_after : DevExpress.XtraEditors.XtraForm
    {


        Database db = new Database();
        DataTable tbl = new DataTable();


        public frm_sale_date_after()
        {
            InitializeComponent();
        }


        public void get()
        {
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',[Cust-Name] as 'اسم العميل',[Price] as 'مبلغ الفاتورة',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Customer_Money] where Convert(date,Reminder_Date,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
            DgvSearch.DataSource = tbl;
        }

        private void frm_sale_date_after_Load(object sender, EventArgs e)
        {
            try { get(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}