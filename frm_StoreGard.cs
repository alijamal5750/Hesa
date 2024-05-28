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
    public partial class frm_StoreGard : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();


        private void FillStore()
        {
            cpxStore.DataSource = db.readData("select * from Store", "");
            cpxStore.DisplayMember = "Store_Name";
            cpxStore.ValueMember = "Store_ID";
        }

        public frm_StoreGard()
        {
            InitializeComponent();
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnAllStore.Checked == true)
                {
                    tbl.Clear();
                    tbl = db.readData("SELECT [Products_Qty].[Pro_ID] as 'معرف المنتج',Pro_Name as 'اسم المنتج',[Store_Name] as 'اسم المخزن',[Products_Qty].[Qty] as 'الكمية',[Buy_Price] as 'سعر الشراء',[Products_Qty].[Sale_PriceTax] as 'سعر البيع'FROM [Sales_System].[dbo].[Products_Qty],[Products] where Products .Pro_ID=Products_Qty .Pro_ID", "");
                    DgvSearch.DataSource = tbl;

                    if (DgvSearch.Rows.Count >= 1)
                    {
                        decimal TotalRb7h = 0, TotalBuy = 0, TotalSale = 0;

                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            TotalRb7h += (Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value) - Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value)) * Convert.ToDecimal(DgvSearch.Rows[i].Cells[3].Value);
                            TotalBuy += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                            TotalSale += Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value);
                        }
                        txtTotalRb7h.Text = Math.Round(TotalRb7h, 2).ToString();
                        txtTotalBuy.Text = Math.Round(TotalBuy, 2).ToString();
                        txtTotalSale.Text = Math.Round(TotalSale, 2).ToString();
                    }

                    else
                    {
                        txtTotalBuy.Text = "0";
                        txtTotalRb7h.Text = "0";
                        txtTotalSale.Text = "0";
                    }
                }

                if (rbtnSingleStore.Checked == true)
                { 
                
                    tbl.Clear();
                    tbl = db.readData("SELECT [Products_Qty].[Pro_ID] as 'معرف المنتج',Pro_Name as 'اسم المنتج',[Store_Name] as 'اسم المخزن',[Products_Qty].[Qty] as 'الكمية',[Buy_Price] as 'سعر الشراء',[Products_Qty].[Sale_PriceTax] as 'سعر البيع'FROM [Sales_System].[dbo].[Products_Qty],[Products] where Products .Pro_ID=Products_Qty .Pro_ID and [Products_Qty].Store_ID="+cpxStore.SelectedValue+" ", "");
                    DgvSearch.DataSource = tbl;

                    if (DgvSearch.Rows.Count >= 1)
                    {
                        decimal TotalRb7h = 0, TotalBuy = 0, TotalSale = 0;

                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            TotalRb7h += (Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value) - Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value)) * Convert.ToDecimal(DgvSearch.Rows[i].Cells[3].Value);
                            TotalBuy += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                            TotalSale += Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value);
                        }
                        txtTotalRb7h.Text = Math.Round(TotalRb7h, 2).ToString();
                        txtTotalBuy.Text = Math.Round(TotalBuy, 2).ToString();
                        txtTotalSale.Text = Math.Round(TotalSale, 2).ToString();
                    }

                    else
                    {
                        txtTotalBuy.Text = "0";
                        txtTotalRb7h.Text = "0";
                        txtTotalSale.Text = "0";
                    }
                }

            }
            catch (Exception) { }
        }

        private void frm_StoreGard_Load(object sender, EventArgs e)
        {
            try
            {
                FillStore();
                txtTotalBuy.Text = "0";
                txtTotalRb7h.Text = "0";
                txtTotalSale.Text = "0";
            }
            catch (Exception) { }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbl.Clear();
                tbl = db.readData("SELECT [Products_Qty].[Pro_ID] as 'معرف المنتج',Pro_Name as 'اسم المنتج',[Store_Name] as 'اسم المخزن',[Products_Qty].[Qty] as 'الكمية',[Buy_Price] as 'سعر الشراء',[Products_Qty].[Sale_PriceTax] as 'سعر البيع'FROM [Sales_System].[dbo].[Products_Qty],[Products] where Products .Pro_ID=Products_Qty .Pro_ID and [Products].Barcode=N'" + txtBarcode.Text + "' ", "");
                DgvSearch.DataSource = tbl;

                if (DgvSearch.Rows.Count >= 1)
                {
                    decimal TotalRb7h = 0, TotalBuy = 0, TotalSale = 0;

                    for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                    {
                        TotalRb7h += (Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value) - Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value)) * Convert.ToDecimal(DgvSearch.Rows[i].Cells[3].Value);
                        TotalBuy += Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                        TotalSale += Convert.ToDecimal(DgvSearch.Rows[i].Cells[5].Value);
                    }
                    txtTotalRb7h.Text = Math.Round(TotalRb7h, 2).ToString();
                    txtTotalBuy.Text = Math.Round(TotalBuy, 2).ToString();
                    txtTotalSale.Text = Math.Round(TotalSale, 2).ToString();
                }

                else
                {
                    txtTotalBuy.Text = "0";
                    txtTotalRb7h.Text = "0";
                    txtTotalSale.Text = "0";
                }
            }

        }
    }
}