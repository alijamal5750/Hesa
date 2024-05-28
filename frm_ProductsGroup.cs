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
    public partial class frm_ProductsGroup : DevExpress.XtraEditors.XtraForm
    {
        tracker tr = new tracker();
        Database db = new Database();
        DataTable tbl = new DataTable();
        DataTable tblGruop = new DataTable();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {

            tblGruop.Clear();
            tblGruop = db.readData("select Group_ID as 'رقم المجموعة',Group_Name as 'اسم المجموعة' from Products_Group", "");
            DgvSearch.DataSource = tblGruop;

            tbl.Clear();
            tbl = db.readData("select MAX(Group_ID) from Products_Group", "");

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
            tbl = db.readData("select * from Products_Group", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لاتوجد بيانات في هذه الشاشة");
            }

            else
            {
                txtID.Text = tbl.Rows[row][0].ToString();
                txtName.Text = tbl.Rows[row][1].ToString();

            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
        }


        public frm_ProductsGroup()
        {
            InitializeComponent();
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
                tbl = db.readData("select count (Group_ID) from Products_Group", "");
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
            tbl = db.readData("select count (Group_ID) from Products_Group", "");
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
            tbl = db.readData("select count (Group_ID) from Products_Group", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void frm_ProductsGroup_Load(object sender, EventArgs e)
        {
            try
            {
                AutoNumber();
            }
            catch (Exception) { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("رجاءا قم بإدخال اسم المجموعة ");
                return;
            }

            db.executedata("insert into Products_Group Values ( " + txtID.Text + ", N'" + txtName.Text + "' )", "تم الادخال بنجاح");
            tr.TrackerInsert("شاشة الاصناف", "اضافة صنف",txtName.Text);
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.readData("update Products_Group set Group_Name = N'" + txtName.Text + "' where Group_ID=" + txtID.Text + " ", "تم التعديل بنجاح");
            tr.TrackerInsert("شاشة الاصناف", "تعديل صنف", txtName.Text);
            AutoNumber();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المجموعة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products_Group where Group_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة الاصناف", "حذف صنف", txtName.Text);
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
            if (MessageBox.Show("هل تريد حذف كل المجموعات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products_Group", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة الاصناف", "حذف كل الاصناف", "");
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void DgvSearch_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                if (DgvSearch.Rows.Count >= 1)
                {
                    DataTable tblshow = new DataTable();
                    tblshow.Clear();
                    tblshow = db.readData("select * from Products_Group where Group_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " ", "");

                    txtID.Text = tblshow.Rows[0][0].ToString();
                    txtName.Text = tblshow.Rows[0][1].ToString();

                    btnAdd.Enabled = false;
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDeleteAll.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void frm_ProductsGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                frm_products.GetForm.FillGroup();

            }
            catch (Exception) { }
        }

        private void frm_ProductsGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                frm_products.GetForm.FillGroup();

            }
            catch (Exception) { }
        
    }
    }
}