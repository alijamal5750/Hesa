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
    public partial class frm_EmployeeSalary : DevExpress.XtraEditors.XtraForm
    {
        tracker tr = new tracker();
        Database db = new Database();
        DataTable tbl = new DataTable();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX(Order_ID) from Employee_Salary", "");

            //if customers table are null
            if ((tbl.Rows[0][0].ToString() == DBNull.Value.ToString()))
            {
                txtID.Text = "1";
            }

            //if data available in the table bring them and add 1 to adding information
            else
            {
                txtID.Text = (Convert.ToInt32(tbl.Rows[0][0]) + 1).ToString();
            }


            try
            {
                CpxEmployee.Text = "اختر موظف";
                txtSafySalary.Clear();
                txtTotalBorrow.Clear();
                txtTotalSalary.Clear();
                DtpReminder.Text = DateTime.Now.ToShortDateString();
                DtpDate.Text = DateTime.Now.ToShortDateString();
                txtNotes.Clear();
            }
            catch (Exception) { }

        }

        private void FillCpx()
        {

            CpxEmployee.DataSource = db.readData("select * from Emploies", "");
            CpxEmployee.DisplayMember = "Emp_Name";
            CpxEmployee.ValueMember = "Emp_ID";
        }

        public frm_EmployeeSalary()
        {
            InitializeComponent();
        }

        string Stock_ID = "";
        private void frm_EmployeeSalary_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();
            DtpReminder.Text = DateTime.Now.ToShortDateString();
            
            try
            {
                FillCpx();
                AutoNumber();
            }
            catch (Exception) { }
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
        }

        private void CpxEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select Salary,Date from Emploies where Emp_ID="+CpxEmployee.SelectedValue+" ", "");
                
                txtTotalSalary.Text = Convert.ToDecimal(tbl.Rows[0][0]).ToString();

                this.Text = tbl.Rows[0][1].ToString();
                DateTime dtp = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);
                DtpReminder.Value = dtp;

                // to bring us the borrow items,and borrow money(سلفيات) from the shared table Employee_SalaryMoney !
                try
                {
                    DataTable tblCheck = new DataTable();
                    tblCheck.Clear();
                    tblCheck = db.readData("select * from Employee_SalaryMoney where Emp_ID="+CpxEmployee.SelectedValue+" and Pay=N'No' ", "");

                    decimal TotalBorrow = 0;
                    for (int i = 0; i <= tblCheck.Rows.Count - 1; i++)
                    {
                        TotalBorrow += Convert.ToDecimal(tblCheck.Rows[i][4]);
                    }
                    txtTotalBorrow.Text = (Math.Round(TotalBorrow, 2)).ToString();


                    txtSafySalary.Text = (Convert.ToDecimal(txtTotalSalary.Text) - Convert.ToDecimal(txtTotalBorrow.Text)).ToString();
                }
                catch (Exception) { }
            }
            catch (Exception) { }
        }

        private void PayBorrow()
        {
            DataTable tblprice = new DataTable();
            tblprice.Clear();
            tblprice = db.readData("select Price from Employee_SalaryMoney where Emp_ID="+CpxEmployee.SelectedValue+" ", "");
            decimal totsa = Convert.ToDecimal(txtTotalSalary.Text);

            for (int i = 0; i <= tblprice.Rows.Count - 1; i++)
            { 

            if(totsa > Convert.ToDecimal(tblprice.Rows[i][0]))
            {
                db.executedata("update Employee_SalaryMoney set Pay='Yes' where Emp_ID="+CpxEmployee.SelectedValue+"  and Pay=N'No' and Emp_Name=N'"+CpxEmployee.Text+"' and Price="+tblprice.Rows[i][0]+" ", "");
                totsa = totsa - Convert.ToDecimal(tblprice.Rows[i][0]);
            }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string date1 = DtpDate.Value.ToString("dd/MM/yyyy");
            string date2 = DtpReminder.Value.ToString("dd/MM/yyyy");

            // for users system later on ! we cheacked if the stock have the price entered or not ! 
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + Stock_ID + " ", "");

            decimal Stock_Money = 0;

            Stock_Money = Convert.ToDecimal(tbl.Rows[0][1]);

            if (Convert.ToDecimal( txtSafySalary.Text) > Stock_Money)
            {
                MessageBox.Show("لا يمكن ان يكون مبلغ الصرف اكبر من المبلغ الموجود في الخزنة ", "تنبيه !");
                return;
            }

            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + txtSafySalary.Text + ",N'" + date1 + "',N'"+Properties.Settings.Default.Defualt_USERNAME+"',N'رواتب',N'" + txtNotes.Text + "') ", "");
           
            db.executedata("update Stock set Money=Money - " + txtSafySalary.Text + " where Stock_ID=" + Stock_ID + "  ", "");

            db.executedata("insert into Employee_Salary values (" + txtID.Text + "," + CpxEmployee.SelectedValue + ","+txtTotalSalary.Text+","+txtTotalBorrow.Text+","+txtSafySalary.Text+",N'"+date1+"',N'"+date2+"',N'"+txtNotes.Text+"') ", "تمت عملية الصرف بنجاح !");

            // to delete the items borrow and the borrow money from selected employee after give him the salary money each month from the table salarymoney !
            try
            {
                PayBorrow();
            }
            catch (Exception) { }
            tr.TrackerInsert("شاشة الرواتب", "صرف راتب للموظف",CpxEmployee.Text);
            AutoNumber();    
        }
    }
}