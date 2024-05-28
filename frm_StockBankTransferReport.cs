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
    public partial class frm_StockBankTransferReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_StockBankTransferReport()
        {
            InitializeComponent();
        }

        private void frm_StockBankTransferReport_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();

            tbl.Clear();
            DgvSearch.DataSource = tbl;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbtnAll.Checked == true)
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                date2 = DtpTo.Value.ToString("yyyy-MM-dd");
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Money] as 'المبلغ المحول' ,[Date] as 'التاريخ',[From_] as 'تحويل من',[To_] as 'الى',[Name] as 'اسم المحول'FROM [Sales_System].[dbo].[StockBank_Transfer]  where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "");

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

            else if (rbtnFromStockToBank.Checked == true)
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                date2 = DtpTo.Value.ToString("yyyy-MM-dd");
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Money] as 'المبلغ المحول' ,[Date] as 'التاريخ',[From_] as 'تحويل من',[To_] as 'الى',[Name] as 'اسم المحول'FROM [Sales_System].[dbo].[StockBank_Transfer] where To_=N'تحويل الى بنك' and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "");

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

            else if (rbtnFromBankToStock.Checked == true)
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                date2 = DtpTo.Value.ToString("yyyy-MM-dd");
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Money] as 'المبلغ المحول' ,[Date] as 'التاريخ',[From_] as 'تحويل من',[To_] as 'الى',[Name] as 'اسم المحول'FROM [Sales_System].[dbo].[StockBank_Transfer] where From_ =N'من البنك' and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "");

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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (MessageBox.Show("هل تريد حذف كل التحويلات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.executedata("delete from StockBank_Transfer where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "تم الحذف بنجاح");
                txtTotal.Text = "0";
                frm_StockBankTransferReport_Load(null, null);
            }
        }
    }
}