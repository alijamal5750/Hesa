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
    public partial class frm_StockTransfer : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();


        private void onLoadScreen()
        {

            FillStock();

            // bring me the money of the stock that selected in the cpx stock !
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + cpxStockFrom.SelectedValue + " ", "");
            if (tbl.Rows.Count <= 0)
            {
                // insert a defualt values atomaticly without user know that ! 

                db.executedata("insert into Stock values (" + cpxStockFrom.SelectedValue + ",0) ", "");

                // to fill it and used it after money was created !
                tbl = db.readData("select * from Stock where Stock_ID=" + cpxStockFrom.SelectedValue + " ", "");
            }

            // to display the number of money in the label of each sotck that cpx stockes !

            if (Convert.ToDecimal(tbl.Rows[0][1]) <= 0)
            {
                lblMoney1.Text = "0";
                lblMoney2.Text = "0";
            }

            else if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                lblMoney1.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
                lblMoney2.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
            }
        }

      


        private void FillStock()
        {
            cpxStockFrom.DataSource = db.readData("select * from Stock_Data", "");
            cpxStockFrom.DisplayMember = "Stock_Name";
            cpxStockFrom.ValueMember = "Stock_ID";

            cpxStockTo.DataSource = db.readData("select * from Stock_Data", "");
            cpxStockTo.DisplayMember = "Stock_Name";
            cpxStockTo.ValueMember = "Stock_ID";
        }


        public frm_StockTransfer()
        {
            InitializeComponent();
        }

        private void frm_StockTransfer_Load(object sender, EventArgs e)
        {
            DtpDate.Text = DateTime.Now.ToShortDateString();

            try
            {
                onLoadScreen();
            }
            catch (Exception) { }
        }

        private void cpxStockFrom_SelectionChangeCommitted(object sender, EventArgs e)
        {
             // bring me the money of the stock that selected in the cpx stock !
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + cpxStockFrom.SelectedValue + " ", "");
            if (tbl.Rows.Count <= 0)
            {
                // insert a defualt values atomaticly without user know that ! 

                db.executedata("insert into Stock values (" + cpxStockFrom.SelectedValue + ",0) ", "");

                // to fill it and used it after money was created !
                tbl = db.readData("select * from Stock where Stock_ID=" + cpxStockFrom.SelectedValue + " ", "");
            }

            // to display the number of money in the label of each sotck that cpx stockes !

            if (Convert.ToDecimal(tbl.Rows[0][1]) <= 0)
            {
                lblMoney1.Text = "0";
                
            }

            else if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                lblMoney1.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
                
            }
        
        }

        private void cpxStockTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
             // bring me the money of the stock that selected in the cpx stock !
            tbl.Clear();
            tbl = db.readData("select * from Stock where Stock_ID=" + cpxStockTo.SelectedValue + " ", "");
            if (tbl.Rows.Count <= 0)
            {
                // insert a defualt values atomaticly without user know that ! 

                db.executedata("insert into Stock values (" + cpxStockTo.SelectedValue + ",0) ", "");

                // to fill it and used it after money was created !
                tbl = db.readData("select * from Stock where Stock_ID=" + cpxStockTo.SelectedValue + " ", "");
            }

            // to display the number of money in the label of each sotck that cpx stockes !

            if (Convert.ToDecimal(tbl.Rows[0][1]) <= 0)
            {
                
                lblMoney2.Text = "0";
            }

            else if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                
                lblMoney2.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
            }
        
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            string date = DtpDate.Value.ToString("dd/MM/yyyy");

            try
            {
                if (cpxStockFrom.Items.Count <= 0)
                {
                    MessageBox.Show("من فضلك قم بملىء بيانات الخزنات اولاً", "تنبيه !");
                    return;
                }


                if (Convert.ToInt32(cpxStockFrom.SelectedValue) == Convert.ToInt32(cpxStockTo.SelectedValue))
                {
                    MessageBox.Show("لا يمكن تحويل الرصيد لنفس الخزنة", "تنبيه !");
                    return;
                }


                if (NudPrice.Value > Convert.ToDecimal(lblMoney1.Text))
                {
                    MessageBox.Show("لا يمكن تحويل رصيد اكبر من الرصيد الموجود في الخزنة", "تنبيه !");
                    return;
                }

                if (txtName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم الشخص المسؤول عن التحويل", "تنبيه !");
                    return;
                }


                db.executedata("update Stock set Money=Money - "+NudPrice.Value+" where Stock_ID="+cpxStockFrom.SelectedValue+"  ", "");


                db.executedata("update Stock set Money=Money + " + NudPrice.Value + " where Stock_ID=" + cpxStockTo.SelectedValue + "  ", "");


                db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + cpxStockFrom.SelectedValue + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'تحويل الى خزنة',N'" + txtReason.Text + "') ", "");


                db.executedata("insert into Stock_Insert (Stock_ID,Money,Date,Name,Type,Reason) values (" + cpxStockTo.SelectedValue + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'تحويل من خزنة اخرى',N'" + txtReason.Text + "') ", "");


                db.executedata("insert into Stock_Transfer (Money,Date,From_,To_,Name,Reason) values ("+NudPrice.Value+",N'"+date+"',"+cpxStockFrom.SelectedValue+","+cpxStockTo.SelectedValue+",N'"+txtName.Text+"',N'"+txtReason.Text+"') ", "تم التحويل بنجاح !");

                txtName.Clear();
                txtReason.Clear();
                NudPrice.Value = 1;
                onLoadScreen();
            }
            catch (Exception) { }
        }
    }
}