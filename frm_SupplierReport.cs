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
    public partial class frm_SupplierReport : DevExpress.XtraEditors.XtraForm
    {
        public frm_SupplierReport()
        {
            InitializeComponent();
        }


        Database db = new Database();
        DataTable tbl = new DataTable();

        private void FillSupplier()
        {
            cpxSuppliers.DataSource = db.readData("select * from Suppliers", "");
            cpxSuppliers.DisplayMember = "Sup_Name";
            cpxSuppliers.ValueMember = "Sup_ID";
        }

        private void frm_SupplierReport_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                FillSupplier();
            }

            catch (Exception) { }

            //to fill the supplier_money table into datagridview
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتروة' ,[Price] as 'المبلغ المسدد',[Date] as 'تاريخ الفاتورة',suppliers.Sup_Name  as 'اسم المورد' FROM [Sales_System].[dbo].[Supplier_Report],[Suppliers] where suppliers.Sup_ID=Supplier_Report.Sup_ID ", "");
            DgvSearch.DataSource = tbl;

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
            if (rbtnAllSup.Checked == true)
            {
               
                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتروة' ,[Price] as 'المبلغ المسدد',[Date] as 'تاريخ الفاتورة',suppliers.Sup_Name  as 'اسم المورد' FROM [Sales_System].[dbo].[Supplier_Report],[Suppliers] where suppliers.Sup_ID=Supplier_Report.Sup_ID ", "");
                DgvSearch.DataSource = tbl;

                //for total textbox
                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[1].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
            }

            else if (rbtnOneSup.Checked == true)
            {
               
                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتروة' ,[Price] as 'المبلغ المسدد',[Date] as 'تاريخ الفاتورة',suppliers.Sup_Name  as 'اسم المورد' FROM [Sales_System].[dbo].[Supplier_Report],[Suppliers] where suppliers.Sup_ID=Supplier_Report.Sup_ID and [Suppliers].Sup_ID=" + cpxSuppliers.SelectedValue + " ", "");
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
            if (MessageBox.Show("هل تريد حذف المبالغ المسددة للمورد المحدد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DgvSearch.Rows.Count >= 1)
                    if (rbtnAllSup.Checked == true) { MessageBox.Show("من فضلك حدد اسم مورد معين"); return; }
                if (rbtnOneSup.Checked == true)
                {
                    db.readData("delete from Supplier_Report where Sup_ID= " + cpxSuppliers.SelectedValue + "", "تم مسح البيانات بنجاح");
                    frm_SupplierReport_Load(null, null);
                }
            }
            }
        }
    }
