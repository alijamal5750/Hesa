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
    public partial class frm_Deserve : DevExpress.XtraEditors.XtraForm
    {
        public frm_Deserve()
        {
            InitializeComponent();
        }

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX(Des_ID) from Deserved", "");

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
            DtpDate.Text = DateTime.Now.ToShortDateString();
            NudPrice.Value = 1;
            txtNote.Clear();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
          
        }


        //function to the arrows
        int row;
        private void show()
        {
            tbl.Clear();
            tbl = db.readData("select * from Deserved", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لاتوجد بيانات في هذه الشاشة");
            }

            else
            {
                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    NudPrice.Value = Convert.ToDecimal(tbl.Rows[row][1]);

                    //for the datetime 
                    this.Text = tbl.Rows[row][2].ToString();
                    DateTime dt = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);
                    DtpDate.Value = dt;

                    txtNote.Text = tbl.Rows[row][3].ToString();
                    cbxType.SelectedValue = Convert.ToDecimal(tbl.Rows[row][4].ToString());

                } catch (Exception){}
            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
           
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count (Des_ID) from Deserved", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }

            else
            {
                row--;
                show();
            }
        }

        //function to fill the deserved_type into combobox 
        private void FillType()
        {
         cbxType.DataSource=db.readData("select * from Deserved_Type ","");
         cbxType.DisplayMember = "Name";
         cbxType.ValueMember = "Des_ID";
        }

        private void frm_Deserve_Load(object sender, EventArgs e)
        {
            AutoNumber();
            FillType();
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Des_ID) from Deserved", "");
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
            tbl = db.readData("select count (Des_ID) from Deserved", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        string Stock_ID = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {

            // for users system later on ! we cheacked if the stock have the price entered or not ! 
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + Stock_ID + " ", "");

            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            decimal Stock_Money = 0;

            Stock_Money = Convert.ToDecimal(tbl.Rows[0][1]);

            if (Convert.ToDecimal(NudPrice.Value) > Stock_Money)
            {
                MessageBox.Show("لا يمكن ان يكون مبلغ الصرف اكبر من المبلغ الموجود في الخزنة ", "تنبيه !");
                return;
            }

            

            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudPrice.Value + ",N'" + d + "',N'"+Properties.Settings.Default.Defualt_USERNAME+"',N'مصروفات',N'" + txtNote.Text + "') ", "");

            db.executedata("update Stock set Money=Money - " + NudPrice.Value + " where Stock_ID=" + Stock_ID + "  ", "");

            
            db.executedata("insert into Deserved Values ("+txtID.Text+", "+NudPrice.Value+",N'"+d+"',N'"+txtNote.Text+"',"+cbxType.SelectedValue+"  )", "تم الادخال بنجاح");
            tr.TrackerInsert("شاشة المصروفات", "اضافة مصروفة",cbxType.Text);
            AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
            FillType();
            NudPrice.Value = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");
            db.readData("update Deserved set Price=" +NudPrice.Value + ",Date=N'" +d+ "',Notes=N'" +txtNote.Text + "',Type_ID=" +cbxType.SelectedValue+ " where Des_ID= "+txtID.Text+" ", "تم التعديل بنجاح");
            tr.TrackerInsert("شاشة المصروفات", "تعديل مصروفة", cbxType.Text);
            AutoNumber();
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
           
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المصروفة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Deserved where Des_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة المصروفات", "حذف مصروفة", cbxType.Text);
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
               
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف كل المصروفات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Deserved ", "تم الحذف بنجاح");
                tr.TrackerInsert("شاشة المصروفات", "حذف كل المصروفات", "");
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
               
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}