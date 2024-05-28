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
    public partial class frm_BankAddedMoneyReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_BankAddedMoneyReport()
        {
            InitializeComponent();
        }

        private void frm_BankAddedMoneyReport_Load(object sender, EventArgs e)
        {
            try
            {
                DtpFrom.Text = DateTime.Now.ToShortDateString();
                DtpTo.Text = DateTime.Now.ToShortDateString();

                tbl.Clear();
                DgvSearch.DataSource = tbl;
            }
            catch (Exception)
            { }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                date2 = DtpTo.Value.ToString("yyyy-MM-dd");
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Money] as 'المبلغ المودع',[Date] as 'التاريخ',[Name] as 'اسم الشخص' ,[Type] as 'نوع الايداع',[Reason] as 'سبب الايداع'FROM [Sales_System].[dbo].[Bank_Insert] where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "");

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
            }catch(Exception) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                date2 = DtpTo.Value.ToString("yyyy-MM-dd");

                if (MessageBox.Show("هل تريد حذف كل الايداعات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.executedata("delete from Bank_Insert where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "تم الحذف بنجاح");
                    txtTotal.Text = "0";
                    frm_BankAddedMoneyReport_Load(null, null);
                }
            }
            catch (Exception) { }
        }
    }
}