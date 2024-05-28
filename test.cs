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
    public partial class test : Form
    {

        Database db = new Database();
        DataTable tbl = new DataTable();
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
           
            



            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            test1 frm = new test1();
            frm.ShowDialog();
            
            
            textBox1.Text = frm.dgv.CurrentRow.Cells[1].Value+"";
            textBox2.Text = frm.dgv.CurrentRow.Cells[2].Value+"";
            dg.Rows.Add(1);
            int index = dg.Rows.Count - 1;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dg.Rows.Clear();
        }
    }
}
