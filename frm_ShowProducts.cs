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
    public partial class frm_ShowProducts : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();


        private void fillgroup()
        {
            cpxGroup.DataSource = db.readData("select * from Products_Group", "");
            cpxGroup.DisplayMember = "Group_Name";
            cpxGroup.ValueMember = "Group_ID";
        }

        public frm_ShowProducts()
        {
            InitializeComponent();
        }

        private void frm_ShowProducts_Load(object sender, EventArgs e)
        {
            try
            {
                fillgroup();
                tbl.Clear();
                DgvStore.DataSource = tbl;
                txtTotalGomla.Text = "0";
                txtTotalQty.Text = "0";
                txtTotalSale.Text = "0";
                txtTotalTax.Text = "0";
            }
            catch (Exception) { }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {

                tbl.Clear();
                tbl = db.readData("SELECT [Pro_ID] as 'معرف المنتج',[Pro_Name] as 'اسم المنتج',[Qty] as 'الكمية',[Gomla_Price] as 'سعر الجملة',[Sale_Price] as 'سعر البيع',[Tax_Value] as 'قيمة الضريبة المضافة',[Sale_PriceTax] as 'السعر بعد الضريبة',[Barcode] as 'باركود المنتج',[MinyQty] as 'حد الطلب',[MaxDiscount] as 'الخصم' ,[IS_Tax] as 'حالة الضريبة',Group_Name  as 'ينتمي للصنف',[Main_UnitName] as 'الوحدة الرئيسية',[Sale_UnitName] as 'وحدة البيع',[Buy_UnitName] as 'وحدة الشراء'FROM [Sales_System].[dbo].[Products],[Products_Group] where Products.Group_ID =Products_Group.Group_ID and Products.Group_ID=" + cpxGroup.SelectedValue + " order by Pro_ID", "");
                DgvStore.DataSource = tbl;

                if (DgvStore.Rows.Count >= 1)
                {
                    decimal totalqty = 0, totalsale = 0, totalbuy = 0, totaltax = 0;

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalqty += Convert.ToDecimal(DgvStore.Rows[i].Cells[2].Value);
                    }
                    txtTotalQty.Text = Math.Round(totalqty, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalbuy += Convert.ToDecimal(DgvStore.Rows[i].Cells[3].Value);
                    }
                    txtTotalGomla.Text = Math.Round(totalbuy, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalsale += Convert.ToDecimal(DgvStore.Rows[i].Cells[4].Value);
                    }
                    txtTotalSale.Text = Math.Round(totalsale, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totaltax += Convert.ToDecimal(DgvStore.Rows[i].Cells[5].Value);
                    }
                    txtTotalTax.Text = Math.Round(totaltax, 2).ToString();
                }
                else
                {
                    txtTotalGomla.Text = "0";
                    txtTotalQty.Text = "0";
                    txtTotalSale.Text = "0";
                    txtTotalTax.Text = "0";
                }
            }
            catch (Exception) { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                tbl.Clear();
                tbl = db.readData("SELECT [Pro_ID] as 'معرف المنتج',[Pro_Name] as 'اسم المنتج',[Qty] as 'الكمية',[Gomla_Price] as 'سعر الجملة',[Sale_Price] as 'سعر البيع',[Tax_Value] as 'قيمة الضريبة المضافة',[Sale_PriceTax] as 'السعر بعد الضريبة',[Barcode] as 'باركود المنتج',[MinyQty] as 'حد الطلب',[MaxDiscount] as 'الخصم' ,[IS_Tax] as 'حالة الضريبة',Group_Name  as 'ينتمي للصنف',[Main_UnitName] as 'الوحدة الرئيسية',[Sale_UnitName] as 'وحدة البيع',[Buy_UnitName] as 'وحدة الشراء'FROM [Sales_System].[dbo].[Products],[Products_Group] where Products.Group_ID =Products_Group.Group_ID and Barcode=N'" + txtBarcode.Text + "' order by Pro_ID", "");
                DgvStore.DataSource = tbl;

                if (DgvStore.Rows.Count >= 1)
                {
                    decimal totalqty = 0, totalsale = 0, totalbuy = 0, totaltax = 0;

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalqty += Convert.ToDecimal(DgvStore.Rows[i].Cells[2].Value);
                    }
                    txtTotalQty.Text = Math.Round(totalqty, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalbuy += Convert.ToDecimal(DgvStore.Rows[i].Cells[3].Value);
                    }
                    txtTotalGomla.Text = Math.Round(totalbuy, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalsale += Convert.ToDecimal(DgvStore.Rows[i].Cells[4].Value);
                    }
                    txtTotalSale.Text = Math.Round(totalsale, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totaltax += Convert.ToDecimal(DgvStore.Rows[i].Cells[5].Value);
                    }
                    txtTotalTax.Text = Math.Round(totaltax, 2).ToString();
                }
                else
                {
                    txtTotalGomla.Text = "0";
                    txtTotalQty.Text = "0";
                    txtTotalSale.Text = "0";
                    txtTotalTax.Text = "0";
                }
            }
            catch (Exception) { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                tbl.Clear();
                tbl = db.readData("SELECT [Pro_ID] as 'معرف المنتج',[Pro_Name] as 'اسم المنتج',[Qty] as 'الكمية',[Gomla_Price] as 'سعر الجملة',[Sale_Price] as 'سعر البيع',[Tax_Value] as 'قيمة الضريبة المضافة',[Sale_PriceTax] as 'السعر بعد الضريبة',[Barcode] as 'باركود المنتج',[MinyQty] as 'حد الطلب',[MaxDiscount] as 'الخصم' ,[IS_Tax] as 'حالة الضريبة',Group_Name  as 'ينتمي للصنف',[Main_UnitName] as 'الوحدة الرئيسية',[Sale_UnitName] as 'وحدة البيع',[Buy_UnitName] as 'وحدة الشراء'FROM [Sales_System].[dbo].[Products],[Products_Group] where Products.Group_ID =Products_Group.Group_ID and Pro_Name like N'%" + txtName.Text + "%' order by Pro_ID", "");
                DgvStore.DataSource = tbl;

                if (DgvStore.Rows.Count >= 1)
                {
                    decimal totalqty = 0, totalsale = 0, totalbuy = 0, totaltax = 0;

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalqty += Convert.ToDecimal(DgvStore.Rows[i].Cells[2].Value);
                    }
                    txtTotalQty.Text = Math.Round(totalqty, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalbuy += Convert.ToDecimal(DgvStore.Rows[i].Cells[3].Value);
                    }
                    txtTotalGomla.Text = Math.Round(totalbuy, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totalsale += Convert.ToDecimal(DgvStore.Rows[i].Cells[4].Value);
                    }
                    txtTotalSale.Text = Math.Round(totalsale, 2).ToString();

                    for (int i = 0; i <= DgvStore.Rows.Count - 1; i++)
                    {
                        totaltax += Convert.ToDecimal(DgvStore.Rows[i].Cells[5].Value);
                    }
                    txtTotalTax.Text = Math.Round(totaltax, 2).ToString();
                }
                else
                {
                    txtTotalGomla.Text = "0";
                    txtTotalQty.Text = "0";
                    txtTotalSale.Text = "0";
                    txtTotalTax.Text = "0";
                }
            }
            catch (Exception) { }
        }
    }
}