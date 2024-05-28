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
    public partial class frm_buy_date_before : DevExpress.XtraEditors.XtraForm
    {
        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_buy_date_before()
        {
            InitializeComponent();
        }

        public void get()
        {
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',[sup_name] as 'اسم المورد',[Price] as 'مبلغ الفاتورة',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Supplier_Money],[Suppliers] where Supplier_Money.Sup_ID= Suppliers.Sup_ID  and Convert(date,Reminder_Date,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
            DgvSearch.DataSource = tbl;
        }

        private void frm_buy_date_before_Load(object sender, EventArgs e)
        {
            try { get(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}