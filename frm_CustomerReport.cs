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
    public partial class frm_CustomerReport : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillCustomers()
        {
            cpxCustomers.DataSource = db.readData("select * from Customers", "");
            cpxCustomers.DisplayMember = "Cust_Name";
            cpxCustomers.ValueMember = "Cust_ID";
        }

        public frm_CustomerReport()
        {
            InitializeComponent();
        }

        private void frm_CustomerReport_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                FillCustomers();
            }

            catch (Exception) { }

            //to fill the supplier_money table into datagridview
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',[Price] as 'السعر' ,[Date] as 'التاريخ',[Cust_Name] as 'اسم العميل'FROM [Sales_System].[dbo].[Customer_Report]", "");
            DgvSearch.DataSource = tbl;

            rbtnAllCust.Checked = true;
            //for total textbox
            decimal TotalPrice = 0;
            for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
            {
                TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[1].Value);
            }
            txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (rbtnAllCust.Checked == true)
            {

                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',[Price] as 'السعر' ,[Date] as 'التاريخ',[Cust_Name] as 'اسم العميل'FROM [Sales_System].[dbo].[Customer_Report]", "");
                DgvSearch.DataSource = tbl;

                //for total textbox
                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[1].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
            }

            else if (rbtnOneCust.Checked == true)
            {

                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',[Price] as 'السعر' ,[Date] as 'التاريخ',[Cust_Name] as 'اسم العميل'FROM [Sales_System].[dbo].[Customer_Report] where [Cust_Name]=N'" + cpxCustomers.Text + "' ", "");
                DgvSearch.DataSource = tbl;

                //for total textbox
                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[1].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المبالغ المسددة للعميل المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DgvSearch.Rows.Count >= 1)
                    if (rbtnAllCust.Checked == true) { MessageBox.Show("من فضلك حدد اسم عميل معين"); return; }
                if (rbtnOneCust.Checked == true)
                {
                    db.readData("delete from Customer_Report where Cust_Name=N'" +cpxCustomers.Text+ "'", "تم مسح البيانات بنجاح");
                    frm_CustomerReport_Load(null, null);
                }
            }
        }
    }
}