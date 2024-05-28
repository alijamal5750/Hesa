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
    public partial class frm_EmployeeBorrowItemsReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillCpx()
        {
            CpxEmployee.DataSource = db.readData("select * from Emploies", "");
            CpxEmployee.DisplayMember = "Emp_Name";
            CpxEmployee.ValueMember = "Emp_ID";
        }


        public frm_EmployeeBorrowItemsReport()
        {
            InitializeComponent();
        }

        private void frm_EmployeeBorrowItemsReport_Load(object sender, EventArgs e)
        {
            txtTotal.Text = "0";
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
            tbl.Clear();
            DgvSearch.DataSource = tbl;
            try
            {
                FillCpx();
            }
            catch (Exception) { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (rbtnAll.Checked == true)
            {
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',Products.Pro_Name as 'اسم المنتج المسحوب',Emploies.Emp_Name  as 'اسم الساحب',[Employee_BorrowItems].[Date] as 'تاريخ العملية',[Employee_BorrowItems].[Qty] as 'الكمية المسحوبة'FROM [Sales_System].[dbo].[Employee_BorrowItems],[Products],[Emploies] where Employee_BorrowItems.Emp_ID=Products.Pro_ID and Employee_BorrowItems.Emp_ID=Emploies.Emp_ID and Convert(date,Employee_BorrowItems.Date,105) between N'" + date1 + "' and N'" + date2 + "' order by Employee_BorrowItems.Order_ID ", "");
                DgvSearch.DataSource = tbl;

                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice,2).ToString();
            }

            else if (rbtnSingleEmp.Checked == true)
            {
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',Products.Pro_Name as 'اسم المنتج المسحوب',Emploies.Emp_Name  as 'اسم الساحب',[Employee_BorrowItems].[Date] as 'تاريخ العملية',[Employee_BorrowItems].[Qty] as 'الكمية المسحوبة'FROM [Sales_System].[dbo].[Employee_BorrowItems],[Products],[Emploies] where Employee_BorrowItems.Emp_ID=Products.Pro_ID and Employee_BorrowItems.Emp_ID=Emploies.Emp_ID and Convert(date,Employee_BorrowItems.Date,105) between N'" + date1 + "' and N'" + date2 + "' and Employee_BorrowItems.Emp_ID =" + CpxEmployee.SelectedValue + " order by Employee_BorrowItems.Order_ID", "");
                DgvSearch.DataSource = tbl;

                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 2).ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل تريد حذف جميع البيانات للفترة المحددة؟", "تأكيد !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.executedata("delete from Employee_BorrowItems where Convert(date,Employee_BorrowItems.Date,105) between N'" + date1 + "' and N'" + date2 + "'", "تم الحذف بنجاح !");
                    frm_EmployeeBorrowItemsReport_Load(null, null);
                }
            }
        }
    }
}