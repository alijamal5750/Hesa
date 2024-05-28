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
    public partial class frm_Customer : DevExpress.XtraEditors.XtraForm
    {
        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();
        public frm_Customer()
        {
            InitializeComponent();
        }
        
        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX(Cust_ID) from Customers","");

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
            txtName.Clear();
            txtAdress.Clear();
            txtNotes.Clear();
            txtPhone.Clear();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;
        }

        
        //function to the arrows
        int row;
        private void show()
        {
            tbl.Clear();
            tbl = db.readData("select * from Customers","");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لاتوجد بيانات في هذه الشاشة");
            }

            else
            {
                txtID.Text = tbl.Rows[row][0].ToString();
                txtName.Text = tbl.Rows[row][1].ToString();
                txtAdress.Text = tbl.Rows[row][2].ToString();
                txtPhone.Text = tbl.Rows[row][3].ToString();
                txtNotes.Text = tbl.Rows[row][4].ToString();
            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void frm_Customer_Load(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtPhone.Text=="")
            {
                MessageBox.Show("رجاءا قم بإدخال اسم العميل و رقمه على الاقل");
                return;
            }

            DataTable dup = new DataTable();
            dup.Clear();
            dup = db.readData("select * from Customers where Cust_Name=N'"+txtName.Text+"' ", "");
            if (dup.Rows.Count >=1) { MessageBox.Show("العميل موجود مسبقاً");return; }
                else {
                db.executedata("insert into Customers Values (" + txtID.Text + ", N'" + txtName.Text + "', N'" + txtAdress.Text + "', N'" + txtPhone.Text + "', N'" + txtNotes.Text + "')", "تم الادخال بنجاح");
                tr.TrackerInsert("شاشة العملاء", "اضافة عميل",txtName.Text);
            }

                AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.readData("update Customers set Cust_Name=N'" + txtName.Text + "',Cust_Adress=N'" + txtAdress.Text + "',Cust_Phone=N'" + txtPhone.Text + "',Notes=N'" + txtNotes.Text + "' where Cust_ID=" + txtID.Text + " ", "تم التعديل بنجاح");
            tr.TrackerInsert("شاشة العملاء", "تعديل عميل", txtName.Text);
            AutoNumber();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف العميل؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Customers where Cust_ID= "+txtID.Text+" ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة العملاء", "حذف عميل", txtName.Text);
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
            if (MessageBox.Show("هل تريد حذف كل العملاء؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Customers ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة العملاء", "حذف كل العملاء", "");
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Cust_ID) from Customers","");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Cust_ID) from Customers", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) -1 == row)
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

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Cust_ID) from Customers", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }

            else
            {
                row--;
                show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable tblsearch = new DataTable();
            tblsearch.Clear();
            tblsearch = db.readData("select * from Customers where Cust_Name + Cust_Phone like N'%" + txtSearch.Text + "%'", "");

            try
            {
                txtID.Text = tblsearch.Rows[0][0].ToString();
                txtName.Text = tblsearch.Rows[0][1].ToString();
                txtAdress.Text = tblsearch.Rows[0][2].ToString();
                txtPhone.Text = tblsearch.Rows[0][3].ToString();
                txtNotes.Text = tblsearch.Rows[0][4].ToString();
            }
            catch (Exception) { 
            
            }

            btnAdd.Enabled = false;
            btnNew.Enabled = false;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
        }

        private void frm_Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                frm_Sales.GetForm.FillCustomers();
            }
            catch (Exception) { }
        }
    }
}