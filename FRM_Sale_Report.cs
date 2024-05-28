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
    public partial class FRM_Sale_Report : DevExpress.XtraEditors.XtraForm
    {


        Database db = new Database();
        DataTable tbl = new DataTable();


        public FRM_Sale_Report()
        {
            InitializeComponent();
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
                    tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير',[Price] as 'السعر قبل الضريبة',[Sales_Details].[Tax_Value] as 'الضريبة' ,[Price_Tax] as 'السعر شامل الضريبة',[Unit] as 'الوحدة' ,[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'السعر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC ", "");
                    DgvSearch.DataSource = tbl;
                }
                else if (rbtnOneUser.Checked == true)
                {
                    tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير',[Price] as 'السعر قبل الضريبة',[Sales_Details].[Tax_Value] as 'الضريبة' ,[Price_Tax] as 'السعر شامل الضريبة',[Unit] as 'الوحدة' ,[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'السعر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID and User_Name=N'" + cpxUser.Text + "' and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC", "");
                    DgvSearch.DataSource = tbl;
                }

            }

            // for check box of the order_id
            else if (CheackBoxOrderNumber.Checked == true)
            {
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير',[Price] as 'السعر قبل الضريبة',[Sales_Details].[Tax_Value] as 'الضريبة' ,[Price_Tax] as 'السعر شامل الضريبة',[Unit] as 'الوحدة' ,[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID and Order_ID=N'" + txtOrderNumber.Text + "' ORDER BY Order_ID ASC", "");
                DgvSearch.DataSource = tbl;


            }

                // for the total orders  
                try
                {
                    if (DgvSearch.Rows.Count >= 1)
                    {
                        decimal  TotalTax = 0, TotalPriceTax = 0;

                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            TotalTax += (Convert.ToDecimal(DgvSearch.Rows[i].Cells[7].Value) * Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value));
                            TotalPriceTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value);
                        }
                       
                        txtTotalTax.Text = Math.Round(TotalTax, 3).ToString();
                        txtPriceTax.Text = Math.Round(TotalPriceTax, 2).ToString();

                    // to give me the total rbh7 for the selected user !

                    if (rbtnOneUser.Checked == true)
                    {
                        decimal rb7h = 0;

                        try
                        {
                            rb7h = Convert.ToDecimal(db.readData("select * from Users where User_ID=" + cpxUser.SelectedValue + " ", "").Rows[0][5]);
                        }
                        catch (Exception) { }
                        txtUserRb7h.Text = ((Convert.ToDecimal(txtPriceTax.Text) / 100) * rb7h).ToString();

                    }

                    if (rbtnAllUser.Checked == true)
                    {
                        txtUserRb7h.Text = "0";
                    }

                }
                   
                }
                catch (Exception) { }
        


            //if (rbtnOneUser.Checked == true)
            //{
            //    if (CheackBoxOrderNumber.Checked == false)
            //    {
            //        tbl.Clear();
            //        tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[User_Name] as 'اسم المستخدم',[Price] as 'سعر المنتج',[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and [Suppliers].Sup_ID=" + cpxSuppliers.SelectedValue + " and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC", "");
            //        DgvSearch.DataSource = tbl;
            //    }

            //    else if (CheackBoxOrderNumber.Checked == true)
            //    {
            //        tbl.Clear();
            //        tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[User_Name] as 'اسم المستخدم',[Price] as 'سعر المنتج',[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and [Suppliers].Sup_ID=" + cpxSuppliers.SelectedValue + " and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' and Order_ID=" + txtOrderNumber.Text + " ORDER BY Order_ID ASC", "");
            //        DgvSearch.DataSource = tbl;
            //    }
            //    // for the total orders  
            //    try
            //    {
            //        if (DgvSearch.Rows.Count >= 1)
            //        {
            //            decimal Total = 0;

            //            for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
            //            {
            //                Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[9].Value);
            //            }

            //            txtTotal.Text = Math.Round(Total, 3).ToString();
            //        }
            //    }
            //    catch (Exception) { }
            //}
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {

            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd"); 

            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد حذف الفاتورة المحددة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.executedata("delete from Sales where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "'", "تم المسح بنجاح");
                }
                btnSearch_Click(null, null);
            }
        }

        private void FillUser()
        {
            cpxUser.DataSource = db.readData("select * from Users", "");
            cpxUser.DisplayMember = "User_Name";
            cpxUser.ValueMember = "User_ID";
        }

        private void FRM_Sale_Report_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
            FillUser();
        }


        // methode to print A4 order
        private void PrintAll()
        {
            // the same order id of the order 
         
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("dd/MM/yyyy");
                date2 = DtpTo.Value.ToString("dd/MM/yyyy");

                DataTable tblRpt = new DataTable();
                
                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير' ,[Price] as 'سعر المنتج',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID  and CONVERT(date,Date,105) between N'" + date1 + "' and N'" + date2 + "'", "");

                frm_Printing frm = new frm_Printing();

                rpt_SalesReport rpt = new rpt_SalesReport();

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

        private void btnPrintSingleOrder_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            { 
            // methode to print 8 cm order

            // the same order id of the order 

            int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير' ,[Price] as 'سعر المنتج',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID   and Order_ID=" + id + "", "");

            frm_Printing frm = new frm_Printing();

            rpt_OrderSales rpt = new rpt_OrderSales();

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
    }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

               
               
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير',[Price] as 'السعر قبل الضريبة',[Sales_Details].[Tax_Value] as 'الضريبة' ,[Price_Tax] as 'السعر شامل الضريبة',[Unit] as 'الوحدة' ,[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'السعر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID ", "");
            DgvSearch.DataSource = tbl;
               
            }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                // methode to print 8 cm order

                // the same order id of the order 

                int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

                DataTable tblRpt = new DataTable();

                tblRpt.Clear();

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير' ,[Price] as 'سعر المنتج',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID   and Order_ID=" + id + "", "");

                frm_Printing frm = new frm_Printing();

                RptOrderSaleA4 rpt = new RptOrderSaleA4();

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
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                // methode to print 8 cm order

                // the same order id of the order 

                int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

                DataTable tblRpt = new DataTable();

                tblRpt.Clear();

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير' ,[Price] as 'سعر المنتج',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID   and Order_ID=" + id + "", "");

                frm_Printing frm = new frm_Printing();

                rpt_OrderSales rpt = new rpt_OrderSales();

                frm.crystalReportViewer1.RefreshReport();

                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

                rpt.PrintToPrinter(1, true, 0, 0);

                //frm.ShowDialog();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                // methode to print 8 cm order

                // the same order id of the order 

                int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

                DataTable tblRpt = new DataTable();

                tblRpt.Clear();

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[User_Name] as 'الكاشير' ,[Price] as 'سعر المنتج',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'العر المتبقي'FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID   and Order_ID=" + id + "", "");

                frm_Printing frm = new frm_Printing();

                RptOrderSaleA4 rpt = new RptOrderSaleA4();

                frm.crystalReportViewer1.RefreshReport();

                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

                rpt.PrintToPrinter(1, true, 0, 0);

                //frm.ShowDialog();
            }
        }
    }
}
      