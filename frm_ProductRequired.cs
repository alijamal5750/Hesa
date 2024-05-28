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
    public partial class frm_ProductRequired : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_ProductRequired()
        {
            InitializeComponent();
        }

        private void frm_ProductRequired_Load(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select Pro_Name as 'اسم المنتج',Qty as'الكمية المتوفرة للمنتج',MinyQty as'حد الطلب' from Products where MinyQty >=1 and Qty <=MinyQty", "");
            DgvSearch.DataSource = tbl;
            txtTotal.Text = tbl.Rows.Count+"";
        }
    }
}