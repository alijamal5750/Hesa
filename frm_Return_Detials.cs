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
    public partial class frm_Return_Detials : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();



        public frm_Return_Detials()
        {
            InitializeComponent();
        }

        private void frm_Return_Detials_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();

            tbl.Clear();
            DgvSearch.DataSource = tbl;
        }

        private void sumall()
        {

            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");
           
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',[Sup_Name] as 'اسم المورد',[Cust_Name] as 'اسم العميل',[Pro_Name] as 'اسم المنتج',[Date] as 'تاريخ الارجاع',[Qty] as 'الكمية',[Price] as 'السعر قبل الضريبة',[Total] as 'سعر الصنف',[User_Name] as 'اسم المستخدم',[TotalOrder] as 'سعر الفاتورة الكلي' ,[Madfou3] as 'المدفوع',[Baky] as 'الباقي' ,[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة',[Unit] as 'الوحدة'FROM [Sales_System].[dbo].[Returns_Details] where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' order by Order_ID ASC", "");
                DgvSearch.DataSource = tbl;

                
                    try
                    {
                        decimal Total = 0, TotalTax = 0;
                        for (int i = 0; i <= DgvSearch.Rows.Count - 1;i++)
                        {
                            Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[7].Value);
                            TotalTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[12].Value);
                        }

                        txtTotal.Text = Math.Round(Total, 3).ToString();
                        txtotalta.Text = Math.Round(TotalTax, 2).ToString();
                    }
                    catch (Exception) { }
             if (DgvSearch.Rows.Count <= 0) { txtotalta.Text = "0"; txtTotal.Text = "0"; }
                
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            if (rbtnAllReturn.Checked == true)
            {
                sumall();
            }

            else if (rbtnSalesReturn.Checked == true)
            {
                string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                string date2 = DtpTo.Value.ToString("yyyy-MM-dd");
                tbl.Clear();
                tbl = db.readData("SELECT [Returns_Details].[Order_ID]  as 'رقم الفاتورة',[Cust_Name] as 'اسم العميل',[Pro_Name] as 'اسم المنتج',[Date] as 'تاريخ الارجاع',[Qty] as 'الكمية',[Price] as 'السعر قبل الضريبة',[Total] as 'سعر الصنف',[User_Name] as 'اسم المستخدم',[TotalOrder] as 'سعر الفاتورة الكلي' ,[Madfou3] as 'المدفوع',[Baky] as 'الباقي' ,[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة',[Unit] as 'الوحدة'FROM [Sales_System].[dbo].[Returns_Details],[Returns]   where [Returns_Details].Order_ID=[Returns].Order_ID and [Returns].Order_Type =N'مرتجعات مبيعات' and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' order by Returns_Details.Order_ID ASC", "");
                DgvSearch.DataSource = tbl;

                // for the total orders 

                if (DgvSearch.Rows.Count >= 1)
                {
                    try
                    {
                        decimal Total = 0, TotalTax = 0;
                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[6].Value);
                            TotalTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value);
                        }

                        txtTotal.Text = Math.Round(Total, 3).ToString();
                        txtotalta.Text = Math.Round(TotalTax, 3).ToString();
                    }
                    catch (Exception) { }
                }
                else if (DgvSearch.Rows.Count <= 0) { txtotalta.Text = "0"; txtTotal.Text = "0"; }

            }

            else if (txttotaltax.Checked == true)
            {
                string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
                string date2 = DtpTo.Value.ToString("yyyy-MM-dd");
                tbl.Clear();
                tbl = db.readData("SELECT [Returns_Details].[Order_ID]  as 'رقم الفاتورة',[Sup_Name]  as 'اسم المورد',[Pro_Name] as 'اسم المنتج',[Date] as 'تاريخ الارجاع',[Qty] as 'الكمية',[Price] as 'السعر قبل الضريبة',[Total] as 'سعر الصنف',[User_Name] as 'اسم المستخدم',[TotalOrder] as 'سعر الفاتورة الكلي' ,[Madfou3] as 'المدفوع',[Baky] as 'الباقي' ,[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة',[Unit] as 'الوحدة'FROM [Sales_System].[dbo].[Returns_Details],[Returns]   where [Returns_Details].Order_ID=[Returns].Order_ID and [Returns].Order_Type =N'مرتجعات مشتريات' and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' order by Returns_Details.Order_ID ASC", "");
                DgvSearch.DataSource = tbl;

                // for the total orders 

                if (DgvSearch.Rows.Count >= 1)
                {
                    try
                    {
                        decimal Total = 0, TotalTax = 0;
                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[6].Value);
                            TotalTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value);
                        }

                        txtTotal.Text = Math.Round(Total, 3).ToString();
                        txtotalta.Text = Math.Round(TotalTax, 2).ToString();
                    }
                    catch (Exception) { }
                }
                else if (DgvSearch.Rows.Count <= 0) { txtotalta.Text = "0"; txtTotal.Text = "0"; }
            }

          
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");


            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل تريد حذف البيانات لهذه الفترة ؟", "تأكيد !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    db.executedata("delete Returns where convert(date,Order_Date,105) between '" + date1 + "' and '" + date2 + "'", "");

                    db.executedata("delete Returns_Details where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "'", "");

                    MessageBox.Show("تم المسح بنجاح !", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frm_Return_Detials_Load(null, null);
                }

            }
        }
    }
}