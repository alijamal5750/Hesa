using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class test1 : Form
    {
        Database db = new Database();
        DataTable tbl = new DataTable();
        public test1()
        {
            InitializeComponent();
        }

        private void test1_Load(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select * from Users", "");
            dgv.DataSource = tbl;
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            test frm = new test();
            int index = frm.dg.Rows.Count - 1;
            frm.dg.Rows[index].Cells[0].Value = dgv.CurrentRow.Cells[1].Value;
            frm.dg.Rows[index].Cells[1].Value = dgv.CurrentRow.Cells[2].Value;
            Close();

           
        }
    }
}
