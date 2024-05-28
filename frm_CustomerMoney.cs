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
    public partial class frm_CustomerMoney : DevExpress.XtraEditors.XtraForm
    {
        string Stock_ID = "";
        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        private void FillCustomers()
        {
            cpxCustomers.DataSource = db.readData("select * from Customers", "");
            cpxCustomers.DisplayMember = "Cust_Name";
            cpxCustomers.ValueMember = "Cust_ID";
        }

        public frm_CustomerMoney()
        {
            InitializeComponent();
        }

        private void frm_CustomerMoney_Load(object sender, EventArgs e)
        {
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
            DtpDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                FillCustomers();
            }
            catch (Exception) { }

            //to fill the supplier_money table into datagridview
            tbl.Clear();
            tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust-Name] as 'اسم العميل',[Price] as 'السعر',[Order_Date] as 'تاريخ الفاتورة' ,[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Customer_Money]", "");
            DgvSearch.DataSource = tbl;

            rbtnAllCust.Checked = true;
            //for total textbox
            decimal TotalPrice = 0;
            for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
            {
                TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
            }
            txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbtnAllCust.Checked == true)
            {
                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust-Name] as 'اسم العميل',[Price] as 'السعر',[Order_Date] as 'تاريخ الفاتورة' ,[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Customer_Money]", "");
                DgvSearch.DataSource = tbl;

                //for total textbox
                decimal TotalPrice = 0;
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalPrice += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
                }
                txtTotal.Text = Math.Round(TotalPrice, 3).ToString();
            }

            else if (rbtnOneCust.Checked == true)
            {
                //to fill the supplier_money table into datagridview
                tbl.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust-Name] as 'اسم العميل',[Price] as 'السعر',[Order_Date] as 'تاريخ الفاتورة' ,[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Customer_Money] where [Cust-Name]=N'" + cpxCustomers.Text + "'", "");
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
           
                if (DgvSearch.Rows.Count >= 1)
                {
                    string d = DtpDate.Value.ToString("dd/MM/yyyy");

                    // for pay all

                    if (rbtnPayAll.Checked == true)
                    {
                        if (MessageBox.Show("هل انت متأكد من تسديد المبلغ بالكامل للعميل؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (rbtnAllCust.Checked == true) { MessageBox.Show("من فضلك حدد اسم عميل معين"); return; }

                            // for the price delete in where condition thats to make sure the price is deleted aslo from the table and move it to the price of the frm_supplier_report
                            db.readData("delete from Customer_Money where Order_ID= " + DgvSearch.CurrentRow.Cells[0].Value + " and Price=" + DgvSearch.CurrentRow.Cells[2].Value + "", "");
                            db.executedata("insert into Customer_Report values(" + DgvSearch.CurrentRow.Cells[0].Value + "," + DgvSearch.CurrentRow.Cells[2].Value + ",N'" + d + "',N'" + cpxCustomers.Text + "') ", "تم التسديد بنجاح");
                            tr.TrackerInsert("تسديد العملاء", "تسديد كامل", DgvSearch.CurrentRow.Cells[1].Value.ToString());

                        db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + DgvSearch.CurrentRow.Cells[2].Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات من عملاء',N'') ", "");

                        db.executedata("update Stock set Money=Money + " + DgvSearch.CurrentRow.Cells[2].Value + " where Stock_ID=" + Stock_ID + "  ", "");

                        DataTable empty = new DataTable(); empty.Clear(); DgvSearch.DataSource = empty;
                        }


                    }
                    // for pay part

                    else if (rbtnPayPart.Checked == true)
                    {
                        if (MessageBox.Show("هل انت متأكد من تسديد جزء من المبلغ للعميل؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (rbtnAllCust.Checked == true) { MessageBox.Show("من فضلك حدد اسم عميل معين"); return; }

                             if (NudMiniQty.Value > Convert.ToDecimal(DgvSearch.CurrentRow.Cells[2].Value))
                            {
                                MessageBox.Show("المبلغ المدفوع اكبر من مبلغ الفاتورة");
                                return;
                            }

                            decimal money = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[2].Value) - NudMiniQty.Value;

                              if (money > 0)
                            {
                                db.executedata("update Customer_Money set Price=" + money + " where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Price=" + DgvSearch.CurrentRow.Cells[2].Value + "", "");
                                db.executedata("insert into Customer_Report values(" + DgvSearch.CurrentRow.Cells[0].Value + "," + NudMiniQty.Value + ",N'" + d + "',N'" + cpxCustomers.Text + "') ", "تم التسديد بنجاح");
                                tr.TrackerInsert("تسديد العملاء", "تسديد جزئي", DgvSearch.CurrentRow.Cells[1].Value.ToString());

                            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudMiniQty.Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات من عملاء',N'') ", "");

                            db.executedata("update Stock set Money=Money + " + NudMiniQty.Value + " where Stock_ID=" + Stock_ID + "  ", "");

                            DataTable empty = new DataTable(); empty.Clear(); DgvSearch.DataSource = empty;
                            }
                             if (money == 0)
                            {
                                db.readData("delete from Customer_Money where Order_ID= " + DgvSearch.CurrentRow.Cells[0].Value + " and Price=" + DgvSearch.CurrentRow.Cells[2].Value + "", "");
                                db.executedata("insert into Customer_Report values(" + DgvSearch.CurrentRow.Cells[0].Value + "," + NudMiniQty.Value + ",N'" + d + "',N'" + cpxCustomers.Text + "') ", "تم التسديد بنجاح");
                                tr.TrackerInsert("تسديد العملاء", "تسديد كامل", DgvSearch.CurrentRow.Cells[1].Value.ToString());

                            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudMiniQty.Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات من عملاء',N'') ", "");

                            db.executedata("update Stock set Money=Money + " + NudMiniQty.Value + " where Stock_ID=" + Stock_ID + "  ", "");

                            DataTable empty = new DataTable(); empty.Clear(); DgvSearch.DataSource = empty;
                            }


                        }
                    }

                    // if (rbtnPayAll.Checked == true)
                    //{
                    //    db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + DgvSearch.CurrentRow.Cells[2].Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات من عملاء',N'') ", "");

                    //    db.executedata("update Stock set Money=Money + " + DgvSearch.CurrentRow.Cells[2].Value + " where Stock_ID=" + Stock_ID + "  ", "");
                    //}

                    // if (rbtnPayPart.Checked == true)
                    //{
                    //    db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + NudMiniQty.Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مستحقات من عملاء',N'') ", "");

                    //    db.executedata("update Stock set Money=Money + " + NudMiniQty.Value + " where Stock_ID=" + Stock_ID + "  ", "");
                    //}

                }
            
        }

        // for the 8 cm print one customer_order

        private void PrintOneSupplier()
        {
            // the same order id of the order 

            string Name =Convert.ToString (cpxCustomers.Text);

            DataTable tblRpt = new DataTable();

            tblRpt.Clear();

            // from the stored_procedure 
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust-Name] as 'اسم العميل',[Price] as 'السعر',[Order_Date] as 'تاريخ الفاتورة' ,[Reminder_Date] as 'تاريخ الاستحقاق'FROM [Sales_System].[dbo].[Customer_Money] where [Cust-Name]=N'"+Name+"'", "");

            frm_Printing frm = new frm_Printing();

            rpt_CustomerMoney rpt = new rpt_CustomerMoney();

            frm.crystalReportViewer1.RefreshReport();

            // for the server,database,username,password
            rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");

            rpt.SetDataSource(tblRpt);

            rpt.SetParameterValue("Name", Name);

            frm.crystalReportViewer1.ReportSource = rpt;

            // for the print to printers 
            //System.Drawing.Printing.PrintDocument PrintDocument = new System.Drawing.Printing.PrintDocument();

            //rpt.PrintOptions.PrinterName = PrintDocument.PrinterSettings.PrinterName;

            //rpt.PrintToPrinter(1,true,0,0);

            frm.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rbtnOneCust.Checked == true)
            {
                if (DgvSearch.Rows.Count >= 1)
                {
                    PrintOneSupplier();
                }
            }
        }
    }
}