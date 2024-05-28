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
    public partial class frm_SupplierMoney : DevExpress.XtraEditors.XtraForm
    {

        string Stock_ID = "";

        public frm_SupplierMoney()
        {
            InitializeComponent();
        }

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();
        private void FillSupplier()
        {
            cpxSuppliers.DataSource = db.readData("select * from Suppliers", "");
            cpxSuppliers.DisplayMember = "Sup_Name";
            cpxSuppliers.ValueMember = "Sup_ID";
        }

        private void cbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frm_SupplierMoney_Load(object sender, EventArgs e)
        {
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
            DtpDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                FillSupplier();
            }
            catch (Exception) { }

            //to fill the supplier_money table into datagridview
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,suppliers.Sup_Name as 'اسم المورد',[Price] as 'المبلغ',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Supplier_Money],[Suppliers] where suppliers.Sup_ID=Supplier_Money.Sup_ID", "");
            DgvSearch.DataSource = tbl;

            //for total textbox
            decimal TotalPrice = 0;
            for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
            {
                TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
            }
            txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (rbtnAllSup.Checked == true)
            {
                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,suppliers.Sup_Name as 'اسم المورد',[Price] as 'المبلغ',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Supplier_Money],[Suppliers] where suppliers.Sup_ID=Supplier_Money.Sup_ID", "");
                DgvSearch.DataSource = tbl;

                //for total textbox
                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
            }

            else if (rbtnOneSup.Checked == true)
            {
                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,suppliers.Sup_Name as 'اسم المورد',[Price] as 'المبلغ',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Supplier_Money],[Suppliers] where suppliers.Sup_ID=Supplier_Money.Sup_ID and Suppliers.Sup_ID=" + cpxSuppliers.SelectedValue + "", "");
                DgvSearch.DataSource = tbl;

                //for total textbox
                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            if (DgvSearch.Rows.Count >= 1)
            {

                decimal stock_Money = 0;
                tbl = db.readData("select * from Stock where Stock_ID="+Stock_ID+"", "");
                stock_Money = Convert.ToDecimal(tbl.Rows[0][1]);
                if (Convert.ToDecimal(NudMiniQty.Value) > stock_Money)
                {
                    MessageBox.Show("المبلغ الموجود في الخزنة غير كافي لاجراء العملية ! ");
                    return;
                }

                

                // for pay all

                if (rbtnPayAll.Checked == true)
                {

                    if (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[2].Value) > stock_Money)
                    {
                        MessageBox.Show("المبلغ الموجود في الخزنة غير كافي لاجراء العملية ! ");
                        return;
                    }

                    if (MessageBox.Show("هل انت متأكد من تسديد المبلغ بالكامل للمورد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (rbtnAllSup.Checked == true) { MessageBox.Show("من فضلك حدد اسم مورد معين"); return; }
                        
                        // for the price delete in where condition thats to make sure the price is deleted aslo from the table and move it to the price of the frm_supplier_report
                        db.readData("delete from Supplier_Money where Order_ID= " + DgvSearch.CurrentRow.Cells[0].Value + " and Price=" + DgvSearch.CurrentRow.Cells[2].Value + "", "");
                        db.executedata("insert into Supplier_Report values(" + DgvSearch.CurrentRow.Cells[0].Value + "," + DgvSearch.CurrentRow.Cells[2].Value + ",N'" + d + "'," + cpxSuppliers.SelectedValue + ") ", "تم التسديد بنجاح");
                        tr.TrackerInsert("تسديد الموردين", "تسديد كامل",DgvSearch.CurrentRow.Cells[1].Value.ToString());

                        db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + DgvSearch.CurrentRow.Cells[2].Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات الى موردين',N'') ", "");

                        db.executedata("update Stock set Money=Money - " + DgvSearch.CurrentRow.Cells[2].Value + " where Stock_ID=" + Stock_ID + "  ", "");

                        DataTable empty = new DataTable(); empty.Clear(); DgvSearch.DataSource = empty;
                    }


                    }
                // for pay part

                if (rbtnPayPart.Checked == true)
                {

                    if (Convert.ToDecimal(NudMiniQty.Value) > stock_Money)
                    {
                        MessageBox.Show("المبلغ الموجود في الخزنة غير كافي لاجراء العملية ! ");
                        return;
                    }

                    if (MessageBox.Show("هل انت متأكد من تسديد جزء من المبلغ للمورد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (rbtnAllSup.Checked == true) { MessageBox.Show("من فضلك حدد اسم مورد معين"); return; }

                        decimal money = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[2].Value) - NudMiniQty.Value;

                        if (money > 0)
                        {
                            db.executedata("update Supplier_Money set Price=" + money + " where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Price=" + DgvSearch.CurrentRow.Cells[2].Value + "", "");
                            db.executedata("insert into Supplier_Report values(" + DgvSearch.CurrentRow.Cells[0].Value + "," + NudMiniQty.Value + ",N'" + d + "'," + cpxSuppliers.SelectedValue + ") ", "تم التسديد بنجاح");
                            tr.TrackerInsert("تسديد الموردين", "تسديد جزئي", DgvSearch.CurrentRow.Cells[1].Value.ToString());
                            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudMiniQty.Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات الى موردين',N'') ", "");

                            db.executedata("update Stock set Money=Money - " + NudMiniQty.Value + " where Stock_ID=" + Stock_ID + "  ", "");
                            DataTable empty = new DataTable(); empty.Clear(); DgvSearch.DataSource = empty;
                        }
                        else if (money == 0)
                        {
                            db.readData("delete from Supplier_Money where Order_ID= " + DgvSearch.CurrentRow.Cells[0].Value + " and Price=" + DgvSearch.CurrentRow.Cells[2].Value + "", "");
                            db.executedata("insert into Supplier_Report values(" + DgvSearch.CurrentRow.Cells[0].Value + "," + NudMiniQty.Value + ",N'" + d + "'," + cpxSuppliers.SelectedValue + ") ", "تم التسديد بنجاح");
                            tr.TrackerInsert("تسديد الموردين", "تسديد كامل", DgvSearch.CurrentRow.Cells[1].Value.ToString());
                            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudMiniQty.Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات الى موردين',N'') ", "");

                            db.executedata("update Stock set Money=Money - " + NudMiniQty.Value + " where Stock_ID=" + Stock_ID + "  ", "");
                            DataTable empty = new DataTable(); empty.Clear(); DgvSearch.DataSource = empty;

                        }

                    }
                }
            }

            //if (rbtnPayAll.Checked == true)
            //{
            //    db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + DgvSearch.CurrentRow.Cells[2].Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات الى موردين',N'') ", "");

            //    db.executedata("update Stock set Money=Money - " + DgvSearch.CurrentRow.Cells[2].Value + " where Stock_ID=" + Stock_ID + "  ", "");
            //}

            //if (rbtnPayPart.Checked == true)
            //{
            //    db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudMiniQty.Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات الى موردين',N'') ", "");

            //    db.executedata("update Stock set Money=Money - " + NudMiniQty.Value + " where Stock_ID=" + Stock_ID + "  ", "");
            //}

        }

       private void PrintOneSupplier()
        {
            // the same order id of the order 

            int id = Convert.ToInt32(cpxSuppliers.SelectedValue);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,suppliers.Sup_Name as 'اسم المورد',[Price] as 'المبلغ',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Supplier_Money],[Suppliers] where suppliers.Sup_ID=Supplier_Money.Sup_ID and [Suppliers].Sup_ID=" + id + "", "");

            frm_Printing frm = new frm_Printing();

            RptSupllierMoney rpt = new RptSupllierMoney();

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rbtnOneSup.Checked == true)
            {
                if (DgvSearch.Rows.Count >= 1)
                {
                    PrintOneSupplier();
                }
            }
        }
    }
}