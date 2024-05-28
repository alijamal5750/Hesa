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
    public partial class frm_BankAddMoney : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();


        private void onLoadScreen()
        {
            try
            {
                // bring me the money of the stock that selected in the cpx stock !
                tbl.Clear();
                tbl = db.readData("select * from Bank ", "");
                if (tbl.Rows.Count <= 0)
                {
                    // insert a defualt values atomaticly without user know that ! 

                    db.executedata("insert into Bank values (0) ", "");

                    // to fill it and used it after money was created !
                    tbl = db.readData("select * from Bank", "");
                }

                // to display the number of money in the label of each sotck that cpx stockes !

                if (Convert.ToDecimal(tbl.Rows[0][0]) <= 0)
                {
                    lblMoney.Text = "0";
                }

                else if (Convert.ToDecimal(tbl.Rows[0][0]) >= 1)
                {
                    lblMoney.Text = Convert.ToDecimal(tbl.Rows[0][0]).ToString();
                }
            }catch(Exception) { }
        }


        public frm_BankAddMoney()
        {
            InitializeComponent();
        }

        private void frm_BankAddMoney_Load(object sender, EventArgs e)
        {
            try {
                DtpDate.Text = DateTime.Now.ToShortDateString();

                try
                {
                    onLoadScreen();
                }
                catch (Exception) { }
            }
            catch (Exception) { }
            }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string date = DtpDate.Value.ToString("dd/MM/yyyy");


                if (txtName.Text == "") { MessageBox.Show("من فضلك ادخل اسم المودع", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (NudPrice.Value <= 0) { MessageBox.Show("من فضلك يجب ان يكون مبلغ الايداع اكبر من 0", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                db.executedata("update Bank set Money = Money + " + NudPrice.Value + "  ", "");

                // we do the insert like that cuz the order_id is auto generated in the table auto encryment !
                db.executedata("insert into Bank_Insert (Money,Date,Name,Type,Reason) values (" + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'رصيد بنك اضافي',N'" + txtReason.Text + "') ", "تم الايداع بنجاح !");

                lblMoney.Text = "0";
                txtName.Clear();
                txtReason.Clear();
                NudPrice.Value = 0;
                onLoadScreen();
            }
            catch (Exception) { } }
    }
}