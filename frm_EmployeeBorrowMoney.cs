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
    public partial class frm_EmployeeBorrowMoney : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX(Order_ID) from Employee_BorrowMoney", "");

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

            }
            catch (Exception) { }
            NudPrice.Value = 1;
            DtpReminder.Text = DateTime.Now.ToShortDateString();

            try
            {
                CpxEmployee.SelectedIndex = 0;
                txtName.Clear();
                txtCreadtor.Clear();
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

        public frm_EmployeeBorrowMoney()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            CpxEmployee.Enabled = false;
        }

        private void frm_EmployeeBorrowMoney_Load(object sender, EventArgs e)
        {
            DtpReminder.Text = DateTime.Now.ToShortDateString();
            DtpDate.Text = DateTime.Now.ToShortDateString();

            try
            {
                FillCpx();
                AutoNumber();
            }
            catch (Exception) { }
            stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
        }

        private void rbtnEmployee_CheckedChanged(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            CpxEmployee.Enabled = true;
        }

        // for users system later on ! we cheacked if the stock have the price entered or not ! 
        string stock_ID = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string date1 = DtpDate.Value.ToString("dd/MM/yyyy");
            string date2 = DtpReminder.Value.ToString("dd/MM/yyyy");

            if (NudPrice.Value <= 0)
            {
                MessageBox.Show("لا يمكن ان يكون المبلغ اصغر من واحد", "تنبيه !");
                return;
            }

            string name = "";

            if (rbtnEmployee.Checked == true)
            {
                if (txtCreadtor.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم الدائن", "تنبيه !");
                    return;
                }

                name = CpxEmployee.Text;
            }

            else if (rbtnNormal.Checked == true) 
            {
                if (txtName.Text == "" || txtCreadtor.Text=="")
                {
                    MessageBox.Show("من فضلك ادخل اسم الشخص و اسم الدائن", "تنبيه !");
                    return;
                }
                name = txtName.Text; 
            }

                 // for users system later on ! we cheacked if the stock have the price entered or not ! 
                tbl.Clear();
               tbl= db.readData("select * from Stock where Stock_ID="+stock_ID+" ", "");

                decimal Stock_Money = 0;

                Stock_Money = Convert.ToDecimal(tbl.Rows[0][1]);

                if (NudPrice.Value > Stock_Money)
                {
                    MessageBox.Show("لا يمكن ان يكون المبلغ اكبر من مبلغ الموجود في الخزنة ", "تنبيه !");
                    return;
                }

                if (rbtnEmployee.Checked == true)
                {
                    db.executedata("insert into Employee_SalaryMoney (Emp_ID,Emp_Name,Date,Price,Pay) values (" + CpxEmployee.SelectedValue + ",N'" + name + "',N'" + date1 + "'," + NudPrice.Value + ",N'No') ", "");
                }

                db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values ("+stock_ID+","+NudPrice.Value+",N'"+date1+"',N'"+txtCreadtor.Text+"',N'سلفيات',N'"+txtNotes.Text+"') ", "");
                db.executedata("update Stock set Money=Money - "+NudPrice.Value+" where Stock_ID="+stock_ID+"  ", "");

                db.executedata("insert into Employee_BorrowMoney values (" + txtID.Text + ",N'" + txtCreadtor.Text + "',N'" + name + "',N'"+date1+"',N'"+date2+"',"+NudPrice.Value+",N'"+txtNotes.Text+"') ", "تمت الاضافة بنجاح !");
            tr.TrackerInsert("شاشة السلف", "تسليف لشخص او موظف",name);
            AutoNumber();
        }


    }
}