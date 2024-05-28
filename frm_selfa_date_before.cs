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
    public partial class frm_selfa_date_before : DevExpress.XtraEditors.XtraForm
    {
        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_selfa_date_before()
        {
            InitializeComponent();
        }

        public void get()
        {
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
            DgvSearch.DataSource = tbl;
        }

        private void frm_selfa_date_before_Load(object sender, EventArgs e)
        {
            try { get(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}