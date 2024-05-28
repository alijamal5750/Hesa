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
    public partial class frm_Employee_SalaryMoneyReport : DevExpress.XtraEditors.XtraForm
    {


        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillCpx()
        {
            CpxEmployee.DataSource = db.readData("select * from Emploies", "");
            CpxEmployee.DisplayMember = "Emp_Name";
            CpxEmployee.ValueMember = "Emp_ID";
        }


        public frm_Employee_SalaryMoneyReport()
        {
            InitializeComponent();
        }

        private void frm_Employee_SalaryMoneyReport_Load(object sender, EventArgs e)
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
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',Emploies.Emp_Name  as 'اسم الموظف',[Total_Salary] as 'مبلغ الراتب الشهري',[Total_Borrow] as 'اجمالي المسحوبات و السلفيات' ,[Safy_Salary] as 'صافي الراتب',[Order_Date] as 'تاريخ الصرف',[Date_Reminder] as 'تاريخ الاستحقاق' ,[Notes] as 'الملاحظات' FROM [Sales_System].[dbo].[Employee_Salary],[Emploies] where Employee_Salary.Emp_ID=Emploies.Emp_ID and Convert(date,[Order_Date],105) between N'" + date1 + "' and N'" + date2 + "' order by Employee_Salary.Order_ID ", "");
                DgvSearch.DataSource = tbl;

                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 2).ToString();
            }

            else if (rbtnSingleEmp.Checked == true)
            {
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',Emploies.Emp_Name  as 'اسم الموظف',[Total_Salary] as 'مبلغ الراتب الشهري',[Total_Borrow] as 'اجمالي المسحوبات و السلفيات' ,[Safy_Salary] as 'صافي الراتب',[Order_Date] as 'تاريخ الصرف',[Date_Reminder] as 'تاريخ الاستحقاق' ,[Notes] as 'الملاحظات' FROM [Sales_System].[dbo].[Employee_Salary],[Emploies] where Employee_Salary.Emp_ID=Emploies.Emp_ID and Emploies.Emp_ID=" + CpxEmployee.SelectedValue + " and Convert(date,[Order_Date],105) between N'" + date1 + "' and N'" + date2 + "' and Employee_Salary.Emp_ID =" + CpxEmployee.SelectedValue + " order by Employee_Salary.Order_ID", "");
                DgvSearch.DataSource = tbl;

                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 2).ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل تريد حذف جميع البيانات للفترة المحددة؟", "تأكيد !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.executedata("delete from Employee_Salary where Convert(date,[Order_Date],105) between N'" + date1 + "' and N'" + date2 + "'", "تم الحذف بنجاح !");
                    frm_Employee_SalaryMoneyReport_Load(null, null);
                }
            }
        }
    }
}