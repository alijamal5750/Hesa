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
    public partial class frm_ProductsTalifReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillStore()
        {
            cpxStoreFrom.DataSource = db.readData("select * from Store", "");
            cpxStoreFrom.DisplayMember = "Store_Name";
            cpxStoreFrom.ValueMember = "Store_ID";
        }
        public frm_ProductsTalifReport()
        {
            InitializeComponent();
        }

        private void frm_ProductsTalifReport_Load(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                DgvSearch.DataSource = tbl;
                txtTotal.Text = "0";
                FillStore();
                DtpFrom.Text = DateTime.Now.ToShortDateString();
                DtpTo.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception) { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string d1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string d2 = DtpTo.Value.ToString("yyyy-MM-dd");

            tbl.Clear();

            if (rbtnAllStoreFrom.Checked == true)
            {
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Pro_Name] as 'اسم المنتج',[Store_Name] as 'اسم المخزن المخرج منه',[Qty] as 'الكمية',[Unit] as 'الوحدة',[Date] as 'التاريخ',[Name] as 'اسم المسؤول عن الاخراج',[Reason] as 'ملاحظات'FROM [Sales_System].[dbo].[Products_OutStore] where convert(date,Date,105) between N'"+d1+"' and N'"+d2+"' order by Order_ID", "");
                DgvSearch.DataSource = tbl;
            }

            else if (rbtnOneStoreFrom.Checked == true)
            {
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Pro_Name] as 'اسم المنتج',[Store_Name] as 'اسم المخزن المخرج منه',[Qty] as 'الكمية',[Unit] as 'الوحدة',[Date] as 'التاريخ',[Name] as 'اسم المسؤول عن الاخراج',[Reason] as 'ملاحظات'FROM [Sales_System].[dbo].[Products_OutStore] where Store_Name=N'"+cpxStoreFrom.Text+"' and convert(date,Date,105) between N'" + d1 + "' and N'" + d2 + "' order by Order_ID", "");
                DgvSearch.DataSource = tbl;
            }

            if (DgvSearch.Rows.Count >= 1)
            {
                decimal total = 0;

                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[3].Value);
                }
                txtTotal.Text = Math.Round(total,2).ToString();
            }

            else if (DgvSearch.Rows.Count <= 0) { txtTotal.Text = "0"; }
        }
    }
}