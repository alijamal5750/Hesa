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
    public partial class frm_EmploiesBorrowItems : DevExpress.XtraEditors.XtraForm
    {


        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        //to binge us the max customer id from the database when form is start
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select MAX(Order_ID) from Employee_BorrowItems", "");

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
            txtBarcode.Clear();
            NudQty.Value = 1;
            DtpDate.Text = DateTime.Now.ToShortDateString();

            try
            {
                CpxItems.SelectedIndex = 0;
                CpxEmployee.SelectedIndex = 0;
            }
            catch (Exception) { }
            
        }

        private void FillCpx()
        {
            CpxItems.DataSource = db.readData("select * from Products", "");
            CpxItems.DisplayMember = "Pro_Name";
            CpxItems.ValueMember = "Pro_ID";

            CpxEmployee.DataSource = db.readData("select * from Emploies", "");
            CpxEmployee.DisplayMember = "Emp_Name";
            CpxEmployee.ValueMember = "Emp_ID";
        }

        public frm_EmploiesBorrowItems()
        {
            InitializeComponent();
        }

        private void frm_EmploiesBorrowItems_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();

            try
            {
                AutoNumber();
                FillCpx();
            }
            catch (Exception) { }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                if (txtBarcode.Text == "") { MessageBox.Show("من فضلك ادخل رقم الباركود", "تنبيه !"); return; }

                DataTable tblSearch = new DataTable();
                tblSearch.Clear();
                tblSearch = db.readData("select * from Products where  Barcode=N'"+txtBarcode.Text+"' ", "");

                if (tblSearch.Rows.Count >= 1)
                {
                    CpxItems.SelectedValue =Convert.ToInt32 (tblSearch.Rows[0][0]);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NudQty.Value <= 0)
            {
                MessageBox.Show("لا يمكن ان تكون الكمية المسحوبة اصغر من واحد", "تنبيه !");
                return;
            }

            string date = DtpDate.Value.ToString("dd/MM/yyyy");
            decimal Price_ = 0;
            decimal TotalPrice = 0;
            try
            {
                Price_ =Convert.ToDecimal( db.readData("select Sale_Price from Products where Pro_ID="+CpxItems.SelectedValue+" ", "").Rows[0][0]);
            }
            catch (Exception) { }

            TotalPrice = Price_ * NudQty.Value;

            db.executedata("insert into Employee_SalaryMoney (Emp_ID,Emp_Name,Date,Price,Pay) values ("+CpxEmployee.SelectedValue+",N'"+CpxEmployee.Text+"',N'"+date+"',"+TotalPrice+",N'No') ", "");

            db.executedata("update Products set Qty=Qty - "+NudQty.Value+" where Pro_ID="+CpxItems.SelectedValue+" ", "");

            db.executedata("insert into Employee_BorrowItems values("+txtID.Text+","+CpxItems.SelectedValue+","+CpxEmployee.SelectedValue+",N'"+date+"',"+NudQty.Value+")", "تمت الاضافة بنجاح !");
            tr.TrackerInsert("سحوبات الموظفين", "سحب منتج للموظف",CpxEmployee.Text);
            AutoNumber();
        }
    }
}