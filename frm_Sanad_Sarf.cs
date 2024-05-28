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
    public partial class frm_Sanad_Sarf : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        string Stock_ID = "";
        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX (Order_ID) from Sanad_Sarf", "");

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
            txtReason.Clear();
            txtTo.Clear();
            NudPrice.Value = 1;
            DtpDate.Text = DateTime.Now.ToShortDateString();
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
            tbl = db.readData("select * from Sanad_Sarf", "");

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
                    NudPrice.Value = Convert.ToDecimal(tbl.Rows[row][2]);

                    this.Text = tbl.Rows[row][3].ToString();
                    DateTime dt = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);
                    DtpDate.Value = dt;

                    txtTo.Text = tbl.Rows[row][4].ToString();
                    txtReason.Text = tbl.Rows[row][5].ToString();

                }
                catch (Exception) { }
            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;

        }


        public frm_Sanad_Sarf()
        {
            InitializeComponent();
        }

        private void frm_Sanad_Sarf_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);

            try
            {
                AutoNumber();
            }
            catch (Exception) { }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف جميع سندات الصرف؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Sanad_Sarf ", "تم الحذف بنجاح");
                tr.TrackerInsert("سند صرف", "حذف كل سندات الصرف", "");
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;

                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف سند الصرف المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Sanad_Sarf where Order_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                tr.TrackerInsert("سند صرف", "حذف صرف , المسؤول عن الحذف", txtName.Text);
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;

                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
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
                tbl = db.readData("select count (Order_ID) from Sanad_Sarf", "");
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
            tbl = db.readData("select count (Order_ID) from Sanad_Sarf", "");
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
            tbl = db.readData("select count (Order_ID) from Sanad_Sarf", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void Print()
        {
            // the same order id of the order 

            int id = Convert.ToInt32(txtID.Text);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم العملية',[Name] as 'اسم المسؤول عن الصرف',[Price] as 'المبلغ',[Date] as 'تاريخ العملية',[To_] as 'تم الصرف ل',[Reason] as 'السبب'FROM [Sales_System].[dbo].[Sanad_Sarf] where Order_ID= " + id + " ", "");

            frm_Printing frm = new frm_Printing();

            rpt_Sanad_Sarf rpt = new rpt_Sanad_Sarf();

            frm.crystalReportViewer1.RefreshReport();

            // for the server,database,username,password
            rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

            rpt.SetDataSource(tblRpt);

            rpt.SetParameterValue("ID", id);

            frm.crystalReportViewer1.ReportSource = rpt;

            // for the print to printers 
            //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

            //rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

            //rpt.PrintToPrinter(1,true,0,0);

            frm.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtTo.Text == "")
            {
                MessageBox.Show("يرجى ادخال كافة ملعومات القبض", "تنبيه !");
                return;
            }

            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            decimal money = Convert.ToDecimal(db.readData("select * from Stock where Stock_ID= "+Stock_ID+" ","").Rows[0][1]);
            
            if (NudPrice.Value > money)
            {
                MessageBox.Show("لا يمكن ان يكون ملبغ السند اكبر من المبلغ الموجود في الخزنة", "تنبيه !");
                return;
            }

            db.executedata("update Stock set Money=Money - " + NudPrice.Value + " where Stock_ID=" + Stock_ID + " ", "");

            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'سند صرف',N'" + txtReason.Text + "') ", "");

            db.executedata("insert into Sanad_Sarf values (" + txtID.Text + ",N'" + txtName.Text + "'," + NudPrice.Value + ",N'" + date + "',N'" + txtTo.Text + "',N'" + txtReason.Text + "') ", "تمت الاضافة بنجاح !");

            tr.TrackerInsert("سند صرف", "اضافة صرف , المسؤول عن الصرف",txtName.Text);
            Print();
           
            AutoNumber();
        }
    }
}