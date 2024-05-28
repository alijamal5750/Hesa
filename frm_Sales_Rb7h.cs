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
    public partial class frm_Sales_Rb7h : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable(); 



        public frm_Sales_Rb7h()
        {
            InitializeComponent();
        }

        private void frm_Sales_Rb7h_Load(object sender, EventArgs e)
        {
            FillUsers();
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
        }

        private void FillUsers()
        {
            cpxUser.DataSource = db.readData("select * from Users", "");
            cpxUser.DisplayMember = "User_Name";
            cpxUser.ValueMember = "User_ID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (CheackBoxOrderNumber.Checked == false)
            {

                if (rbtnAllUser.Checked == true)
                {

                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Cust_Name] as 'اسم العميل',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Sales_Rb7h].[Qty] as 'الكمية المسحوبة من المخزن',[Products_Unit].[QtyINmain] * [Sales_Rb7h].Qty  as 'الكمية المطلوبة',[User_Name] as 'اسم المستخدم' ,[Price] as 'السعر قبل الضريبة' ,[Discount] as 'الخصم' ,[Total] as 'االاجمالي',[TotalOrder] as 'اجمالي الفاتورة',[Madfou3] as 'المدفوع',[Baky] as 'الباقي',([Price_Tax] - [Buy_Price]) * [Products_Unit].[QtyINmain] * [Sales_Rb7h].Qty as 'الربح'  ,[Unit] as 'الوحدة',[Sales_Rb7h].[Tax_Value] as 'قيمة الضرائب',[Price_Tax] as 'السعر بعد الضريبة',[Time] as 'وقت الفاتورة',[Buy_Price] as 'سعر الشراء'FROM [Sales_Rb7h],[Products_Unit] , Products where Products.Pro_ID=Sales_Rb7h.Pro_ID and [Sales_Rb7h].Unit =[Products_Unit].Unit_Name and [Sales_Rb7h].Pro_ID =[Products_Unit].Pro_ID  and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC", "");
                    DgvSearch.DataSource = tbl;
                }

                else if (rbtnOneUser.Checked == true)
                {
                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Cust_Name] as 'اسم العميل',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Sales_Rb7h].[Qty] as 'الكمية المسحوبة من المخزن',[Products_Unit].[QtyINmain] * [Sales_Rb7h].Qty  as 'الكمية المطلوبة',[User_Name] as 'اسم المستخدم' ,[Price] as 'السعر قبل الضريبة' ,[Discount] as 'الخصم' ,[Total] as 'االاجمالي',[TotalOrder] as 'اجمالي الفاتورة',[Madfou3] as 'المدفوع',[Baky] as 'الباقي',([Price_Tax] - [Buy_Price]) * [Products_Unit].[QtyINmain] * [Sales_Rb7h].Qty as 'الربح'  ,[Unit] as 'الوحدة',[Sales_Rb7h].[Tax_Value] as 'قيمة الضرائب',[Price_Tax] as 'السعر بعد الضريبة',[Time] as 'وقت الفاتورة',[Buy_Price] as 'سعر الشراء'FROM [Sales_Rb7h],[Products_Unit] , Products where Products.Pro_ID=Sales_Rb7h.Pro_ID and [Sales_Rb7h].Unit =[Products_Unit].Unit_Name and [Sales_Rb7h].Pro_ID =[Products_Unit].Pro_ID  and User_Name=N'" + cpxUser.Text + "' and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC", "");
                    DgvSearch.DataSource = tbl;

                }
            }

            if (CheackBoxOrderNumber.Checked == true)
            {
                if (rbtnAllUser.Checked == true)
                {
                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Cust_Name] as 'اسم العميل',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Sales_Rb7h].[Qty] as 'الكمية المسحوبة من المخزن',[Products_Unit].[QtyINmain] * [Sales_Rb7h].Qty  as 'الكمية المطلوبة',[User_Name] as 'اسم المستخدم' ,[Price] as 'السعر قبل الضريبة' ,[Discount] as 'الخصم' ,[Total] as 'االاجمالي',[TotalOrder] as 'اجمالي الفاتورة',[Madfou3] as 'المدفوع',[Baky] as 'الباقي',([Price_Tax] - [Buy_Price]) * [Products_Unit].[QtyINmain] * [Sales_Rb7h].Qty as 'الربح'  ,[Unit] as 'الوحدة',[Sales_Rb7h].[Tax_Value] as 'قيمة الضرائب',[Price_Tax] as 'السعر بعد الضريبة',[Time] as 'وقت الفاتورة',[Buy_Price] as 'سعر الشراء'FROM [Sales_Rb7h],[Products_Unit] , Products where Products.Pro_ID=Sales_Rb7h.Pro_ID and [Sales_Rb7h].Unit =[Products_Unit].Unit_Name and [Sales_Rb7h].Pro_ID =[Products_Unit].Pro_ID  and Order_ID=" + txtOrderNumber.Text + " ORDER BY Order_ID ASC", "");
                    DgvSearch.DataSource = tbl;
                }
            }
            // for the total orders  
            try
            {
                if (DgvSearch.Rows.Count >= 1)
                {
                    decimal  TotalRb7h = 0;

                    for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                    {
                        TotalRb7h += Convert.ToDecimal(DgvSearch.Rows[i].Cells[13].Value);
                    }

                   
                    txtTotalRb7h.Text = Math.Round(TotalRb7h, 3).ToString();
                }
            }
            catch (Exception) { }

        }

        // methode to print A4 order
        private void PrintAll()
        {
            // the same order id of the order 

            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            DataTable tblRpt = new DataTable();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Rb7h].[Qty] as 'الكمية' ,[Buy_Price] as 'سعر الشراء',[User_Name] as 'الكاشير' ,[Price] as 'سعر البيع',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',(Sale_Price - Buy_Price) * (Sales_Rb7h .Qty ) as 'اجمالي الربح',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'السعر المتبقي' FROM [Sales_System].[dbo].[Sales_Rb7h] ,[Products] where Products.Pro_ID=Sales_Rb7h.Pro_ID  and CONVERT(date,Date,105) between N'" + date1 + "' and N'" + date2 + "'", "");

            frm_Printing frm = new frm_Printing();

            rpt_SalesRb7h rpt = new rpt_SalesRb7h();

            frm.crystalReportViewer1.RefreshReport();

            // for the server,database,username,password
            rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

            rpt.SetDataSource(tblRpt);

            rpt.SetParameterValue("From", date1);
            rpt.SetParameterValue("To", date2);

            frm.crystalReportViewer1.ReportSource = rpt;

            // for the print to printers 
            //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

            //rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

            //rpt.PrintToPrinter(1,true,0,0);

            frm.ShowDialog();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                PrintAll();
            }
        }
    }
}