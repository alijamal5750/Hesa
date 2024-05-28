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
    public partial class frm_SanadKabd : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        string Stock_ID = "";
        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX (Order_ID) from Sanad_Kabd", "");

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
            txtFrom.Clear();
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
            tbl = db.readData("select * from Sanad_Kabd", "");

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
                    DateTime dt = DateTime.ParseExact(this.Text,"dd/MM/yyyy",null);
                    DtpDate.Value = dt;

                    txtFrom.Text = tbl.Rows[row][4].ToString();
                    txtReason.Text = tbl.Rows[row][5].ToString();

                }
                catch (Exception) { }
            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
           
        }

        public frm_SanadKabd()
        {
            InitializeComponent();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

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
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم العملية',[Name] as 'اسم المسؤول عن القبض',[Price] as 'المبلغ',[Date] as 'تاريخ العملية',[From_] as 'تم القبض من',[Reason] as 'السبب'FROM [Sales_System].[dbo].[Sanad_kabd] where Order_ID= "+id+" ", "");

            frm_Printing frm = new frm_Printing();

            rpt_Sanad_Kabd rpt = new rpt_Sanad_Kabd();

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
            if (txtName.Text == "" || txtFrom.Text == "")
            {
                MessageBox.Show("يرجى ادخال كافة ملعومات القبض", "تنبيه !");
                return;
            }

            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            db.executedata("update Stock set Money=Money + "+NudPrice.Value+" where Stock_ID="+Stock_ID+" ", "");

            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'سند قبض',N'" + txtReason.Text + "') ", "");

            db.executedata("insert into Sanad_kabd values ("+txtID.Text+",N'"+txtName.Text+"',"+NudPrice.Value+",N'"+date+"',N'"+txtFrom.Text+"',N'"+txtReason.Text+"') ", "تمت الاضافة بنجاح !");
            Print();
            tr.TrackerInsert("سند قبض", "اضافة قبض , المسؤول عن القبض",txtName.Text);
            AutoNumber();
        }
        
        
        private void frm_SanadKabd_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);

            try
            {
                AutoNumber();
                Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
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
                tbl = db.readData("select count (Order_ID) from Sanad_Kabd", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                show();
            }
            else {
                row--;
                show();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Order_ID) from Sanad_Kabd", "");
            if(Convert.ToInt32(tbl.Rows[0][0]) -1 == row)
            {
                row = 0;
                show();
            }
            else {
            row ++;
                show();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count (Order_ID) from Sanad_Kabd", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) -1;
            show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف سند القبض المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Sand_Kabd where Order_ID= " + txtID.Text + " ", "تم الحذف بنجاح");
                tr.TrackerInsert("سند قبض", "حذف قبض , المسؤول عن الحذف", txtName.Text);
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
               
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف جميع سندات القبض؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Sand_Kabd ", "تم الحذف بنجاح");
                tr.TrackerInsert("سند قبض", "حذف كل سندات القبض ", "");
                AutoNumber();
                btnAdd.Enabled = true;
                btnNew.Enabled = true;
               
                btnDelete.Enabled = false;
                btnDeleteAll.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}