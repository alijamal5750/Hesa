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
    public partial class frm_StockBankTransfer : DevExpress.XtraEditors.XtraForm
    {

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

            DataTable tblBank = new DataTable();
            tblBank.Clear();

            tblBank = db.readData("select * from Bank", "");

            if (Convert.ToDecimal(tblBank.Rows[0][0]) <= 0)
            {
                lblBank.Text = "0";
            }

            else if (Convert.ToDecimal(tblBank.Rows[0][0]) >= 1)
            {
                lblBank.Text = Convert.ToDecimal(tblBank.Rows[0][0]).ToString();
            }
        }


        private void FillStock()
        {
            cbxStock.DataSource = db.readData("select * from Stock_Data", "");
            cbxStock.DisplayMember = "Stock_Name";
            cbxStock.ValueMember = "Stock_ID";
        }




        public frm_StockBankTransfer()
        {
            InitializeComponent();
        }

        private void frm_StockBankTransfer_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();

            try
            {
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

            if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                lblMoney.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
            }
        }


        private void FromStockToBank()
        {

            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            if (NudPrice.Value > Convert.ToDecimal(lblMoney.Text))
            {
                MessageBox.Show("لا يمكن تحويل مبلغ اكبر من المبلغ الموجود في الخزنة", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; 
            }

            db.executedata("update Stock set Money=Money - "+NudPrice.Value+" where Stock_ID="+cbxStock.SelectedValue+" ", "");

            db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + cbxStock.SelectedValue + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'تحويل الى بنك',N'') ", "");

            db.executedata("update Bank set Money=Money + "+NudPrice.Value+" ", "");

            db.executedata("insert into Bank_Insert (Money,Date,Name,Type,Reason) values (" + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'تحويل من خزنة ',N'') ", "");

            db.executedata("insert into StockBank_Transfer (Money,Date,From_,To_,Name) values (" + NudPrice.Value + ",N'" + date + "',N'" + cbxStock.Text + "',N'تحويل الى بنك',N'" + txtName.Text + "') ", "تم التحويل بنجاح !");

            txtName.Clear();
            NudPrice.Value = 1;
            onLoadScreen();
        }


        private void FromBankToStock()
        {
            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            if (NudPrice.Value > Convert.ToDecimal(lblBank.Text))
            {
                MessageBox.Show("لا يمكن تحويل مبلغ اكبر من المبلغ الموجود في البنك", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            db.executedata("update Stock set Money=Money + " + NudPrice.Value + " where Stock_ID=" + cbxStock.SelectedValue + " ", "");

            db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + cbxStock.SelectedValue + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'تحويل من البنك',N'') ", "");

            db.executedata("update Bank set Money=Money - " + NudPrice.Value + " ", "");

            db.executedata("insert into Bank_Pull (Money,Date,Name,Type,Reason) values (" + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'تحويل الى خزنة ',N'') ", "");
            
            db.executedata("insert into StockBank_Transfer (Money,Date,From_,To_,Name) values (" + NudPrice.Value + ",N'" + date + "',N'من البنك',N'"+cbxStock.Text+"',N'" + txtName.Text + "') ", "تم التحويل بنجاح !");

            txtName.Clear();
            NudPrice.Value = 1;
            onLoadScreen();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            if (cbxStock.Items.Count >= 1)
            {
                if (txtName.Text == "") { MessageBox.Show("من فضلك ادخل اسم المحول", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (NudPrice.Value <= 0) { MessageBox.Show("من فضلك يجب ان يكون مبلغ التحويل اكبر من 0", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            }


            if (rbtnFromStockToBank.Checked == true)
            {
                FromStockToBank();
            }

            else if (rbtnFromBankToStock.Checked == true)
            {
                FromBankToStock();
            }
        }
    }
}