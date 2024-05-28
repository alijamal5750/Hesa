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
    public partial class frm_StockMoneyTransferReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_StockMoneyTransferReport()
        {
            InitializeComponent();
        }

        private void frm_StockMoneyTransferReport_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();

            tbl.Clear();
            DgvSearch.DataSource = tbl;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");
            tbl.Clear();
            tbl = db.readData("SELECT Distinct [Order_ID] as 'رقم العميلة' ,[Money] as 'المبلغ المحول',[Date] as 'التاريخ',(select Stock_Name from Stock_Data where Stock_Data.Stock_ID =From_) as 'تحويل من ',(select Stock_Name from Stock_Data where Stock_Data.Stock_ID = To_) as 'تحويل الى ',[Name] as 'اسم المحول',[Reason] as 'سبب التحويل'FROM [Sales_System].[dbo].[Stock_Transfer],[Stock_Data]  where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "");

            if (tbl.Rows.Count >= 1)
            {
                DgvSearch.DataSource = tbl;

                decimal sum = 0;

                for (int i = 0; i <= tbl.Rows.Count - 1; i++)
                {
                    //the plus value near (=) it is for sum (cell after cell)
                    sum += Convert.ToDecimal(tbl.Rows[i][1]);
                }

                //for the numbers display 2 numbers after dot ....
                txtTotal.Text = Math.Round(sum, 2).ToString();
            }

            //if there are no information to put in the sum function or the information was deleted by user 
            else
            {
                txtTotal.Text = " 0";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (MessageBox.Show("هل تريد حذف كل التحويلات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.executedata("delete from Stock_Transfer where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "تم الحذف بنجاح");
                txtTotal.Text = "0";
                frm_StockMoneyTransferReport_Load(null, null);
            }
        }
    }
}