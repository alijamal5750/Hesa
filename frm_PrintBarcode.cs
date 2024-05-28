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
    public partial class frm_PrintBarcode : DevExpress.XtraEditors.XtraForm
    {  

        Database db=new Database ();
        DataTable tbl=new DataTable ();


        private void FillPro()
        {
            cpxProduct.DataSource = db.readData("select * from Products ", "");
            cpxProduct.DisplayMember = "Pro_Name";
            cpxProduct.ValueMember = "Pro_ID";
        }

        public frm_PrintBarcode()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frm_PrintBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                FillPro();

                txtProName.Text=Properties.Settings.Default.Pro_Name;
                txtBarcode.Text=Properties.Settings.Default.Pro_Barcode;
                txtSalePrice.Text = (Properties.Settings.Default.Pro_Price).ToString();
                
            }
            catch (Exception) { }
        }

        private void btnRanomBarcode_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl.Clear();
            tbl = db.readData("select * from Random_Barcode", "");

            //if (tbl.Rows[0][0].ToString() == DBNull.Value.ToString()) we stop that code cux it shows erros ! 
            
            if(tbl.Rows.Count <=0)
            {
                txtBarcode.Text = "1000000";
                db.executedata("insert into Random_Barcode values (1000000) ", "");
            }
            else 
            {
                // we do the update th update the number of the barcode that exist in the database ! 
                txtBarcode.Text = (Convert.ToInt32(tbl.Rows[0][0]) + 1).ToString();
                db.executedata("update Random_Barcode set Barcode=N'"+ (Convert.ToInt32(tbl.Rows[0][0]) + 1) +"' ", "");
            }
        }

        private void btnSaveBarcode_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl.Clear();
            tbl = db.readData("select * from Random_Barcode", "");

            //if (tbl.Rows[0][0].ToString() == DBNull.Value.ToString()) we stop that code cux it shows erros ! 

            if (tbl.Rows.Count <= 0)
            {
                db.executedata("insert into Random_Barcode values (N'" + txtBarcode.Text + "') ", "تم الحفظ بنجاح!");
            }
            else
            {
                db.executedata("update Random_Barcode set Barcode=N'" + txtBarcode.Text + "' ", "تم الحفظ بنجاح!");
            }
        }

        private void cpxProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cpxProduct.Items.Count >= 1)
            {
                DataTable tbl = new DataTable();
                tbl.Clear();
                tbl = db.readData("select * from Products where Pro_ID="+cpxProduct.SelectedValue+" ", "");

                if (tbl.Rows.Count >= 1)
                {
                    txtProName.Text = tbl.Rows[0][1].ToString();
                    txtBarcode.Text=tbl.Rows[0][7].ToString();
                    txtSalePrice.Text = (tbl.Rows[0][6]).ToString();
                }
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (txtProName.Text == "" || txtBarcode.Text == "" || txtSalePrice.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيانات !");
                return;
            }

            DataSet1 DS = new DataSet1();
            DS.Clear();

            // need to add a validation if there is any space in these columns that will execute errors so we need to add "*" trim to remove the sapce between the words !

            DS.Tables["PrintBarcode"].Rows.Add(txtProName.Text, txtBarcode.Text, txtSalePrice.Text, "*" + txtBarcode.Text.Trim() + "*");

            rpt_CrystalReport rpt = new rpt_CrystalReport();
            frm_Printing frm = new frm_Printing();

            rpt.SetDataSource(DS);
            frm.crystalReportViewer1.ReportSource = rpt;

            frm.crystalReportViewer1.Refresh();
            frm.ShowDialog();

            // if the user type new barcode or not also save it in the properties to have it back after this form is closing , to display it in the txtbarcode in the products form !
            Properties.Settings.Default.Pro_Barcode = txtBarcode.Text;
            Properties.Settings.Default.Save();

            // add the Barcode that we print it !
            db.executedata("update Products set Barcode=N'"+txtBarcode.Text+"' where Pro_Name=N'"+txtProName.Text+"' ", "");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
             if (txtProName.Text == "" || txtBarcode.Text == "" || txtSalePrice.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيانات !");
                return;
            }

            DataSet1 DS = new DataSet1();
            DS.Clear();

             //need to add a validation if there is any space in these columns that will execute errors so we need to add "*" trim to remove the sapce between the words !

            DS.Tables["PrintBarcode"].Rows.Add(txtProName.Text, txtBarcode.Text, txtSalePrice.Text, "*" + txtBarcode.Text.Trim() + "*");

            //// add another way to print by table in the database ! 
            //decimal count = 0;
            
            //try
            //{
            //    count =Convert.ToDecimal (db.readData("select * from Barcode_Print", "").Rows[0][0]);
            //}
            //catch (Exception) { }

            //if (count >= 1)
            //{
            //    db.executedata("update Barcode_Print set Pro_Name=N'" + txtProName.Text + "',Pro_Barcode=N'" + txtBarcode.Text + "',Pro_Price=N'" + txtSalePrice.Text + "',Barcode=N'" + txtBarcode.Text + "' ", "");
            //}
            //else
            //{
            //    db.executedata("insert into Barcode_Print values (N'"+txtProName.Text+"',N'"+txtBarcode.Text+"',N'"+txtSalePrice.Text+"',N'"+txtBarcode.Text+"') ", "");
            //}

            //DataTable tbls = new DataTable();
            //tbls.Clear();
            //tbls = db.readData("select * from Barcode_Print", "");
            // and update the database in the report by verify the database !

            rpt_CrystalReport rpt = new rpt_CrystalReport();
            frm_Printing frm = new frm_Printing();

            rpt.SetDataSource(DS);
            frm.crystalReportViewer1.ReportSource = rpt;

            frm.crystalReportViewer1.Refresh();
            //frm.ShowDialog();

             
            System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

            rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

            rpt.PrintToPrinter(1,true,0,0);

            // if the user type new barcode or not also save it in the properties to have it back after this form is closing , to display it in the txtbarcode in the products form !
            Properties.Settings.Default.Pro_Barcode = txtBarcode.Text;
            Properties.Settings.Default.Save();

            // add the Barcode that we print it !
            db.executedata("update Products set Barcode=N'"+txtBarcode.Text+"' where Pro_Name=N'"+txtProName.Text+"' ", "");
        
        }
    }
}