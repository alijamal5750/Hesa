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
    public partial class frm_BuyReport : DevExpress.XtraEditors.XtraForm
    {
        public frm_BuyReport()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد حذف الفاتورة المحددة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.executedata("delete from Buy where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + "", "تم المسح بنجاح");
                }
                    frm_BuyReport_Load(null, null);
            }
        }

        private void frm_BuyReport_Load(object sender, EventArgs e)
        {
            try
            {
                DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();

           
                FillSupplier();
            } 

            catch (Exception) { }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

                if (rbtnAllSup.Checked == true)
                {   
                    // for check box of the order_id
                    if (CheackBoxOrderNumber.Checked == false)
                    {
                        tbl.Clear();
                        tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID  and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC", "");
                        DgvSearch.DataSource = tbl;
                        
                            
                    }

                    else if (CheackBoxOrderNumber.Checked == true)
                    {
                        tbl.Clear();
                        tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + txtOrderNumber.Text + " ORDER BY Order_ID ASC", "");
                        DgvSearch.DataSource = tbl;
                    }
                    // for the total orders  
                    try
                    {
                        if (DgvSearch.Rows.Count >= 1)
                        {
                            decimal Total = 0, totaltax = 0;

                            for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                            {
                                Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value);
                                totaltax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[8].Value) * Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                            }
                            txtTotalTax.Text = Math.Round(totaltax, 2).ToString();
                            txtTotal.Text = Math.Round(Total, 3).ToString();
                        }
                    }
                    catch (Exception) { }
                }


                if (rbtnOneSup.Checked == true)
                {
                    if (CheackBoxOrderNumber.Checked == false)
                    {
                        tbl.Clear();
                        tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and [Suppliers].Sup_ID=" + cpxSuppliers.SelectedValue + " and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ORDER BY Order_ID ASC", "");
                        DgvSearch.DataSource = tbl;
                    }

                    else if (CheackBoxOrderNumber.Checked == true)
                    {
                        tbl.Clear();
                        tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and [Suppliers].Sup_ID=" + cpxSuppliers.SelectedValue + " and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' and Order_ID=" + txtOrderNumber.Text + " ORDER BY Order_ID ASC", "");
                        DgvSearch.DataSource = tbl;
                    }
                    // for the total orders  
                    try
                    {
                        if (DgvSearch.Rows.Count >= 1)
                        {
                            decimal Total = 0, totaltax = 0;

                            for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                            {
                                Total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value);
                                totaltax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[8].Value) * Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value);
                            }
                            txtTotalTax.Text = Math.Round(totaltax, 2).ToString();
                            txtTotal.Text = Math.Round(Total, 3).ToString();
                        }
                    }
                    catch (Exception) { }
                }
            }


        // methode to print 8 cm order
      // methode to print 8 cm order or A4
        private void Print()
        {
            // the same order id of the order 

            int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + id + "", "");

            frm_Printing frm = new frm_Printing();

            frm.crystalReportViewer1.RefreshReport();

                RptOrderBuy rpt = new RptOrderBuy();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                //rpt.PrintToPrinter(1, true, 0, 0);

                frm.ShowDialog();
           
        }

        // methode to print A4 order
        private void PrintAll()
        {
            // the same order id of the order 
            if (DgvSearch.Rows.Count >= 1)
            {
                string date1;
                string date2;
                date1 = DtpFrom.Value.ToString("dd/MM/yyyy");
                date2 = DtpTo.Value.ToString("dd/MM/yyyy");


                DataTable tblRpt = new DataTable();

                

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID  and CONVERT(date,Date,105) between N'" + date1 + "' and N'" + date2 + "' ORDER BY Order_ID ASC", "");

                frm_Printing frm = new frm_Printing();

                RptBuyReport rpt = new RptBuyReport();

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
        }


        private void btnPrintSingleOrder_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                Print();
            }
        }

        private void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=8)
            {
                e.Handled = true;
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                PrintAll();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                // the same order id of the order 

                int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

                DataTable tblRpt = new DataTable();

                tblRpt.Clear();

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + id + "", "");

                frm_Printing frm = new frm_Printing();

                frm.crystalReportViewer1.RefreshReport();

                RptOrderBuyA4 rpt = new RptOrderBuyA4();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                //rpt.PrintToPrinter(1, true, 0, 0);

                frm.ShowDialog();

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                // the same order id of the order 

                int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

                DataTable tblRpt = new DataTable();

                tblRpt.Clear();

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + id + "", "");

                frm_Printing frm = new frm_Printing();

                frm.crystalReportViewer1.RefreshReport();

                RptOrderBuy rpt = new RptOrderBuy();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                rpt.PrintToPrinter(1, true, 0, 0);

                //frm.ShowDialog();
            }
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                // the same order id of the order 

                int id = Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value);

                DataTable tblRpt = new DataTable();

                tblRpt.Clear();

                // from the stored_procedure 
                tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',[Buy_Destails].[Tax_Value] as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي'FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + id + "", "");

                frm_Printing frm = new frm_Printing();

                frm.crystalReportViewer1.RefreshReport();

                RptOrderBuyA4 rpt = new RptOrderBuyA4();
                // for the server,database,username,password
                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

                rpt.SetDataSource(tblRpt);

                rpt.SetParameterValue("ID", id);

                frm.crystalReportViewer1.ReportSource = rpt;

                // for the print to printers 
                System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;

                rpt.PrintToPrinter(1, true, 0, 0);

                //frm.ShowDialog();
            }
        }
    }
    }
