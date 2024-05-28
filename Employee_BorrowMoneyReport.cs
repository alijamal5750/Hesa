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
    public partial class Employee_BorrowMoneyReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public Employee_BorrowMoneyReport()
        {
            InitializeComponent();
        }

        private void Employee_BorrowMoneyReport_Load(object sender, EventArgs e)
        {
            try {
                txtTotal.Text = "0";
                DtpFrom.Text = DateTime.Now.ToShortDateString();
                DtpTo.Text = DateTime.Now.ToShortDateString();
                tbl.Clear();
                DgvSearch.DataSource = tbl;
            }
            catch (Exception) { }
            }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

                if (rbtnAll.Checked == true)
                {
                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العميلة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم المديون',[Order_Date] as 'تاريخ السلف',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'مبلغ السلف',[Notes] as 'الملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Order_Date,105) between N'" + date1 + "' and N'" + date2 + "' order by Order_ID ", "");
                    DgvSearch.DataSource = tbl;

                    decimal TotalPrice = 0;
                    for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                    {
                        TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value);
                    }
                    txtTotal.Text = Math.Round(TotalPrice, 2).ToString();
                }

                else if (rbtnSingleEmp.Checked == true)
                {

                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العميلة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم المديون',[Order_Date] as 'تاريخ السلف',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'مبلغ السلف',[Notes] as 'الملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Order_Date,105) between N'" + date1 + "' and N'" + date2 + "' and [Borrow_To] like  N'%" + txtname.Text + "%' order by Order_ID ", "");
                    DgvSearch.DataSource = tbl;

                    decimal TotalPrice = 0;
                    for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                    {
                        TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value);
                    }
                    txtTotal.Text = Math.Round(TotalPrice, 2).ToString();
                }
            }
            catch (Exception) { }
            }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

                if (DgvSearch.Rows.Count >= 1)
                {
                    if (MessageBox.Show("هل تريد حذف جميع البيانات للفترة المحددة؟", "تأكيد !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        db.executedata("delete from Employee_BorrowMoney where Convert(date,Order_Date,105) between N'" + date1 + "' and N'" + date2 + "'", "تم الحذف بنجاح !");
                        Employee_BorrowMoneyReport_Load(null, null);
                    }
                }
            }
            catch (Exception) { }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnSingleEmp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}