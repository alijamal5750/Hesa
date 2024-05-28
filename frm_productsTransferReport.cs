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
    public partial class frm_productsTransferReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillStore()
        {
            cpxStoreFrom.DataSource = db.readData("select * from Store", "");
            cpxStoreFrom.DisplayMember = "Store_Name";
            cpxStoreFrom.ValueMember = "Store_ID";

            cpxStoreTo.DataSource = db.readData("select * from Store", "");
            cpxStoreTo.DisplayMember = "Store_Name";
            cpxStoreTo.ValueMember = "Store_ID";
        }
        public frm_productsTransferReport()
        {
            InitializeComponent();
        }

        private void frm_productsTransferReport_Load(object sender, EventArgs e)
        {
            try
            {
                FillStore();

                tbl.Clear();
                DgvSearch.DataSource = tbl;
                txtTotal.Text = "0";

                DtpFrom.Text = DateTime.Now.ToShortDateString();
                DtpTo.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception) { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 

            string d1=DtpFrom.Value.ToString("yyyy-MM-dd");
            string d2=DtpTo.Value.ToString("yyyy-MM-dd");

            tbl.Clear();

           

            // with the date 

             if (rbtnAllStoreFrom.Checked == true)
            {
                if (rbtnAllStoreTo.Checked == true)
                {
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Pro_Name] as 'اسم المنتج',[Store_From] as 'المخزن المحول منه',[Store_To] as 'المخزن المحول له',[Qty] as 'الكمية المحولة',[Unit] as 'الوحدة',[Buy_Price] as 'سعر الشراء',[Sale_Price] as 'سعرالبيع',[Date] as 'التاريخ',[Name] as 'اسم المسؤول',[Reason] as 'الملاحظات'FROM [Sales_System].[dbo].[Products_Transfer] where convert(date,Date,105) between N'"+d1+"' and N'"+d2+"' order by [Order_ID]", "");
                }

                else if (rbtnSingleStoreTo.Checked == true)
                {
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Pro_Name] as 'اسم المنتج',[Store_From] as 'المخزن المحول منه',[Store_To] as 'المخزن المحول له',[Qty] as 'الكمية المحولة',[Unit] as 'الوحدة',[Buy_Price] as 'سعر الشراء',[Sale_Price] as 'سعرالبيع',[Date] as 'التاريخ',[Name] as 'اسم المسؤول',[Reason] as 'الملاحظات'FROM [Sales_System].[dbo].[Products_Transfer] where Store_To=N'" + cpxStoreTo.Text + "' and convert(date,[Date],105) between N'" + d1 + "' and N'" + d2 + "' order by [Order_ID]", "");

                }
            }

            else if (rbtnOneStoreFrom.Checked == true)
            {
                if (rbtnAllStoreTo.Checked == true)
                {
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Pro_Name] as 'اسم المنتج',[Store_From] as 'المخزن المحول منه',[Store_To] as 'المخزن المحول له',[Qty] as 'الكمية المحولة',[Unit] as 'الوحدة',[Buy_Price] as 'سعر الشراء',[Sale_Price] as 'سعرالبيع',[Date] as 'التاريخ',[Name] as 'اسم المسؤول',[Reason] as 'الملاحظات'FROM [Sales_System].[dbo].[Products_Transfer] where Store_From=N'" + cpxStoreFrom.Text + "' and convert(date,[Date],105) between N'" + d1 + "' and N'" + d2 + "' order by [Order_ID]", "");
                }

                else if (rbtnSingleStoreTo.Checked==true)
                {
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Pro_Name] as 'اسم المنتج',[Store_From] as 'المخزن المحول منه',[Store_To] as 'المخزن المحول له',[Qty] as 'الكمية المحولة',[Unit] as 'الوحدة',[Buy_Price] as 'سعر الشراء',[Sale_Price] as 'سعرالبيع',[Date] as 'التاريخ',[Name] as 'اسم المسؤول',[Reason] as 'الملاحظات'FROM [Sales_System].[dbo].[Products_Transfer] where Store_To=N'" + cpxStoreTo.Text + "' and Store_From=N'" + cpxStoreFrom.Text + "' and convert(date,[Date],105) between N'" + d1 + "' and N'" + d2 + "' order by [Order_ID]", "");

                }
            }
          
            DgvSearch.DataSource = tbl;

            if (DgvSearch.Rows.Count >= 1)
            {
                decimal Total = 0;

                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                }

                txtTotal.Text = Math.Round(Total, 3).ToString();
            }

            else if (DgvSearch.Rows.Count <= 0)
            {
                txtTotal.Text = "0";
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string d1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string d2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد العمليات في هذه الفترة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.executedata("delete from Products_Transfer where convert(date,[Date],105) between N'" + d1 + "' and N'" + d2 + "'", "تم المسح بنجاح");
                    frm_productsTransferReport_Load(null,null);
                }
               
            }
        }
    }
}