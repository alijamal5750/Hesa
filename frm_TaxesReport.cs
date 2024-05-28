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
    public partial class frm_TaxesReport : DevExpress.XtraEditors.XtraForm
    {


        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_TaxesReport()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_TaxesReport_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            string sale = "", buy = "", salereturn = "", buyreturn = "";
            if (checkSale.Checked == true)
            {
                sale = "فاتورة مبيعات";
            }
            else
            {
                sale = "";
            }

            if (checkBuy.Checked == true)
            {
                buy = "فاتورة مشتريات";
            }

            else
            {
                buy = "";
            }

            if (checkSaleReturn.Checked == true)
            {
                salereturn = "فاتورة مرتجعات مبيعات";
            }

            else
            {
                salereturn = "";
            }

            if (checkBuyReturn.Checked == true)
            {
                buyreturn = "فاتورة مرتجعات مشتريات";
            }

            else
            {
                buyreturn = "";
            }

                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Order_Num] as 'رقم الفاتورة ',[Order_Type] as 'نوع الفاتورة',[Tax_Type] as 'نوع الضريبة',[Sup_Name] as 'اسم المورد',[Cust_Name] as 'اسم العميل',[Total_Order] as 'اجمالي الفاتورة قبل الضريبة',[Total_Tax] as 'اجمالي الضريبة',[Total_AfterTax] as 'اجمالي الفاتورة بعد الضريبة',[Date] as 'تاريخ الفاتورة'FROM [Sales_System].[dbo].[Taxes_Report] where Order_Type in(N'"+sale+"',N'"+buy+"',N'"+salereturn+"',N'"+buyreturn+"')  and convert(date,Date,105) between N'" + date1 + "' and N'" + date2 + "'", "");
                DgvSearch.DataSource = tbl;

                decimal totalorder = 0, totaltax = 0, totalorderaftertax = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    totalorder += Convert.ToDecimal(DgvSearch.Rows[i].Cells[6].Value);
                    totaltax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[7].Value);
                    totalorderaftertax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[8].Value);
                }
                txtTotal.Text = Math.Round(totalorder, 2).ToString();
                txtTotalTax.Text = Math.Round(totaltax, 2).ToString();
                txtTotalAfterTax.Text = Math.Round(totalorderaftertax, 2).ToString();
            
        }

        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            // the same order id of the order 

            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (DgvSearch.Rows.Count <= 0)
            {
                MessageBox.Show("يجب ملئ البيانات اولاً");
                return;
            }

            DataTable tblRpt = new DataTable();

            string sale = "", buy = "", salereturn = "", buyreturn = "";
            if (checkSale.Checked == true)
            {
                sale = "فاتورة مبيعات";
            }
            else
            {
                sale = "";
            }

            if (checkBuy.Checked == true)
            {
                buy = "فاتورة مشتريات";
            }

            else
            {
                buy = "";
            }

            if (checkSaleReturn.Checked == true)
            {
                salereturn = "فاتورة مرتجعات مبيعات";
            }

            else
            {
                salereturn = "";
            }

            if (checkBuyReturn.Checked == true)
            {
                buyreturn = "فاتورة مرتجعات مشتريات";
            }

            else
            {
                buyreturn = "";
            }
                // from the stored_procedure 
            tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Order_Num] as 'رقم الفاتورة ',[Order_Type] as 'نوع الفاتورة',[Tax_Type] as 'نوع الضريبة',[Sup_Name] as 'اسم المورد',[Cust_Name] as 'اسم العميل',[Total_Order] as 'اجمالي الفاتورة قبل الضريبة',[Total_Tax] as 'اجمالي الضريبة',[Total_AfterTax] as 'اجمالي الفاتورة بعد الضريبة',[Date] as 'تاريخ الفاتورة'FROM [Sales_System].[dbo].[Taxes_Report] where [Order_Type] in(N'" + sale + "',N'" + buy + "',N'" + salereturn + "',N'" + buyreturn + "')  and convert(date,Date,105) between N'" + date1 + "' and N'" + date2 + "'", "");

            frm_Printing frm = new frm_Printing();

            RptTaxesReports rpt = new RptTaxesReports();

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

        private void RbtnPrintSummary_Click(object sender, EventArgs e)
        {
            // the same order id of the order 

            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");

            if (DgvSearch.Rows.Count <= 0)
            {
                MessageBox.Show("يجب ملئ البيانات اولاً");
                return;
            }

            DataTable tblRpt = new DataTable();

            string sale = "", buy = "", salereturn = "", buyreturn = "";
            if (checkSale.Checked == true)
            {
                sale = "فاتورة مبيعات";
            }
            else
            {
                sale = "";
            }

            if (checkBuy.Checked == true)
            {
                buy = "فاتورة مشتريات";
            }

            else
            {
                buy = "";
            }

            if (checkSaleReturn.Checked == true)
            {
                salereturn = "فاتورة مرتجعات مبيعات";
            }

            else
            {
                salereturn = "";
            }

            if (checkBuyReturn.Checked == true)
            {
                buyreturn = "فاتورة مرتجعات مشتريات";
            }

            else
            {
                buyreturn = "";
            }
            // from the stored_procedure 
            tbl = db.readData("select sum(Total_Order) as 'اجمالي فواتير المبيعات',sum(Total_Tax) as 'قيمة ضرائب المبيعات',sum(Total_AfterTax) as 'اجمالي بعد الضرائب' from Taxes_Report where Order_Type=N'فاتورة مبيعات'  and convert(date,Date,105) between N'" + date1 + "' and N'" + date2 + "'", "");

            frm_Printing frm = new frm_Printing();

            rpttaxesreportsummary rpt = new rpttaxesreportsummary();

            frm.crystalReportViewer1.RefreshReport();

            // for the server,database,username,password
            rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

            rpt.SetDataSource(tblRpt);

            rpt.SetParameterValue("@fromsale", date1);
            rpt.SetParameterValue("@tosale", date2);

            frm.crystalReportViewer1.ReportSource = rpt;

            // for the print to printers 
            //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

            //rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

            //rpt.PrintToPrinter(1,true,0,0);

            frm.ShowDialog();
        }
    }
}