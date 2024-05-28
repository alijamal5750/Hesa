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
    public partial class frm_fast : DevExpress.XtraEditors.XtraForm
    {

        Database db = new Database();
        DataTable tbl = new DataTable();

        public frm_fast()
        {
            InitializeComponent();
        }

        private void frm_fast_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select * from Products where Pro_Name like '%"+textBox1.Text+"%'  ", "");
            DgvSearch.DataSource = tbl;
        }
    }
}