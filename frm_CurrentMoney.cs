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
    public partial class frm_CurrentMoney : DevExpress.XtraEditors.XtraForm
    {
        int USER_ID = 0;
        Database db = new Database();
        DataTable tbl = new DataTable();


        private void onLoadScreen()
        {

            FillStock();

            // bring me the money of the stock that selected in the cpx stock !
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + cbxStock.SelectedValue + " ", "");
            if (tbl.Rows.Count <= 0)
            {
                // insert a defualt values atomaticly without user know that ! 

                db.executedata("insert into Stock values (" + cbxStock.SelectedValue + ",0) ", "");

                // to fill it and used it after money was created !
                tbl = db.readData("select * from Stock where Stock_ID=" + cbxStock.SelectedValue + " ", "");
            }

            // to display the number of money in the label of each sotck that cpx stockes !

            if (Convert.ToDecimal(tbl.Rows[0][1]) <= 0)
            {
                lblMoney.Text = "0";
            }

            else if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                lblMoney.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
            }

          
        }

        private void FillStock()
        {
            cbxStock.DataSource = db.readData("select * from Stock_Data ", "");
            cbxStock.DisplayMember = "Stock_Name";
            cbxStock.ValueMember = "Stock_ID";
        }

        public frm_CurrentMoney()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = checkuser("Stock_Insert", "User_StockBank");
                if (check == true)
                {
                    frm_StockAddMoney frm = new frm_StockAddMoney();
                    frm.ShowDialog();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool check = checkuser("Bank_Insert", "User_StockBank");
            if (check == true)
            {
                frm_BankAddMoney frm = new frm_BankAddMoney();
                frm.ShowDialog();
            }
        }

        private void frm_CurrentMoney_Load(object sender, EventArgs e)
        {
            try
            {
                USER_ID = Convert.ToInt32(db.readData("select * from Users where USer_Name=N'"+Properties.Settings.Default.Defualt_USERNAME+"' ","").Rows[0][0]);
                onLoadScreen();
            }
            catch (Exception) { }
        }

        private void cbxStock_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // bring me the money of the stock that selected in the cpx stock !
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + cbxStock.SelectedValue + " ", "");
            if (tbl.Rows.Count <= 0)
            {
                // insert a defualt values atomaticly without user know that ! 

                db.executedata("insert into Stock values (" + cbxStock.SelectedValue + ",0) ", "");

                // to fill it and used it after money was created !
                tbl = db.readData("select * from Stock where Stock_ID=" + cbxStock.SelectedValue + " ", "");
            }

            // to display the number of money in the label of each sotck that cpx stockes !

            if (Convert.ToDecimal(tbl.Rows[0][1]) <= 0)
            {
                lblMoney.Text = "0";
            }

            else if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                lblMoney.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
            }
        }

        private bool checkuser(string filed, string table)
        {
            DataTable tblsearch = new DataTable();
            tblsearch = db.readData("select " + filed + " from " + table + " where User_ID=" + USER_ID + "", "");
            if (Convert.ToDecimal(tblsearch.Rows[0][0]) == 0)
            {
                MessageBox.Show("انت لا تملك صلاحية الدخول لهذه الشاشة", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}