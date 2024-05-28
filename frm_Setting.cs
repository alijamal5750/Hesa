using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Sales_Management
{
    public partial class frm_Setting : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();


        public frm_Setting()
        {
            InitializeComponent();
        }

        //to bring me the data of this form from the database ! 
        private void showOrderData()
        {
            tbl.Clear();
            tbl = db.readData("select * from Order_PrintData", "");

            if (tbl.Rows.Count >= 1)
            {   
                txtName.Text = tbl.Rows[0][1].ToString();
                txtAddress.Text = tbl.Rows[0][2].ToString();
                txtDescription.Text = tbl.Rows[0][3].ToString();
                txtPhone1.Text = tbl.Rows[0][4].ToString();
                txtPhone2.Text = tbl.Rows[0][5].ToString();
            }

            try
            {
                // retrive image from the database !
                Byte[] byteimage = new Byte[0];
                byteimage =(Byte[]) (tbl.Rows[0][0]);
                MemoryStream memorystream = new MemoryStream(byteimage);

                pictureLogo.BackgroundImageLayout = ImageLayout.Stretch;
                pictureLogo.BackgroundImage = Image.FromStream(memorystream);
            }
            catch (Exception) { }
        }

        private void showprinters()
        {
            for (int i = 0; i <= PrinterSettings.InstalledPrinters.Count - 1; i++)
            {
                PrinterName = PrinterSettings.InstalledPrinters[i];
                cpxPrinter.Items.Add(PrinterName);
            }

            cpxPrinter.SelectedIndex = 0;

            if (Properties.Settings.Default.PrinterName == "")
            {
                cpxPrinter.SelectedIndex = 0;
            }
            else
            {
                // after the form load open please bring me the saved printer name and display it in the cpx printer !
                cpxPrinter.Text = Properties.Settings.Default.PrinterName;
            }
        }

        // to show the general setting when form is loaded !
        private void ShowGeneral()
        {
            if (Properties.Settings.Default.ItemDiscount == "Present")
            {
                rbtnPresent.Checked=true;
            }

            else if (Properties.Settings.Default.ItemDiscount == "Value")
            {
                rbtnValue.Checked=true;
            }

            NudSaleNumber.Value = Properties.Settings.Default.SalesPrintNum;
            NudBuyNumber.Value = Properties.Settings.Default.BuyPrintNum;

            if (Properties.Settings.Default.Taxes == true)
            {
                checkTaxes.Checked=true;
            }

            else if (Properties.Settings.Default.Taxes == false)
            {
               checkTaxes.Checked=false;
            }

            if (Properties.Settings.Default.SaleDiscountForCasher == true)
            {
                checkDiscount.Checked = true;
            }

            else if (Properties.Settings.Default.SaleDiscountForCasher == false)
            {
                checkDiscount.Checked = false;
            }

            if (Properties.Settings.Default.SalesPrint == true)
            {
                checkSalePrint.Checked = true;
            }

            else if (Properties.Settings.Default.SalesPrint == false)
            {
                checkSalePrint.Checked = false;
            }

            if (Properties.Settings.Default.BuyPrint == true)
            {
                checkBuyPrint.Checked = true;
            }

            else if (Properties.Settings.Default.BuyPrint == false)
            {
                checkBuyPrint.Checked = false;
            }

            if (Properties.Settings.Default.SalePrintKind =="8CM")
            {
                rbtn8cmSales.Checked = true;
            }

            else if (Properties.Settings.Default.SalePrintKind == "A4")
            {
                rbtnA4Sales.Checked = true;
            }

            if (Properties.Settings.Default.BuyPrintKind == "8CM")
            {
                rbtn8cmBuy.Checked = true;
            }

            else if (Properties.Settings.Default.BuyPrintKind == "A4")
            {
                rbtnA4Buy.Checked = true;
            }

            Properties.Settings.Default.Save();
        }

        string PrinterName="";
        private void frm_Setting_Load(object sender, EventArgs e)
        {
            try
            {
                showprinters();
                showOrderData();
                ShowGeneral();
            }
            catch (Exception) { }

            }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            if (cpxPrinter.Text == "")
            {
                MessageBox.Show("من فضلك قم بأختيار الطابعة");
                return;
            }

            Properties.Settings.Default.PrinterName = cpxPrinter.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("تم الحفظ بنجاح","تأكيد !",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        string imagePath = "";
        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*) | *.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                imagePath = op.FileName.ToString();
                // delete the image if the user choose ok for adding another image !
                pictureLogo.Image = null;
                pictureLogo.ImageLocation = imagePath;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pictureLogo.BackgroundImage = null;
            pictureLogo.Image = null;

            imagePath = "";
        }

        // funcction to convert the image to byte and save it in database !

        private void saveImage(string stmt,string parametername,string message)
        {
            //connection to database
            SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Sales_System; Integrated Security=True");

            // we will send the parameters by @
            SqlCommand cmd = new SqlCommand(stmt, conn);


            // convert the picture to Binary and send it to the cmd to @Logo parameter ! using system.io;
            FileStream filestream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            byte[] bytestream = new Byte[filestream.Length];

            filestream.Read(bytestream, 0, bytestream.Length);

            filestream.Close();

            //-----------------------------

            SqlParameter parameter = new SqlParameter(parametername, SqlDbType.VarBinary, bytestream.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytestream);

            cmd.Parameters.Add(parameter);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (message != "")
            {
                MessageBox.Show(message, "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (imagePath == "")
            {
                MessageBox.Show("من فضلك اختر لوجو ", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tbl = db.readData("select * from Order_PrintData", "");
            if (tbl.Rows.Count >= 1)
            {

                // call function to save image !
                saveImage("update Order_PrintData set Logo=@Logo,Name=N'" + txtName.Text + "',Adress=N'" + txtAddress.Text + "',Description=N'" + txtDescription.Text + "',Phone1=N'" + txtPhone1.Text + "',Phone2=N'" + txtPhone2.Text + "' ", "@Logo", "تم الحفظ بنجاح !");
            }

            else
            {
                saveImage("insert into Order_PrintData values (@Logo,N'" + txtName.Text + "',N'" + txtAddress.Text + "',N'" + txtDescription.Text + "',N'" + txtPhone1.Text + "',N'" + txtPhone2.Text + "' )", "@Logo", "تم الحفظ بنجاح !");
            }
            imagePath = "";
        }

        private void btnSaveGeneralSetting_Click(object sender, EventArgs e)
        {

            if (NudSaleNumber.Value < 1 || NudBuyNumber.Value < 1) 
            {
                MessageBox.Show("من فضلك لا يمكن ان يقل عدد الفواتير المطبوعة عن واحد ", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (rbtnPresent.Checked == true)
            {
                Properties.Settings.Default.ItemDiscount = "Present";
            }

            else if (rbtnValue.Checked == true)
            {
                Properties.Settings.Default.ItemDiscount = "Value";
            }

            Properties.Settings.Default.SalesPrintNum = Convert.ToInt32(NudSaleNumber.Value);
            Properties.Settings.Default.BuyPrintNum = Convert.ToInt32(NudBuyNumber.Value);

            if (checkTaxes.Checked == true)
            {
                Properties.Settings.Default.Taxes = true;
            }

            else if (checkTaxes.Checked == false)
            {
                Properties.Settings.Default.Taxes = false;
            }

            if (checkDiscount.Checked == true)
            {
                Properties.Settings.Default.SaleDiscountForCasher = true;
            }

            else if (checkDiscount.Checked == false)
            {
                Properties.Settings.Default.SaleDiscountForCasher = false;
            }

            if (checkSalePrint.Checked == true)
            {
                Properties.Settings.Default.SalesPrint = true;
            }

            else if (checkSalePrint.Checked == false)
            {
                Properties.Settings.Default.SalesPrint = false;
            }

            if (checkBuyPrint.Checked== true)
            {
                Properties.Settings.Default.BuyPrint = true;
            }

            else if (checkBuyPrint.Checked == false)
            {
                Properties.Settings.Default.BuyPrint = false;
            }

            if (rbtn8cmSales.Checked == true)
            {
                Properties.Settings.Default.SalePrintKind = "8CM";
            }

            else if (rbtnA4Sales.Checked == true)
            {
                Properties.Settings.Default.SalePrintKind = "A4";
            }

            if (rbtn8cmBuy.Checked == true)
            {
                Properties.Settings.Default.BuyPrintKind = "8CM";
            }

            else if (rbtnA4Buy.Checked == true)
            {
                Properties.Settings.Default.BuyPrintKind = "A4";
            }

            Properties.Settings.Default.Save();

            MessageBox.Show("تم حفظ البيانات بنجاح ", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}