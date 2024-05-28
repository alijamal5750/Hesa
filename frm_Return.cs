using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System.Diagnostics;
namespace Sales_Management
{
    public partial class frm_Return : DevExpress.XtraEditors.XtraForm
    {


        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

        public frm_Return()
        {
            InitializeComponent();
        }
        string Stock_ID = "";
        private void frm_Return_Load(object sender, EventArgs e)
        {
            Stock_ID = Convert.ToString(Properties.Settings.Default.Stock_ID);
            FillStore();
            DtpDate.Text = DateTime.Now.ToShortDateString();
            tbl.Clear();
            DgvSearch.DataSource = tbl;
            txtName1.Clear();
            txtName2.Clear();
            txtTotalOrder.Clear();
            txtMadfou3.Clear();
            txtBaky.Clear();
            txtID.Clear();
            txtTotalTex.Clear();
            txtTotalOrderAfterTex.Clear();
        }

        private void rbtnSales_CheckedChanged(object sender, EventArgs e)
        {
            lblName1.Text = "اسم العميل:";
            lblName2.Text = "اسم العميل:";
        }

        private void rbtnBuy_CheckedChanged(object sender, EventArgs e)
        {
            lblName1.Text = "اسم المورد:";
            lblName2.Text = "اسم المورد:";
        }


        private void FillStore()
        {
            CpxStore1.DataSource = db.readData("select * from Store", "");
            CpxStore1.DisplayMember = "Store_Name";
            CpxStore1.ValueMember = "Store_ID";

            cpxStore2.DataSource = db.readData("select * from Store", "");
            cpxStore2.DisplayMember = "Store_Name";
            cpxStore2.ValueMember = "Store_ID";
        }
        // when press sales return 
        private void salesReturn()
        {
            try
            {   
                tbl.Clear();
                txtMadfou3.Clear();
                txtTotalOrder.Clear();
                txtBaky.Clear();
                tbl = db.readData(" SELECT [Order_ID] as 'رقم الفاتورة' ,[Cust_Name] as 'اسم العميل',Products.Pro_Name as 'اسم المنتج' ,[Date] as 'تاريخ الفاتورة' ,[Sales_Details].[Qty] as 'الكمية' ,[Price_Tax] as 'السعر بعد الضريبة'  ,([Sales_Details].[Tax_Value] * [Sales_Details] .Qty)   as 'الضريبة',[Price] as 'السعر قبل الضريبة',[Discount] as 'الخصم' ,[Total] as 'اجمالي المنتج',[User_Name] as 'الكاشير',[TotalOrder] as 'اجمالي الفاتورة' ,[Madfou3] as 'السعر المدفوع' ,[Baky] as 'السعر المتبقي',[Unit] as 'الوحدة' FROM [Sales_System].[dbo].[Sales_Details],[Products] where Products.Pro_ID=Sales_Details.Pro_ID and Order_ID=" + txtID.Text + " ORDER BY Order_ID ASC", "");
                DgvSearch.DataSource = tbl;


                // fot total order by price
                // total orrder its before adding taxes ! 
                
                decimal TotalOrder = 0;
                decimal TotalMadfou3 = 0;
                decimal Baky = 0;
                decimal taxvalue = 0;
                decimal totalAfterTax = 0;

                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalOrder += Convert.ToDecimal(DgvSearch.Rows[i].Cells[9].Value) - Convert.ToDecimal(DgvSearch.Rows[i].Cells[6].Value);
                    taxvalue =Convert.ToDecimal(DgvSearch.Rows[i].Cells[6].Value);
                    totalAfterTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[9].Value);
                }
                    txtTotalOrder.Text = Math.Round(TotalOrder, 3).ToString();
                TotalMadfou3 = Convert.ToDecimal(DgvSearch.Rows[0].Cells[12].Value);
                txtMadfou3.Text = Math.Round(TotalMadfou3, 3).ToString();
                Baky = totalAfterTax - TotalMadfou3;
                txtBaky.Text=Math.Round(Baky,3).ToString();
                txtTotalTex.Text = Math.Round(taxvalue,2).ToString();
                txtTotalOrderAfterTex.Text = Math.Round(totalAfterTax,2).ToString();
            }
            catch (Exception) { }
        }

        // when press buy return
        private void buysReturn()
        {
            try
            {
                tbl.Clear();
                txtMadfou3.Clear();
                txtTotalOrder.Clear();
                txtBaky.Clear();
                tbl = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',suppliers.Sup_Name as 'اسم المورد',products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Destails].[Qty] as 'الكمية',[Unit_Name] as 'الوحدة' ,[User_Name] as 'اسم المستخدم',[Price] as 'السعر قبل الضريبة',([Buy_Destails].[Tax_Value] * [Buy_Destails] .Qty)as 'قيمة الضريبة',[Price_Tax] as 'السعر بعد الضريبة' ,[Discount] as 'الخصم',[Total] as 'سعر المنتج الاجمالي',[TotalOrder] as 'السعر الاجمالي للفاتورة',[Madfou3] as 'المبلغ المدفوع',[Baky] as 'المبلغ المتبقي', [Unit_Name] as 'الوحدة'  FROM [Sales_System].[dbo].[Buy_Destails],[Suppliers],[Products]  where suppliers.Sup_ID =Buy_Destails.Sup_ID and Products.Pro_ID=Buy_Destails.Pro_ID and Order_ID=" + txtID.Text + " ORDER BY Order_ID ASC", "");
                DgvSearch.DataSource = tbl;


                // fot total order by price
                // total orrder its before adding taxes ! 

                decimal TotalOrder = 0;
                decimal TotalMadfou3 = 0;
                decimal Baky = 0;
                decimal taxvalue = 0;
                decimal totalAfterTax = 0;

                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                    TotalOrder += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value) - Convert.ToDecimal(DgvSearch.Rows[i].Cells[8].Value);
                    taxvalue = Convert.ToDecimal(DgvSearch.Rows[i].Cells[8].Value);
                    totalAfterTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[11].Value);
                }
                txtTotalOrder.Text = Math.Round(TotalOrder, 3).ToString();
                TotalMadfou3 = Convert.ToDecimal(DgvSearch.Rows[0].Cells[13].Value);
                txtMadfou3.Text = Math.Round(TotalMadfou3, 3).ToString();
                Baky = totalAfterTax - TotalMadfou3;
                txtBaky.Text = Math.Round(Baky, 3).ToString();
                txtTotalTex.Text = Math.Round(taxvalue, 2).ToString();
                txtTotalOrderAfterTex.Text = Math.Round(totalAfterTax, 2).ToString();
            }
            catch (Exception) { }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if(!char.IsDigit(e.KeyChar) && e.KeyChar !=8)
            {
            e.Handled=true;
            }

            if (e.KeyChar == 13)
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل رقم فاتورة","تأكيد",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                if (rbtnSales.Checked == true)
                {
                    salesReturn();
                }

                else if (rbtnBuy.Checked == true)
                {
                    buysReturn();
                }
            }
        }

        // to return all sales 
        private void ReturnAllSales()
        {  
            string d=DtpDate.Value.ToString("dd/MM/yyyy");

            DataTable tblstock = new DataTable();
            tblstock.Clear();
            tblstock = db.readData("select * from Stock where Stock_ID="+Stock_ID+"","");
            Decimal stock_money = Convert.ToDecimal(tblstock.Rows[0][1]);

            if (Convert.ToDecimal(txtTotalOrderAfterTex.Text) > stock_money)
            {
                MessageBox.Show("مبلغ الفاتورة اكبر من المبلغ الموجود في الخزنة !");
                return;
            }

            if (txtName1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم العميل","تأكيد"); return;
            }

            db.executedata("delete from Sales where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + "", "");

            //// we have cascade relation between sales and sales_details but this is for to be sure all things goes right !
            db.executedata("delete from Sales_Details where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + "", "");

            //// and delete it from Rb7h table cuz the order was deleted frm the source ! 
            db.executedata("delete from Sales_Rb7h where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + "", "");

            // Delete from the cust_money and cust_Report : 
            db.executedata("delete from Customer_Money where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value+" ","");
            db.executedata("delete from Customer_Report where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " ", "");

            // add the deleted order to the Return table to display it in the Return form ! IFNORAMTION ADDED TO THE TABLE (DATE,TYPE) CUZ THE ORDER_ID IN THE TABLE WAS AUTO GENERATE ENCREMANT BY 1 ;;
            db.executedata("insert into Returns (Order_Date,Order_Type) values (N'"+d+"',N'مرتجعات مبيعات')","");

            // add the order details to the return_details table 

            // to bring me the max or last Order_ID from Return table
            int id = 1;
            id = Convert.ToInt32(db.readData("select max(Order_ID) from Returns", "").Rows[0][0]);
            decimal TotalTax = 0;
            try
            {
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {
                   
                    // to insert into reurnt_details table and return Qty to the products
                    db.executedata("insert into Returns_Details values (" + id + ",N'',N'" + txtName1.Text + "',N'" + DgvSearch.Rows[i].Cells[2].Value + "',N'" + d + "'," + DgvSearch.Rows[i].Cells[4].Value + "," + DgvSearch.Rows[i].Cells[7].Value + "," + DgvSearch.Rows[i].Cells[9].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + txtTotalOrderAfterTex.Text + "," + txtMadfou3.Text + "," + txtBaky.Text + "," + txtTotalTex.Text + "," + DgvSearch.Rows[i].Cells[5].Value + ",N'" + DgvSearch.Rows[i].Cells[14].Value + "') ", "");

                   
                  

                     int   proID = Convert.ToInt32(db.readData("select Pro_ID from Products where Pro_Name=N'"+DgvSearch.Rows[i].Cells[2].Value+"' ","").Rows[0][0]);

                   
                    
                    DataTable tblunit = new DataTable();

                    tblunit = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.Rows[i].Cells[14].Value + "'  ", "");

                    decimal realQty = 0;
                    decimal QtyInMain = 0;
                    
                    try
                    {

                        QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
                    }
                    catch (Exception) { }


                     realQty = Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value) / QtyInMain;

                     db.executedata("update Products set Qty=Qty + " + realQty + " where Pro_ID=" + proID + " ", "");
                    // add validation if the qty in nudqty is bigger that the actual qty in the table of each store that saved into ! 

                     DataTable tblQty = new DataTable();
                     tblQty.Clear();

                     tblQty = db.readData("select top 1 * from Products_Qty where Pro_ID="+proID+" and Store_ID="+CpxStore1.SelectedValue+"", "");

                     if (tblQty.Rows.Count >= 1)
                     {
                         db.executedata("update Products_Qty set Qty=Qty + " + realQty + " where Pro_ID=" + proID + " and Store_ID=" + CpxStore1.SelectedValue + " and Qty=" + tblQty.Rows[0][3] + " and Buy_Price=" + tblQty.Rows[0][4] + "", "");
                     }

                     else
                     {
                         DataTable tblQt = new DataTable();
                         // the tblqty to select the buy price from any store by the id of the product if there is any info for it ! 
                         tblQt.Clear();

                         tblQt = db.readData("select top 1 * from Products_Qty where Pro_ID=" + proID + " ", "");

                         if (tblQt.Rows.Count >= 1)
                     {
                         db.executedata("insert into Products_Qty values (" + proID + "," + CpxStore1.SelectedValue + ",N'" + CpxStore1.Text + "'," + realQty + "," + tblQt.Rows[0][4] + "," + DgvSearch.Rows[i].Cells[5].Value + ") ", "");
                     }
                         // if there are no prices (buy price) in any store so we need to enter the price from the user manually ! 
                         else 
                     {
                         string buyprice = Microsoft.VisualBasic.Interaction.InputBox("ادخل سعر للمنتج" + (DgvSearch.Rows[i].Cells[2].Value), "سعر الشراء", "من فضلك ادخل السعر هنا", 1, 1);
                         db.executedata("insert into Products_Qty values (" + proID + "," + CpxStore1.SelectedValue + ",N'" + CpxStore1.Text + "'," + realQty + "," + buyprice + "," + DgvSearch.Rows[i].Cells[5].Value + ") ", "");
                     }
                         }

                    TotalTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[6].Value);

                    }

             

                decimal totalBeforeTax = 0;
                totalBeforeTax = Convert.ToDecimal(txtTotalOrderAfterTex.Text) - TotalTax;
                db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + DgvSearch.CurrentRow.Cells[0].Value + ",N'فاتورة مرتجعات مبيعات',N'قيمة مضافة',N'لايوجد',N'"+txtName1.Text+"'," + totalBeforeTax + "," + TotalTax + "," + txtTotalOrderAfterTex.Text + ",N'" + d + "') ", "");

                db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + txtTotalOrderAfterTex.Text + ",N'" + d + "',N'"+Properties.Settings.Default.Defualt_USERNAME+"',N'مرتجعات مبيعات',N'') ", "");

                db.executedata("update Stock set Money=Money - " + txtTotalOrderAfterTex.Text + " where Stock_ID=" + Stock_ID + "  ", "");
            }
            catch (Exception) { }

            MessageBox.Show("تم ارجاع الفاتورة بنجاح !", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tr.TrackerInsert("شاشة المرتجعات", "ارجاع كامل مبيعات , رقم الفاتورة",DgvSearch.CurrentRow.Cells[0].Value.ToString());

            frm_Return_Load(null, null);
        }

        // to return all buys 
        private void ReturnAllBuy()
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            if (txtName1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المورد", "تأكيد"); return;
            }

            db.executedata("delete from Buy where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + "", "");

            // we have cascade relation between sales and sales_details but this is for to be sure all things goes right !
            db.executedata("delete from Buy_Destails where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + "", "");

            // Delete from sub_money and Sub_Report : 
            db.executedata("delete from Supplier_Money where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value+" ","");
            db.executedata("delete from Supplier_Report where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " ", "");

            // add the deleted order to the Return table to display it in the Return form ! IFNORAMTION ADDED TO THE TABLE (DATE,TYPE) CUZ THE ORDER_ID IN THE TABLE WAS AUTO GENERATE ENCREMANT BY 1 ;;
            db.executedata("insert into Returns (Order_Date,Order_Type) values (N'" + d + "',N'مرتجعات مشتريات')", "");

            // add the order details to the return_details table 

            // to bring me the max or last Order_ID from Return table
            int id = 1;
            id = Convert.ToInt32(db.readData("select max(Order_ID) from Returns", "").Rows[0][0]);

            decimal TotalTax = 0;

            try
            {
                for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                {

                    // to insert into reurnt_details table and return Qty to the products
                    db.executedata("insert into Returns_Details values (" + id + ",N'" + txtName1.Text + "',N'',N'" + DgvSearch.Rows[i].Cells[2].Value + "',N'" + d + "'," + DgvSearch.Rows[i].Cells[4].Value + "," + DgvSearch.Rows[i].Cells[7].Value + "," + DgvSearch.Rows[i].Cells[11].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + txtTotalOrderAfterTex.Text + "," + txtMadfou3.Text + "," + txtBaky.Text + "," + txtTotalTex.Text + "," + DgvSearch.Rows[i].Cells[9].Value + ",N'" + DgvSearch.Rows[i].Cells[15].Value + "') ", "");
                    int proID = 1;
                    try
                    {
                        // to pring the Pro_ID cuz it is best than the name 
                        

                        proID = Convert.ToInt32(db.readData("select Pro_ID from Products where Pro_Name=N'" + DgvSearch.Rows[i].Cells[2].Value + "' ", "").Rows[0][0]);

                        
                    }
                    catch (Exception) { }

                    DataTable tblunit = new DataTable();

                    tblunit = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.Rows[i].Cells[15].Value + "'  ", "");

                    decimal realQty = 0;
                    decimal QtyInMain = 0;

                    try
                    {

                        QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
                    }
                    catch (Exception) { }


                    realQty = Convert.ToDecimal(DgvSearch.Rows[i].Cells[4].Value) / QtyInMain;

                    db.executedata("update Products set Qty=Qty - " + realQty + " where Pro_ID=" + proID + " ", "");

                    DataTable tblQty = new DataTable();
                    tblQty.Clear();
                    tblQty = db.readData("select * from Products_Qty where Pro_ID="+proID+" and Store_ID="+CpxStore1.SelectedValue+"", "");
                    decimal def = 0;
                    def=Convert.ToDecimal(tblQty.Rows[0][3]) - realQty; 
                    if (def < 0) { MessageBox.Show("الكمية المراد ارجاعها غير موجودة في المخزن"); return; }
                    else
                    {
                        db.executedata("update Products_Qty set Qty=Qty - " + realQty + " where Pro_ID=" + proID + " and Store_ID=" + CpxStore1.SelectedValue + " and Qty=" + tblQty.Rows[0][3] + " and Buy_Price=" + tblQty.Rows[0][4] + "", "");
                    }

                    TotalTax += Convert.ToDecimal(DgvSearch.Rows[i].Cells[8].Value);
                }
            }
            catch (Exception) { }

            decimal totalBeforeTax = 0;
            totalBeforeTax = Convert.ToDecimal(txtTotalOrderAfterTex.Text) - TotalTax;
            db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + DgvSearch.CurrentRow.Cells[0].Value + ",N'فاتورة مرتجعات مشتريات',N'قيمة مضافة',N'"+txtName1.Text+"',N'لايوجد'," + totalBeforeTax + "," + TotalTax + "," + txtTotalOrderAfterTex.Text + ",N'" + d + "') ", "");

            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + txtTotalOrderAfterTex.Text + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مرتجعات مشتريات',N'') ", "");

            db.executedata("update Stock set Money=Money + " + txtTotalOrderAfterTex.Text + " where Stock_ID=" + Stock_ID + "  ", "");

            MessageBox.Show("تم ارجاع الفاتورة بنجاح !", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tr.TrackerInsert("شاشة المرتجعات", "ارجاع كامل مشتريات , رقم الفاتورة", DgvSearch.CurrentRow.Cells[0].Value.ToString());
            frm_Return_Load(null, null);
        }

        private void btnReturnAll_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                if (rbtnSales.Checked == true)
                {
                    ReturnAllSales();
                }

                else if (rbtnBuy.Checked == true)
                {
                    ReturnAllBuy();
                }
            }
        }

        // when user press return item only for sales 
        private void returnItemSaleOnly()
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            DataTable tblstock = new DataTable();
            tblstock.Clear();
            tblstock = db.readData("select * from Stock where Stock_ID=" + Stock_ID + "", "");
            Decimal stock_money = Convert.ToDecimal(tblstock.Rows[0][1]);

            if (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[9].Value) > stock_money)
            {
                MessageBox.Show("مبلغ الفاتورة اكبر من المبلغ الموجود في الخزنة !");
                return;
            }

            if (txtName2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم العميل", "تأكيد"); return;
            }

            int proID = Convert.ToInt32(db.readData("select Pro_ID from Products where Pro_Name=N'" + DgvSearch.CurrentRow.Cells[2].Value + "' ", "").Rows[0][0]);

            //// we have cascade relation between sales and sales_details but this is for to be sure all things goes right !
            db.executedata("delete from Sales_Details where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Pro_ID="+proID+" and Qty="+DgvSearch.CurrentRow.Cells[4].Value+" and Total="+DgvSearch.CurrentRow.Cells[9].Value+" ", "");

            //// and delete it from Rb7h table cuz the order was deleted frm the source ! 
            db.executedata("delete from Sales_Rb7h where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Pro_ID=" + proID + " and Qty=" + DgvSearch.CurrentRow.Cells[4].Value + " and Total=" + DgvSearch.CurrentRow.Cells[8].Value + "", "");

            // add the deleted order to the Return table to display it in the Return form ! IFNORAMTION ADDED TO THE TABLE (DATE,TYPE) CUZ THE ORDER_ID IN THE TABLE WAS AUTO GENERATE ENCREMANT BY 1 ;;
            db.executedata("insert into Returns (Order_Date,Order_Type) values (N'" + d + "',N'مرتجعات مبيعات')", "");

            // add the order details to the return_details table 

            // to bring me the max or last Order_ID from Return table
            int id = 1;
            id = Convert.ToInt32(db.readData("select max(Order_ID) from Returns", "").Rows[0][0]);

            try
            {
                    // to insert into reurnt_details table and return Qty to the products
                db.executedata("insert into Returns_Details values (" + id + ",N'',N'" + txtName2.Text + "',N'" + DgvSearch.CurrentRow.Cells[2].Value + "',N'" + d + "'," + DgvSearch.CurrentRow.Cells[4].Value + "," + DgvSearch.CurrentRow.Cells[7].Value + "," + DgvSearch.CurrentRow.Cells[9].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + txtTotalOrderAfterTex.Text + "," + txtMadfou3.Text + "," + txtBaky.Text + "," + txtTotalTex.Text + "," + DgvSearch.CurrentRow.Cells[5].Value + ",N'" + DgvSearch.CurrentRow.Cells[14].Value + "') ", "");

                    DataTable tblunit = new DataTable();

                    tblunit = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.CurrentRow.Cells[14].Value + "'  ", "");

                    decimal realQty = 0;
                    decimal QtyInMain = 0;
                   

                    try
                    {

                        QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
                    }
                    catch (Exception) { }


                    realQty = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value) / QtyInMain;

                    db.executedata("update Products set Qty=Qty + " + realQty + " where Pro_ID=" + proID + " ", "");
                    // add validation if the qty in nudqty is bigger that the actual qty in the table of each store that saved into ! 

                    DataTable tblQty = new DataTable();
                    tblQty.Clear();

                    tblQty = db.readData("select top 1 * from Products_Qty where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + "", "");

                    if (tblQty.Rows.Count >= 1)
                    {
                        db.executedata("update Products_Qty set Qty=Qty + " + realQty + " where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + " and Qty=" + tblQty.Rows[0][3] + " and Buy_Price=" + tblQty.Rows[0][4] + "", "");
                    }

                    else
                    {
                        DataTable tblQt = new DataTable();
                        // the tblqty to select the buy price from any store by the id of the product if there is any info for it ! 
                        tblQt.Clear();

                        tblQt = db.readData("select top 1 * from Products_Qty where Pro_ID=" + proID + " ", "");

                        if (tblQt.Rows.Count >= 1)
                        {
                            db.executedata("insert into Products_Qty values (" + proID + "," + cpxStore2.SelectedValue + ",N'" + cpxStore2.Text + "'," + realQty + "," + tblQt.Rows[0][4] + "," + DgvSearch.CurrentRow.Cells[5].Value + ") ", "");
                        }
                        // if there are no prices (buy price) in any store so we need to enter the price from the user manually ! 
                        else
                        {
                            string buyprice = Microsoft.VisualBasic.Interaction.InputBox("ادخل سعر للمنتج" + (DgvSearch.CurrentRow.Cells[2].Value), "سعر الشراء", "من فضلك ادخل السعر هنا", 1, 1);
                            db.executedata("insert into Products_Qty values (" + proID + "," + cpxStore2.SelectedValue + ",N'" + cpxStore2.Text + "'," + realQty + "," + buyprice + "," + DgvSearch.CurrentRow.Cells[5].Value + ") ", "");
                        }


                    }
            }
            catch (Exception) { }

           
            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + DgvSearch.CurrentRow.Cells[9].Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مرتجعات مبيعات',N'') ", "");

            db.executedata("update Stock set Money=Money - " + DgvSearch.CurrentRow.Cells[9].Value + " where Stock_ID=" + Stock_ID + "  ", "");

            decimal TotalTax = 0;
            TotalTax = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[6].Value);
            decimal totalBeforeTax = 0;
            decimal totalitem = 0;

            totalitem = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value) * Convert.ToDecimal(DgvSearch.CurrentRow.Cells[5].Value);
            totalBeforeTax = totalitem - TotalTax;
            db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + DgvSearch.CurrentRow.Cells[0].Value + ",N'فاتورة مرتجعات مبيعات',N'قيمة مضافة',N'لايوجد',N'" + txtName2.Text + "'," + totalBeforeTax + "," + TotalTax + "," + totalitem + ",N'" + d + "') ", "");

            MessageBox.Show("تم بنجاح!");
            tr.TrackerInsert("شاشة المرتجعات", "ارجاع منتج مبيعات , رقم الفاتورة", DgvSearch.CurrentRow.Cells[0].Value.ToString());
            frm_Return_Load(null,null);
        }

        private void returnItemBuyOnly()
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            if (txtName2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المورد", "تأكيد"); return;
            }

            // to pring the Pro_ID cuz it is best than the name 
           int proID = Convert.ToInt32(db.readData("select Pro_ID from Products where Pro_Name=N'" + DgvSearch.CurrentRow.Cells[2].Value + "'", "").Rows[0][0]);

            // we have cascade relation between sales and sales_details but this is for to be sure all things goes right !
           db.executedata("delete from Buy_Destails where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Pro_ID=" + proID + " and Qty=" + DgvSearch.CurrentRow.Cells[4].Value + " and Total=" + DgvSearch.CurrentRow.Cells[11].Value + "", "");


            // add the deleted order to the Return table to display it in the Return form ! IFNORAMTION ADDED TO THE TABLE (DATE,TYPE) CUZ THE ORDER_ID IN THE TABLE WAS AUTO GENERATE ENCREMANT BY 1 ;;
            db.executedata("insert into Returns (Order_Date,Order_Type) values (N'" + d + "',N'مرتجعات مشتريات')", "");

            // add the order details to the return_details table 

            // to bring me the max or last Order_ID from Return table
            int id = 1;
            id = Convert.ToInt32(db.readData("select max(Order_ID) from Returns", "").Rows[0][0]);

            try
            {
               

                    // to insert into reurnt_details table and return Qty to the products
                db.executedata("insert into Returns_Details values (" + id + ",N'" + txtName2.Text + "',N'',N'" + DgvSearch.CurrentRow.Cells[2].Value + "',N'" + d + "'," + DgvSearch.CurrentRow.Cells[4].Value + "," + DgvSearch.CurrentRow.Cells[7].Value + "," + DgvSearch.CurrentRow.Cells[11].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + txtTotalOrderAfterTex.Text + "," + txtMadfou3.Text + "," + txtBaky.Text + "," + txtTotalTex.Text + "," + DgvSearch.CurrentRow.Cells[9].Value + ",N'" + DgvSearch.CurrentRow.Cells[15].Value + "') ", "");
                    
                    try
                    {
                        // to pring the Pro_ID cuz it is best than the name 


                       


                    }
                    catch (Exception) { }

                    DataTable tblunit = new DataTable();

                    tblunit = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.CurrentRow.Cells[15].Value + "'  ", "");

                    decimal realQty = 0;
                    decimal QtyInMain = 0;

                    try
                    {

                        QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
                    }
                    catch (Exception) { }


                    realQty = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value) / QtyInMain;

                    db.executedata("update Products set Qty=Qty - " + realQty + " where Pro_ID=" + proID + " ", "");

                    DataTable tblQty = new DataTable();
                    tblQty.Clear();
                    tblQty = db.readData("select * from Products_Qty where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + "", "");
                    decimal def = 0;
                    def = Convert.ToDecimal(tblQty.Rows[0][3]) - realQty;
                    if (def < 0) { MessageBox.Show("الكمية المراد ارجاعها غير موجودة في المخزن"); return; }
                    else
                    {
                        db.executedata("update Products_Qty set Qty=Qty - " + realQty + " where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + " and Qty=" + tblQty.Rows[0][3] + " and Buy_Price=" + tblQty.Rows[0][4] + "", "");
                    }
                
            }
            catch (Exception) { }


            decimal TotalTax = 0;
            TotalTax = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[8].Value);
            decimal totalBeforeTax = 0;
            decimal totalitem = 0;

            totalitem = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value) * Convert.ToDecimal(DgvSearch.CurrentRow.Cells[9].Value);
            totalBeforeTax = totalitem - TotalTax;
            db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + DgvSearch.CurrentRow.Cells[0].Value + ",N'فاتورة مرتجعات مشتريات',N'قيمة مضافة',N'"+txtName2.Text+"',N'لايوجد'," + totalBeforeTax + "," + TotalTax + "," +totalitem + ",N'" + d + "') ", "");

            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + DgvSearch.CurrentRow.Cells[11].Value + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مرتجعات مشتريات',N'') ", "");

            db.executedata("update Stock set Money=Money + " + DgvSearch.CurrentRow.Cells[11].Value + " where Stock_ID=" + Stock_ID + "  ", "");

            MessageBox.Show("تم ارجاع الفاتورة بنجاح !", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tr.TrackerInsert("شاشة المرتجعات", "ارجاع منتج مشتريات , رقم الفاتورة", DgvSearch.CurrentRow.Cells[0].Value.ToString());
            frm_Return_Load(null, null);
        }


        private void returnQtySaleOnly()
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            DataTable tblstock = new DataTable();
            tblstock.Clear();
            tblstock = db.readData("select * from Stock where Stock_ID=" + Stock_ID + "", "");
            Decimal stock_money = Convert.ToDecimal(tblstock.Rows[0][1]);

            if ((Convert.ToDecimal(DgvSearch.CurrentRow.Cells[5].Value) * NudQty.Value) > stock_money)
            {
                MessageBox.Show("مبلغ الفاتورة اكبر من المبلغ الموجود في الخزنة !");
                return;
            }

            if (txtName2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم العميل", "تأكيد"); return;
            }

            int proID = Convert.ToInt32(db.readData("select Pro_ID from Products where Pro_Name=N'" + DgvSearch.CurrentRow.Cells[2].Value + "' ", "").Rows[0][0]);


            DataTable tblunit = new DataTable();

            tblunit = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.CurrentRow.Cells[14].Value + "'  ", "");

            decimal realQty = 0;
            decimal QtyInMain = 0;
            decimal realqt = 0;

            try
            {

                QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
            }
            catch (Exception) { }

            realqt = NudQty.Value;

            realQty = NudQty.Value / QtyInMain;

            if (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value) - NudQty.Value < 0)
            {
                MessageBox.Show("الكمية المراد ارجاعها اكبر من الكمية المتوفرة !");
                return;
            }

            //// we have cascade relation between sales and sales_details but this is for to be sure all things goes right !
            db.executedata("update Sales_Details set Qty=Qty - "+ realqt + " where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Pro_ID=" + proID + " and Qty=" + DgvSearch.CurrentRow.Cells[4].Value + " and Total=" + DgvSearch.CurrentRow.Cells[9].Value + " ", "");

            //// and delete it from Rb7h table cuz the order was deleted frm the source ! 
            db.executedata("update Sales_Rb7h set Qty=Qty - "+ realqt + " where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Pro_ID=" + proID + " and Qty=" + DgvSearch.CurrentRow.Cells[4].Value + " and Total=" + DgvSearch.CurrentRow.Cells[8].Value + "", "");

            // add the deleted order to the Return table to display it in the Return form ! IFNORAMTION ADDED TO THE TABLE (DATE,TYPE) CUZ THE ORDER_ID IN THE TABLE WAS AUTO GENERATE ENCREMANT BY 1 ;;
            db.executedata("insert into Returns (Order_Date,Order_Type) values (N'" + d + "',N'مرتجعات مبيعات')", "");

            // add the order details to the return_details table 

            // to bring me the max or last Order_ID from Return table
            int id = 1;
            id = Convert.ToInt32(db.readData("select max(Order_ID) from Returns", "").Rows[0][0]);

            try
            {
                // to insert into reurnt_details table and return Qty to the products
                db.executedata("insert into Returns_Details values (" + id + ",N'',N'" + txtName2.Text + "',N'" + DgvSearch.CurrentRow.Cells[2].Value + "',N'" + d + "'," + realqt + "," + DgvSearch.CurrentRow.Cells[7].Value + "," + DgvSearch.CurrentRow.Cells[9].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + txtTotalOrderAfterTex.Text + "," + txtMadfou3.Text + "," + txtBaky.Text + "," + txtTotalTex.Text + "," + DgvSearch.CurrentRow.Cells[5].Value + ",N'" + DgvSearch.CurrentRow.Cells[14].Value + "') ", "");

                

                db.executedata("update Products set Qty=Qty + " + realQty + " where Pro_ID=" + proID + " ", "");
                // add validation if the qty in nudqty is bigger that the actual qty in the table of each store that saved into ! 

                DataTable tblQty = new DataTable();
                tblQty.Clear();

                tblQty = db.readData("select top 1 * from Products_Qty where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + "", "");

                if (tblQty.Rows.Count >= 1)
                {
                    db.executedata("update Products_Qty set Qty=Qty + " + realQty + " where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + " and Qty=" + tblQty.Rows[0][3] + " and Buy_Price=" + tblQty.Rows[0][4] + "", "");
                }

                else
                {
                    DataTable tblQt = new DataTable();
                    // the tblqty to select the buy price from any store by the id of the product if there is any info for it ! 
                    tblQt.Clear();

                    tblQt = db.readData("select top 1 * from Products_Qty where Pro_ID=" + proID + " ", "");

                    if (tblQt.Rows.Count >= 1)
                    {
                        db.executedata("insert into Products_Qty values (" + proID + "," + cpxStore2.SelectedValue + ",N'" + cpxStore2.Text + "'," + realQty + "," + tblQt.Rows[0][4] + "," + DgvSearch.CurrentRow.Cells[5].Value + ") ", "");
                    }
                    // if there are no prices (buy price) in any store so we need to enter the price from the user manually ! 
                    else
                    {
                        string buyprice = Microsoft.VisualBasic.Interaction.InputBox("ادخل سعر للمنتج" + (DgvSearch.CurrentRow.Cells[2].Value), "سعر الشراء", "من فضلك ادخل السعر هنا", 1, 1);
                        db.executedata("insert into Products_Qty values (" + proID + "," + cpxStore2.SelectedValue + ",N'" + cpxStore2.Text + "'," + realQty + "," + buyprice + "," + DgvSearch.CurrentRow.Cells[5].Value + ") ", "");
                    }
                }
            }
            catch (Exception) { }

            decimal TotalTax = 0;
        
            decimal itemtax = 0;
            decimal totalBeforeTax = 0;
            decimal totalitem = 0;
            
            // give me tax for single item ! 
            itemtax = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[6].Value) / Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value);

            TotalTax = itemtax * NudQty.Value;

            totalitem = NudQty.Value * Convert.ToDecimal(DgvSearch.CurrentRow.Cells[5].Value);
            totalBeforeTax = totalitem - TotalTax;
            db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + DgvSearch.CurrentRow.Cells[0].Value + ",N'فاتورة مرتجعات مبيعات',N'قيمة مضافة',N'لايوجد',N'" + txtName2.Text + "'," + totalBeforeTax + "," + TotalTax + "," + totalitem + ",N'" + d + "') ", "");

            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[5].Value) * NudQty.Value) + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مرتجعات مبيعات',N'') ", "");

            db.executedata("update Stock set Money=Money - " + (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[5].Value) * NudQty.Value) + " where Stock_ID=" + Stock_ID + "  ", "");

            MessageBox.Show("تم بنجاح!");
            tr.TrackerInsert("شاشة المرتجعات", "ارجاع كمية منتج مبيعات , رقم الفاتورة", DgvSearch.CurrentRow.Cells[0].Value.ToString());
            frm_Return_Load(null, null);
        }



        private void returnQtyBuyOnly()
        {
            string d = DtpDate.Value.ToString("dd/MM/yyyy");

            if (txtName2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المورد", "تأكيد"); return;
            }

            // to pring the Pro_ID cuz it is best than the name 
            int proID = Convert.ToInt32(db.readData("select Pro_ID from Products where Pro_Name=N'" + DgvSearch.CurrentRow.Cells[2].Value + "'", "").Rows[0][0]);

            DataTable tblunit = new DataTable();

            tblunit = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.CurrentRow.Cells[15].Value + "'  ", "");

            decimal realQty = 0;
            decimal QtyInMain = 0;

            try
            {

                QtyInMain = Convert.ToDecimal(tblunit.Rows[0][3]);
            }
            catch (Exception) { }


            realQty = NudQty.Value;

            if (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value) - NudQty.Value < 0)
            {
                MessageBox.Show("الكمية المراد ارجاعها اكبر من الكمية المتوفرة !");
                return;
            }

            //// we have cascade relation between sales and sales_details but this is for to be sure all things goes right !
            db.executedata("update Buy_Destails set Qty=Qty - " + realQty + " where Order_ID=" + DgvSearch.CurrentRow.Cells[0].Value + " and Pro_ID=" + proID + " and Qty=" + DgvSearch.CurrentRow.Cells[4].Value + " and Total=" + DgvSearch.CurrentRow.Cells[11].Value + " ", "");


            // add the deleted order to the Return table to display it in the Return form ! IFNORAMTION ADDED TO THE TABLE (DATE,TYPE) CUZ THE ORDER_ID IN THE TABLE WAS AUTO GENERATE ENCREMANT BY 1 ;;
            db.executedata("insert into Returns (Order_Date,Order_Type) values (N'" + d + "',N'مرتجعات مشتريات')", "");

            // add the order details to the return_details table 

            // to bring me the max or last Order_ID from Return table
            int id = 1;
            id = Convert.ToInt32(db.readData("select max(Order_ID) from Returns", "").Rows[0][0]);

            try
            {


                // to insert into reurnt_details table and return Qty to the products
                db.executedata("insert into Returns_Details values (" + id + ",N'" + txtName2.Text + "',N'',N'" + DgvSearch.CurrentRow.Cells[2].Value + "',N'" + d + "'," + realQty + "," + DgvSearch.CurrentRow.Cells[7].Value + "," + DgvSearch.CurrentRow.Cells[11].Value + ",N'" + Properties.Settings.Default.Defualt_USERNAME + "'," + txtTotalOrderAfterTex.Text + "," + txtMadfou3.Text + "," + txtBaky.Text + "," + txtTotalTex.Text + "," + DgvSearch.CurrentRow.Cells[9].Value + ",N'" + DgvSearch.CurrentRow.Cells[15].Value + "') ", "");

                try
                {
                    // to pring the Pro_ID cuz it is best than the name 





                }
                catch (Exception) { }

                DataTable tblunit2 = new DataTable();

                tblunit2 = db.readData("select * from Products_Unit where Pro_ID=" + proID + " and Unit_Name=N'" + DgvSearch.CurrentRow.Cells[15].Value + "'  ", "");

                decimal realQtyy = 0;
                decimal QtyInMainn = 0;

                try
                {

                    QtyInMainn = Convert.ToDecimal(tblunit2.Rows[0][3]);
                }
                catch (Exception) { }


                realQtyy = NudQty.Value / QtyInMainn;

                db.executedata("update Products set Qty=Qty - " + realQtyy + " where Pro_ID=" + proID + " ", "");

                DataTable tblQty = new DataTable();
                tblQty.Clear();
                tblQty = db.readData("select * from Products_Qty where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + "", "");
                decimal def = 0;
                def = Convert.ToDecimal(tblQty.Rows[0][3]) - realQtyy;
                if (def < 0) { MessageBox.Show("الكمية المراد ارجاعها غير موجودة في المخزن"); return; }
                else
                {
                    db.executedata("update Products_Qty set Qty=Qty - " + realQtyy + " where Pro_ID=" + proID + " and Store_ID=" + cpxStore2.SelectedValue + " and Qty=" + tblQty.Rows[0][3] + " and Buy_Price=" + tblQty.Rows[0][4] + "", "");
                }

            }
            catch (Exception) { }

            decimal TotalTax = 0;

            decimal itemtax = 0;
            decimal totalBeforeTax = 0;
            decimal totalitem = 0;

            // give me tax for single item ! 
            itemtax = Convert.ToDecimal(DgvSearch.CurrentRow.Cells[8].Value) / Convert.ToDecimal(DgvSearch.CurrentRow.Cells[4].Value);

            TotalTax = itemtax * NudQty.Value;

            totalitem = NudQty.Value * Convert.ToDecimal(DgvSearch.CurrentRow.Cells[9].Value);
            totalBeforeTax = totalitem - TotalTax;
            db.executedata("insert into Taxes_Report (Order_Num,Order_Type,Tax_Type,Sup_Name,Cust_Name,Total_Order,Total_Tax,Total_AfterTax,Date) values (" + DgvSearch.CurrentRow.Cells[0].Value + ",N'فاتورة مرتجعات مشتريات',N'قيمة مضافة',N'"+txtName2.Text+"',N'لايوجد'," + totalBeforeTax + "," + TotalTax + "," + totalitem + ",N'" + d + "') ", "");

            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + Stock_ID + "," + (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[9].Value) * NudQty.Value) + ",N'" + d + "',N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'مرتجعات مشتريات',N'') ", "");

            db.executedata("update Stock set Money=Money + " + (Convert.ToDecimal(DgvSearch.CurrentRow.Cells[9].Value) *NudQty.Value) + " where Stock_ID=" + Stock_ID + "  ", "");

            MessageBox.Show("تم ارجاع الفاتورة بنجاح !", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tr.TrackerInsert("شاشة المرتجعات", "ارجاع كمية منتج مشتريات , رقم الفاتورة", DgvSearch.CurrentRow.Cells[0].Value.ToString());
            frm_Return_Load(null, null);
        }

        private void btnReturnItemOnly_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {  

                // return item from list of items
                if (rbtnReturnItemOnly.Checked == true)
                {
                    if (rbtnSales.Checked == true)
                    {
                        returnItemSaleOnly();
                    }

                    else if (rbtnBuy.Checked == true)
                    {
                        returnItemBuyOnly();
                    }

                }
                       
                    // return part of the qty
                     if (rbtnReturnQtyOnly.Checked == true)
                    {
                        if (rbtnSales.Checked == true)
                        {
                            returnQtySaleOnly();
                        }

                        else if (rbtnBuy.Checked == true)
                        {
                            returnQtyBuyOnly();
                        }
                    }

                }
            }

        private void rbtnReturnItemOnly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=wS1bHj2GD60&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=8");
        }
    }
    }
