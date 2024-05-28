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
    public partial class frm_AddStock : DevExpress.XtraEditors.XtraForm
    {
        tracker tr = new tracker();
        Database db = new Database();
        DataTable tbl = new DataTable();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            try {
                tbl.Clear();
                tbl = db.readData("select MAX(Stock_ID) from Stock_Data", "");

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
            catch (Exception) { }
        }


        //function to the arrows
        int row;
        private void show()
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select * from Stock_Data", "");

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
            catch (Exception) { }
        }

        public frm_AddStock()
        {
            InitializeComponent();
        }

        private void frm_AddStock_Load(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try {
                if (txtName.Text == "")
                {
                    MessageBox.Show("رجاءا قم بإدخال اسم الخزنة ");
                    return;
                }

                db.executedata("insert into Stock_Data Values ( " + txtID.Text + ", N'" + txtName.Text + "' )", "تم الادخال بنجاح");
                db.executedata("insert into Stock Values ("+txtID.Text+",0)", "");
                tr.TrackerInsert("شاشة الخزنات", "اضافة خزنة",txtName.Text);
                AutoNumber();
            }
            catch (Exception) { }
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.readData("update Stock_Data set Stock_Name= N'" + txtName.Text + "' where Stock_ID=" + txtID.Text + " ", "تم التعديل بنجاح");
                tr.TrackerInsert("شاشة الخزنات", "تعديل خزنة", txtName.Text);
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
            catch (Exception)
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف الخزنة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.readData("delete from Stock_Data where Stock_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                    tr.TrackerInsert("شاشة الخزنات", "حذف خزنة", txtName.Text);
                    AutoNumber();
                    btnAdd.Enabled = true;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDeleteAll.Enabled = false;
                }
            }catch(Exception) { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف كل الخزنات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.readData("delete from Stock_Data", "تم الحذف بنجاح");
                    tr.TrackerInsert("شاشة الخزنات", "حذف كل الخزنات", "");
                    AutoNumber();
                    btnAdd.Enabled = true;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDeleteAll.Enabled = false;
                }
            }catch(Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                row = 0;
                show();
            }catch(Exception) { }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                if (row == 0)
                {
                    tbl.Clear();
                    tbl = db.readData("select count (Stock_ID) from Stock_Data", "");
                    row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                    show();
                }

                else
                {
                    row--;
                    show();
                }
            }catch(Exception) { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select count (Stock_ID) from Stock_Data", "");
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
            catch (Exception) { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select count (Stock_ID) from Stock_Data", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }catch(Exception) { }
        }
    }
}