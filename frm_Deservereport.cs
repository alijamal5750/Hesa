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
    public partial class frm_Deservereport : DevExpress.XtraEditors.XtraForm
    {
        public frm_Deservereport()
        {
            InitializeComponent();
        }

        Database db = new Database();
        DataTable tbl = new DataTable();



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frm_Deservereport_Load(object sender, EventArgs e)
        {   
            //to display the actuly datatime in the machine when form is loaded

            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");
            tbl.Clear();
            tbl = db.readData("select Deserved.Des_ID as 'رقم المصروفة' , Price as 'ثمن المصروفة', Date as 'تاريخ المصروفة', Notes as 'ملاحظات' , Deserved_Type.Name as 'نوع المصروفة' from Deserved,Deserved_Type where Deserved.Type_ID=Deserved_Type.Des_ID and convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "");

            if (tbl.Rows.Count >= 1)
            {
                DgvSearch.DataSource = tbl;

                decimal sum = 0;

                for (int i = 0; i <= tbl.Rows.Count - 1; i++)
                {
                    //the plus value near (=) it is for sum (cell after cell)
                    sum += Convert.ToDecimal(tbl.Rows[i][1]);
                }

                //for the numbers display 2 numbers after dot ....
                txtTotal.Text = Math.Round(sum, 2).ToString();
            }

            //if there are no information to put in the sum function or the information was deleted by user 
            else
            {
                txtTotal.Text =" 0";
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd"); 

            if (MessageBox.Show("هل تريد حذف كل المصروفات؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.executedata("delete from Deserved where convert(date,Date,105) between '" + date1 + "' and '" + date2 + "' ", "تم الحذف بنجاح");
                txtTotal.Text = "0";
            }
        }
    }
}