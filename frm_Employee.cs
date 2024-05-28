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
    public partial class frm_Employee : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX(Emp_ID) from Emploies", "");

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
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;
            txtAdress.Clear();
            DtpDate.Text = DateTime.Now.ToShortDateString();
            txtName.Clear();
            txtNationalID.Clear();
            txtPhone.Clear();
            txtSalary.Clear();
            txtSearch.Clear();
        }


        //function to the arrows
        int row;
        private void show()
        {
            tbl.Clear();
            tbl = db.readData("select * from Emploies", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لاتوجد بيانات في هذه الشاشة");
            }

            else
            {
                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtName.Text = tbl.Rows[row][1].ToString();
                    txtSalary.Text = Convert.ToDecimal(tbl.Rows[row][2]).ToString();

                    this.Text = tbl.Rows[row][3].ToString();
                    DateTime Dtp = DateTime.ParseExact(this.Text, "dd/MM/yyyy",null);
                    DtpDate.Value = Dtp;

                    txtNationalID.Text = tbl.Rows[row][4].ToString();
                    txtPhone.Text = tbl.Rows[row][5].ToString();
                    txtAdress.Text = tbl.Rows[row][6].ToString();
                }
                catch (Exception) { }
            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
        }


        public frm_Employee()
        {
            InitializeComponent();
        }

        private void frm_Employee_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();

            try
            {
                AutoNumber();
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            show();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Emp_ID) from Emploies", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }

            else
            {
                row--;
                show();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Emp_ID) from Emploies", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
            {
                row = 0;
                show();
            }
            else
            {
                row++;
                show();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Emp_ID) from Emploies", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("من فضلك أدخل اسم الموظف", "تنبيه !");
                return;
            }

            if (txtSalary.Text == "")
            {
                MessageBox.Show("من فضلك أدخل راتب الموظف", "تنبيه !");
                return;
            }

            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            db.executedata("insert into Emploies values ("+txtID.Text+",N'"+txtName.Text+"',"+txtSalary.Text+",N'"+date+"',N'"+txtNationalID.Text+"',N'"+txtPhone.Text+"',N'"+txtAdress.Text+"') ", "تمت الاضافة بنجاح !");
            tr.TrackerInsert("شاشة الموظفين", "اضافة موظف",txtName.Text);
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("من فضلك أدخل اسم الموظف", "تنبيه !");
                return;
            }

            if (txtSalary.Text == "")
            {
                MessageBox.Show("من فضلك أدخل راتب الموظف", "تنبيه !");
                return;
            }

            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            db.executedata("update Emploies set Emp_Name= N'" + txtName.Text + "',Salary=" + txtSalary.Text + ",Date=N'" + date + "',National_ID=N'" + txtNationalID.Text + "',Emp_Phone=N'" + txtPhone.Text + "',Emp_Address=N'" + txtAdress.Text + "' where Emp_ID=" + txtID.Text + " ", "تمت التعديل بنجاح !");
            tr.TrackerInsert("شاشة الموظفين", "تعديل موظف", txtName.Text);
            AutoNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف الموظف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Emploies where Emp_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة الموظفين", "حذف موظف", txtName.Text);
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف كل الموظفين؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Emploies ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة الموظفين", "حذف كل الموظفين", "");
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                DataTable tblsearch = new DataTable();
                tblsearch.Clear();

                tblsearch = db.readData("select * from Emploies where Emp_Name + Emp_Phone like '%" + txtSearch.Text + "%'", "");

                if (tblsearch.Rows.Count <= 0)
                {
                    MessageBox.Show("لا توجد منتجات !");
                }

                else
                {
                    try
                    {
                        txtID.Text = tblsearch.Rows[0][0].ToString();
                        txtName.Text = tblsearch.Rows[0][1].ToString();
                        txtSalary.Text = Convert.ToDecimal(tblsearch.Rows[0][2]).ToString();

                        this.Text = tblsearch.Rows[0][3].ToString();
                        DateTime Dtp = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);
                        DtpDate.Value = Dtp;

                        txtNationalID.Text = tblsearch.Rows[0][4].ToString();
                        txtPhone.Text = tblsearch.Rows[0][5].ToString();
                        txtAdress.Text = tblsearch.Rows[0][6].ToString();
                    }
                    catch (Exception) { }
                }

            }
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=8)
            {
                e.Handled = true;
            }
        }
    }
}