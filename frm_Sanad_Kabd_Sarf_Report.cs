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
    public partial class frm_Sanad_Kabd_Sarf_Report : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_Sanad_Kabd_Sarf_Report()
        {
            InitializeComponent();
        }

        private void frm_Sanad_Kabd_Sarf_Report_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
            tbl.Clear();
            DgvSearch.DataSource = tbl;
            txtTotal.Text = "0";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {  
            string date1=DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2=DtpTo.Value.ToString("yyyy-MM-dd");
            try
            {
                if (rbtnKabd.Checked == true)
                {
                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Name] as 'اسم المسؤول عن القبض',[Price] as 'المبلغ',[Date] as 'تاريخ العملية',[From_] as 'تم القبض من',[Reason] as 'السبب'FROM [Sales_System].[dbo].[Sanad_kabd] where convert(date,[Date],105) between N'"+date1+"' and N'"+date2+"' ", "");
                    DgvSearch.DataSource = tbl;

                   
                        decimal total = 0;

                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
                        }
                        txtTotal.Text = Math.Round(total, 2).ToString();
                    
                }

                else if (rbtnSarf.Checked == true)
                {
                    tbl.Clear();
                    tbl = db.readData("SELECT [Order_ID] as 'رقم العملية',[Name] as 'اسم المسؤول عن الصرف',[Price] as 'المبلغ',[Date] as 'تاريخ العملية',[To_] as 'تم الصرف ل',[Reason] as 'السبب'FROM [Sales_System].[dbo].[Sanad_Sarf] where convert(date,[Date],105) between N'" + date1 + "' and N'" + date2 + "' ", "");
                    DgvSearch.DataSource = tbl;

                   
                        decimal total = 0;

                        for (int i = 0; i <= DgvSearch.Rows.Count - 1; i++)
                        {
                            total += Convert.ToDecimal(DgvSearch.Rows[i].Cells[2].Value);
                        }
                        txtTotal.Text = Math.Round(total, 2).ToString();
                    
                }
            }
            catch (Exception) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            string date2 = DtpTo.Value.ToString("yyyy-MM-dd");
            
            if(MessageBox.Show("هل تريد حذف كل السندات؟","تنبيه !",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {

            if (rbtnKabd.Checked == true)
            {
                db.executedata("delete from Sanad_Kabd where convert(date,[Date],105) between N'" + date1 + "' and N'" + date2 + "' ", "تم المسح بنجاح !");
                frm_Sanad_Kabd_Sarf_Report_Load(null, null);
            }

            else if (rbtnSarf.Checked == true)
            {
                db.executedata("delete from Sanad_Sarf where convert(date,[Date],105) between N'" + date1 + "' and N'" + date2 + "'", "تم المسح بنجاح !");
                frm_Sanad_Kabd_Sarf_Report_Load(null, null);
            }

            }

            
        }
    }
}