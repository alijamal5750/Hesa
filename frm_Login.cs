using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Data.SqlClient;
using System.IO;

namespace Sales_Management
{
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {

        // make the splash scrren close after time from thread t ! 
        Thread t;

        Database db = new Database();
        DataTable tbl = new DataTable();


        public frm_Login()
        {
            InitializeComponent();

            // make the splash scrren close after time from thread t ! 
            //try
            //{
            //    t = new Thread(new ThreadStart(startsplashscreen));
            //    t.Start();
            //    Thread.Sleep(10000);
            //    t.Abort();
            //}
            //catch (Exception) { }

            
        }

        private void startsplashscreen()
        {
            //try
            //{
            //    Application.Run(new Splash_Screen());
            //}
            //catch (Exception ) { }
        }

        private bool ceckdatabase()
        {
           
                // to check if the database exist or not ! 
                //connection to database
                SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS; Integrated Security=True");
                SqlCommand cmd = new SqlCommand("", conn);

                SqlDataReader rdr;
            try
            {
                cmd.CommandText = "exec sys.sp_databases";
                conn.Open();

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.GetString(0) == "Sales_System")
                    {
                        return true;
                        break;
                    }
                }
            }
            catch (Exception) { return false; }
                conn.Close();
                rdr.Dispose();
                cmd.Dispose();
                return false;
            }
          
        
        // to create database !
        private void createdatabase()
        {
            try
            {
                bool check = ceckdatabase();
                if (check == false)
                {
                    var filecontent = File.ReadAllText(Application.StartupPath + @"\full.sql");
                    var sqlquries = filecontent.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                    var conn = new SqlConnection(@"Server=.\SQLEXPRESS; Integrated Security=True");
                    var cmd = new SqlCommand("query", conn);
                    conn.Open();

                    foreach (var query in sqlquries)
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception) { }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            //createdatabase();
            txtusername.Clear();
            txtusername.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if the user press enter go to the txtpassword ! 

            if (e.KeyChar == 13)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if the user press enter go to the btnlogin ! 

            if (e.KeyChar == 13)
            {
                btnLogin_Click(null, null);
            }
        }

        private bool Trial()
        {
            int num = Properties.Settings.Default.Trial;

            int thisnum = num + 1;

            Properties.Settings.Default.Trial = thisnum;
            Properties.Settings.Default.Save();

            if (thisnum >= 10)
            {
                MessageBox.Show("انتهت الفترة التجريبية","تنبيه!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }
            else 
            {
                int baky = 10 - thisnum;
                MessageBox.Show("هذه النسخة التجريبية باقي لك عدد مرات  "+baky+" مرة", "تنبيه!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.Product_Key == "No")
            //{
            //    frm_Serial frm = new frm_Serial();
            //    frm.ShowDialog();
            //    return;
            //}
            //else
            //{


            tbl.Clear();
            if (rbtnmanager.Checked == true)
            {
                tbl = db.readData("select * from Users where USer_Name=N'" + txtusername.Text + "' and User_Password=N'" + Hash_Password.hashPassword(txtpassword.Text) + "' and Type=N'مدير'", "");


                if (tbl.Rows.Count >= 1)
                {
                    //bool check;
                    //check = Trial();
                    //if (check == false)
                    //{
                    //    return;
                    //}

                    Properties.Settings.Default.Defualt_USERNAME = txtusername.Text;
                    Properties.Settings.Default.Stock_ID = Convert.ToInt32(tbl.Rows[0][4]);
                    Properties.Settings.Default.User_ID = Convert.ToInt32(tbl.Rows[0][0]);
                    Properties.Settings.Default.Save();
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            else if (rbtnemp.Checked == true)
            {
                tbl = db.readData("select * from Users where USer_Name=N'" + txtusername.Text + "' and User_Password=N'" + Hash_Password.hashPassword(txtpassword.Text) + "' and Type=N'مستخدم عادي'", "");


                if (tbl.Rows.Count >= 1)
                {
                    //bool check;
                    //check = Trial();
                    //if (check == false)
                    //{
                    //    return;
                    //}
                    Properties.Settings.Default.Defualt_USERNAME = txtusername.Text;
                    Properties.Settings.Default.Stock_ID = Convert.ToInt32(tbl.Rows[0][4]);
                    Properties.Settings.Default.User_ID = Convert.ToInt32(tbl.Rows[0][0]);
                    Properties.Settings.Default.Save();
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            DataTable tblstock = new DataTable();
            tblstock.Clear();
            DataTable empty = new DataTable();
            empty.Clear();
            empty = db.readData("select * from USers", "");
            if (empty.Rows.Count <= 0)
            {
                string type = "مدير";
                db.executedata("insert into Users values (1,N'" + Properties.Settings.Default.Defualt_USERNAME + "',N'" + Properties.Settings.Default.Defualt_Password + "',N'" + type + "',1,0) ", "");
                db.executedata("insert into User_Settings values (1,1,1,1,1,1,1,1) ", "");
                db.executedata("insert into User_Customer values (1,1,1,1) ", "");
                db.executedata("insert into User_Supplier values (1,1,1,1) ", "");
                db.executedata("insert into User_Buy values (1,1,1) ", "");
                db.executedata("insert into User_Sale values (1,1,1,1) ", "");
                db.executedata("insert into User_Return values (1,1,1) ", "");
                db.executedata("insert into User_StockBank values (1,1,1,1,1,1,1,1,1,1) ", "");
                db.executedata("insert into User_Emploeey values (1,1,1,1,1,1,1,1) ", "");
                db.executedata("insert into User_Deserved values (1,1,1,1,1,1,1) ", "");
                db.executedata("insert into User_report values (1,1,1,1,1,1,1) ", "");
                db.executedata("insert into User_Backup values (1,1,1) ", "");
            }

            tblstock = db.readData("select * from Stock_Data", "");
            if (tblstock.Rows.Count <= 0)
            {
                db.executedata("insert into Stock_Data values (1,N'الخزنة الرئيسية') ", "");
                db.executedata("insert into Stock values (1,0)", "");
                db.executedata("insert into Bank values (0)", "");
            }

        //}
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
     
        }

        private void simpleButton1_Click_3(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click_4(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click_5(object sender, EventArgs e)
        {
         
        }

        private void simpleButton1_Click_6(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click_7(object sender, EventArgs e)
        {
        
        }

        private void simpleButton1_Click_8(object sender, EventArgs e)
        {
 
        }
    }
}