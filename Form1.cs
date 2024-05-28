using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Smo;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System.Diagnostics;
namespace Sales_Management
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        tracker tr = new tracker();

        int USER_ID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Customer", "User_Customer");
                if (check == true)
                {
                    frm_Customer frm = new frm_Customer();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Supp_Data", "User_Supplier");
                if (check == true)
                {
                    frm_supplier frm = new frm_supplier();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Type", "User_Deserved");
                if (check == true)
                {
                    frm_Deserved frm = new frm_Deserved();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Des", "User_Deserved");
                if (check == true)
                {
                    frm_Deserve frm = new frm_Deserve();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Des_Report", "User_Deserved");
                if (check == true)
                {
                    frm_Deservereport frm = new frm_Deservereport();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Items_Add", "User_Settings");
                if (check == true)
                {
                    frm_products frm = new frm_products();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Buy", "User_Buy");
                if (check == true)
                {
                    frm_Buy frm = new frm_Buy();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Sup_Money", "User_Supplier");
                if (check == true)
                {
                    frm_SupplierMoney frm = new frm_SupplierMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Supp_Report", "User_Supplier");
                if (check == true)
                {
                    frm_SupplierReport frm = new frm_SupplierReport();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Buy_Report", "User_Buy");
                if (check == true)
                {
                    frm_BuyReport frm = new frm_BuyReport();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Sale", "User_Sale");
                if (check == true)
                {
                    frm_Sales frm = new frm_Sales();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("CustomerMoney", "User_Customer");
                if (check == true)
                {
                    frm_CustomerMoney frm = new frm_CustomerMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("CustomerReport", "User_Customer");
                if (check == true)
                {
                    frm_CustomerReport frm = new frm_CustomerReport();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("SaleReport", "User_Sale");
                if (check == true)
                {
                    FRM_Sale_Report frm = new FRM_Sale_Report();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("SaleRb7h", "User_Sale");
                if (check == true)
                {
                    frm_Sales_Rb7h frm = new frm_Sales_Rb7h();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Return_", "User_Return");
                if (check == true)
                {
                    frm_Return frm = new frm_Return();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Return_Report", "User_Return");
                if (check == true)
                {
                    frm_Return_Detials frm = new frm_Return_Detials();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Add_Stock", "User_StockBank");
                if (check == true)
                {
                    frm_AddStock frm = new frm_AddStock();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Stock_Insert", "User_StockBank");
                if (check == true)
                {
                    frm_StockAddMoney frm = new frm_StockAddMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Bank_Insert", "User_StockBank");
                if (check == true)
                {
                    frm_BankAddMoney frm = new frm_BankAddMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Stock_Pull", "User_StockBank");
                if (check == true)
                {
                    frm_StockPullMoney frm = new frm_StockPullMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Bank_Pull", "User_StockBank");
                if (check == true)
                {
                    frm_BankPullMoney frm = new frm_BankPullMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("TRansfer_Stock", "User_StockBank");
                if (check == true)
                {
                    frm_StockTransfer frm = new frm_StockTransfer();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Transfer_BankStock", "User_StockBank");
                if (check == true)
                {
                    frm_StockBankTransfer frm = new frm_StockBankTransfer();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Current_Money", "User_StockBank");
                if (check == true)
                {
                    frm_CurrentMoney frm = new frm_CurrentMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_StockAddedMoneyReport frm = new frm_StockAddedMoneyReport();
            frm.ShowDialog();
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_BankAddedMoneyReport frm = new frm_BankAddedMoneyReport();
            frm.ShowDialog();
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_StockPullMoneyReport frm = new frm_StockPullMoneyReport();
            frm.ShowDialog();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Bank_PuLLMoneyReport frm = new frm_Bank_PuLLMoneyReport();
            frm.ShowDialog();
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_StockMoneyTransferReport frm = new frm_StockMoneyTransferReport();
            frm.ShowDialog();
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_StockBankTransferReport frm = new frm_StockBankTransferReport();
            frm.ShowDialog();
        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Add_Emploeey", "User_Emploeey");
                if (check == true)
                {
                    frm_Employee frm = new frm_Employee();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Pull_Money", "User_Emploeey");
                if (check == true)
                {
                    frm_EmploiesBorrowItems frm = new frm_EmploiesBorrowItems();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Give_Money", "User_Emploeey");
                if (check == true)
                {
                    frm_EmployeeBorrowMoney frm = new frm_EmployeeBorrowMoney();
                    frm.ShowDialog();
                }
            } catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Emploeyey_Money", "User_Emploeey");
                if (check == true)
                {
                    frm_EmployeeSalary frm = new frm_EmployeeSalary();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Emploeey_PullReport", "User_Emploeey");
                if (check == true)
                {
                    frm_EmployeeBorrowItemsReport frm = new frm_EmployeeBorrowItemsReport();
                    frm.ShowDialog();
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Emploeey_GiveReport", "User_Emploeey");
                if (check == true)
                {
                    Employee_BorrowMoneyReport frm = new Employee_BorrowMoneyReport();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Emploeey_MoneyReport", "User_Emploeey");
                if (check == true)
                {
                    frm_Employee_SalaryMoneyReport frm = new frm_Employee_SalaryMoneyReport();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem57_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Sanad_Kabd", "User_Deserved");
                if (check == true)
                {
                    frm_SanadKabd frm = new frm_SanadKabd();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem59_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Sanad_Sarf", "User_Deserved");
                if (check == true)
                {
                    frm_Sanad_Sarf frm = new frm_Sanad_Sarf();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem60_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Kabd_SarfReport", "User_Deserved");
                if (check == true)
                {
                    frm_Sanad_Kabd_Sarf_Report frm = new frm_Sanad_Kabd_Sarf_Report();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        Database db = new Database();

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("cre", "User_Backup");
                if (check == true)
                {
                    try
                    {
                        string d = DateTime.Now.Date.ToString("dd-MM-yyyy");
                        SaveFileDialog open = new SaveFileDialog();

                        open.Filter = "BackUp Files (*.back) | *.back";
                        open.FileName = "Sales_Backup_" + d;

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            tr.TrackerInsert("نسخ احتياطي", "اخذ نسخة احتياطية", "");
                            db.executedata("backup database Sales_System To Disk='" + open.FileName + "' ", "تم أخذ نسخة احتياطية بنجاح !");
                           
                        }
                    }
                    catch (Exception) { }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("re", "User_Backup");
                if (check == true)
                {
                    Server server = new Server(@".\SQLEXPRESS");

                    Microsoft.SqlServer.Management.Smo.Database db = server.Databases["Sales_System"];

                    //if there is any process work kill it to do the restore process correctly !

                    if (db != null)
                    {
                        server.KillAllProcesses(db.Name);
                    }

                    Restore restore = new Restore();

                    restore.Database = db.Name;

                    restore.Action = RestoreActionType.Database;

                    OpenFileDialog open = new OpenFileDialog();

                    open.Filter = "BackUp Files (*.back) | *.back";

                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        // add the libraries to the packages and refrences ! 
                        restore.Devices.AddDevice(open.FileName, DeviceType.File);
                        restore.ReplaceDatabase = true;
                        restore.NoRecovery = false;
                        restore.SqlRestore(server);
                        MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tr.TrackerInsert("استرجاع نسخ احتياطي", "استرجاع نسخة احتياطية", "");
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem61_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Unit", "User_Settings");
                if (check == true)
                {
                    frm_Units frm = new frm_Units();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem62_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Item_Group", "User_Settings");
                if (check == true)
                {
                    frm_ProductsGroup frm = new frm_ProductsGroup();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem63_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Store_Add", "User_Settings");
                if (check == true)
                {
                    frm_Store frm = new frm_Store();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("User_Permission", "User_Settings");
                if (check == true)
                {
                    frm_Permission frm = new frm_Permission();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Setting", "User_Settings");
                if (check == true)
                {
                    frm_Setting frm = new frm_Setting();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool check = checkuser("Item_View", "User_Settings");
                if (check == true)
                {
                    frm_ShowProducts frm = new frm_ShowProducts();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem64_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_StoreGard frm = new frm_StoreGard();
            frm.ShowDialog();
        }

        private void barButtonItem66_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_StoreTransfer frm = new frm_StoreTransfer();
            frm.ShowDialog();
        }

        private void barButtonItem67_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_productsTransferReport frm = new frm_productsTransferReport();
            frm.ShowDialog();
        }

        private void barButtonItem68_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ProductsTalif frm = new frm_ProductsTalif();
            frm.ShowDialog();
        }

        private void barButtonItem69_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ProductsTalifReport frm = new frm_ProductsTalifReport();
            frm.ShowDialog();
        }

        private void barButtonItem70_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_TaxesReport frm = new frm_TaxesReport();
            frm.ShowDialog();
        }

        //// for the buy_sale_order_dates Agel orders : 
        //public void Get_Dates_Sales()
        //{
        //    try
        //    {
        //        DataTable today = new DataTable();
        //        DataTable before = new DataTable();
        //        DataTable after = new DataTable();
        //        today.Clear();
        //        before.Clear();
        //        after.Clear();

        //        DataTable todaybuy = new DataTable();
        //        DataTable beforebuy = new DataTable();
        //        DataTable afterbuy = new DataTable();
        //        todaybuy.Clear();
        //        beforebuy.Clear();
        //        afterbuy.Clear();

        //        DataTable selfatoday = new DataTable();
        //        DataTable selfabefore = new DataTable();
        //        DataTable selfaafter = new DataTable();
        //        selfatoday.Clear();
        //        selfabefore.Clear();
        //        selfaafter.Clear();

        //        today = db.readData("select * from Customer_Money where Convert(date,Reminder_Date,105) = N'"+DateTime.Now.ToShortDateString()+"' ", "");
        //        lbltoday.Text = today.Rows.Count + "";


        //        before = db.readData("select * from Customer_Money where Convert(date,Reminder_Date,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
        //        lblbefore.Text = before.Rows.Count + "";


        //        after = db.readData("select * from Customer_Money where Convert(date,Reminder_Date,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
        //        lblafter.Text = after.Rows.Count + "";

        //        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //        todaybuy = db.readData("select * from Supplier_Money where Convert(date,Reminder_Date,105) = N'"+DateTime.Now.ToShortDateString()+"' ", "");
        //        lbltodaybuy.Text = todaybuy.Rows.Count + "";

        //        beforebuy = db.readData("select * from Supplier_Money where Convert(date,Reminder_Date,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
        //        lblbeforebuy.Text = beforebuy.Rows.Count + "";

        //        afterbuy = db.readData("select * from Supplier_Money where Convert(date,Reminder_Date,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
        //        lblafterbuy.Text = afterbuy.Rows.Count + "";

        //        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //        selfatoday = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) = N'"+DateTime.Now.ToShortDateString()+"' ", "");
        //        lblselfatoday.Text = selfatoday.Rows.Count + "";

        //        selfabefore = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) < N'" + DateTime.Now.ToShortDateString() + "' ", "");
        //        lblselfabefore.Text = selfabefore.Rows.Count + "";

        //        selfaafter = db.readData("SELECT [Order_ID] as 'رقم السلفة',[Borrow_From] as 'اسم الدائن',[Borrow_To] as 'اسم الشخص',[Order_Date] as 'تاريخ السلفة',[Date_Reminder] as 'تاريخ الاستحقاق',[Price] as 'السعر',[Notes] as 'ملاحظات'FROM [Sales_System].[dbo].[Employee_BorrowMoney] where Convert(date,Date_Reminder,105) > N'" + DateTime.Now.ToShortDateString() + "' ", "");
        //        lblselfaafter.Text = selfaafter.Rows.Count + "";

        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                //Get_Dates_Sales();

                RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
                if (SkinName != null)
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinName.GetValue("SkinName").ToString();
                }
            }
            catch (Exception) { }

            barStaticItem2.Caption = "التاريخ : " + DateTime.Now.ToShortDateString();
            barStaticItem3.Caption = "اسم المستخدم : " + Properties.Settings.Default.Defualt_USERNAME;
            try
            {
                USER_ID = Convert.ToInt32(db.readData("select * from Users where User_Name=N'"+Properties.Settings.Default.Defualt_USERNAME+"'", "").Rows[0][0]);
            }
            catch (Exception) { }
        }

        private bool checkuser(string filed,string table)
        {
            DataTable tblsearch = new DataTable();
            tblsearch = db.readData("select "+filed+" from "+table+" where User_ID=" + USER_ID + "", "");
            if (Convert.ToDecimal(tblsearch.Rows[0][0]) == 0)
            {
                MessageBox.Show("انت لا تملك صلاحية الدخول لهذه الشاشة", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Sup_Money", "User_Supplier");
                if (check == true)
                {
                    frm_SupplierMoney frm = new frm_SupplierMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_ProductRequired frm = new frm_ProductRequired();
            frm.ShowDialog();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void tileItem1_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("User_Permission", "User_Settings");
                if (check == true)
                {
                    frm_Permission frm = new frm_Permission();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Items_Add", "User_Settings");
                if (check == true)
                {
                    frm_products frm = new frm_products();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("CustomerMoney", "User_Customer");
                if (check == true)
                {
                    frm_CustomerMoney frm = new frm_CustomerMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Sale", "User_Sale");
                if (check == true)
                {
                    frm_Sales frm = new frm_Sales();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Buy", "User_Buy");
                if (check == true)
                {
                    frm_Buy frm = new frm_Buy();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Return_", "User_Return");
                if (check == true)
                {
                    frm_Return frm = new frm_Return();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Add_Emploeey", "User_Emploeey");
                if (check == true)
                {
                    frm_Employee frm = new frm_Employee();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Current_Money", "User_StockBank");
                if (check == true)
                {
                    frm_CurrentMoney frm = new frm_CurrentMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem8_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_ProductRequired frm = new frm_ProductRequired();
            frm.ShowDialog();
        }

        private void tileItem7_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Return_", "User_Return");
                if (check == true)
                {
                    frm_Return frm = new frm_Return();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem9_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Add_Emploeey", "User_Emploeey");
                if (check == true)
                {
                    frm_Employee frm = new frm_Employee();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tileItem10_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                bool check = checkuser("Current_Money", "User_StockBank");
                if (check == true)
                {
                    frm_CurrentMoney frm = new frm_CurrentMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem71_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_fast frm = new Sales_Management.frm_fast();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
                SkinName.SetValue("SkinName", DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName.ToString());
                SkinName.Close();
                Application.Exit();
            }
            catch (Exception) { } }

        private void barStaticItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem73_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem74_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=BmcXSw1r_sw&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-");
        }

        private void barButtonItem76_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=FVcNILyNYt8&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=2");
        }

        private void barButtonItem77_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=SdtpJHP1dO0&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=10");
        }

        private void barButtonItem78_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=RU9xe7lT6Rg&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=9");
        }

        private void barButtonItem79_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=nDEscDSqOTc&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=7");
        }

        private void barButtonItem80_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=nDEscDSqOTc&list=PLG1WGRqGu5Vj_2IA6y8px83S-TodKduZ-&index=7");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm_sale_date_after frm = new frm_sale_date_after();
            frm.ShowDialog();
        }

        private void lblafter_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_sale_date_before frm = new frm_sale_date_before();
            frm.ShowDialog();
        }

        private void lblbefore_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_sale_date_today frm = new frm_sale_date_today();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frm_buy_date_now frm = new frm_buy_date_now();
            frm.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //try { Get_Dates_Sales(); }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frm_buy_date_before frm = new frm_buy_date_before();
            frm.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frm_buy_date_after frm = new frm_buy_date_after();
            frm.ShowDialog();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            frm_selfa_date_today frm = new frm_selfa_date_today();
            frm.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frm_selfa_date_before frm = new frm_selfa_date_before();
            frm.ShowDialog();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            frm_selfa_date_after frm = new frm_selfa_date_after();
            frm.ShowDialog();
        }

        private void barButtonItem77_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_notif frm = new frm_notif();
            frm.ShowDialog();
        }

        private void barButtonItem78_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_usertree frm = new frm_usertree();
            frm.ShowDialog();
        }
    }
}
