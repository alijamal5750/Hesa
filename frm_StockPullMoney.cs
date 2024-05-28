﻿using System;
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
    public partial class frm_StockPullMoney : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();
        tracker tr = new tracker();

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
            cbxStock.DataSource = db.readData("select * from Stock_Data", "");
            cbxStock.DisplayMember = "Stock_Name";
            cbxStock.ValueMember = "Stock_ID";
        }


        public frm_StockPullMoney()
        {
            InitializeComponent();
        }

        private void frm_StockPullMoney_Load(object sender, EventArgs e)
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

            else if (Convert.ToDecimal(tbl.Rows[0][1]) >= 1)
            {
                lblMoney.Text = Convert.ToDecimal(tbl.Rows[0][1]).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
             string date = DtpDate.Value.ToString("dd/MM/yyyy");

             if (cbxStock.Items.Count >= 1)
             {
                 if (txtName.Text == "") { MessageBox.Show("من فضلك ادخل اسم الساحب", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                 if (NudPrice.Value <= 0) { MessageBox.Show("من فضلك يجب ان يكون مبلغ السحب اكبر من 0", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                 // important validation for the money !
                 tbl.Clear();
                 tbl = db.readData("select * from Stock where Stock_ID="+cbxStock.SelectedValue+" ", ""); 
                 if(NudPrice.Value > Convert.ToDecimal(tbl.Rows[0][1]))
                 {
                     MessageBox.Show("لا يمكن ان يكون المبلغ المسحوب اكبر من المبلغ الموجود في الخزنة","تنبيه !",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                 return;
                 }

                 db.executedata("update Stock set Money = Money - " + NudPrice.Value + " where Stock_ID=" + cbxStock.SelectedValue + " ", "");

                 // we do the insert like that cuz the order_id is auto generated in the table auto encryment !
                 db.executedata("insert into Stock_Pull (Stock_ID,Money,Date,Name,Type,Reason) values (" + cbxStock.SelectedValue + "," + NudPrice.Value + ",N'" + date + "',N'" + txtName.Text + "',N'سحب رصيد من الخزنة',N'" + txtReason.Text + "') ", "تم السحب بنجاح !");
                tr.TrackerInsert("شاشة سحوبات الخزنات", "اضافة السحب, المسؤول عن السحب", txtName.Text);
                lblMoney.Text = "0";
                 txtName.Clear();
                 txtReason.Clear();
                 NudPrice.Value = 0;
                 cbxStock.SelectedValue = 1;

                 onLoadScreen();
             }
        }
    }
}