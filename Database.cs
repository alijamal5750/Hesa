using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sales_Management
{
    class Database
    {   
        //connection to database
        SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Sales_System; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        //function to readdata from the database
        public DataTable readData(string stmt,string message)
        {

            DataTable tbl = new DataTable();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = stmt;
                conn.Open();

                //load data from the database to the datatable(tbl)
                tbl.Load(cmd.ExecuteReader());

                conn.Close();
                if (message != "")
                {
                    MessageBox.Show(message, "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return tbl;
        }


        //function to insert,update,delete data from the database 
        public bool executedata(string stmt,string message)
        {
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = stmt;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
                if (message != "")
                {
                    MessageBox.Show(message, "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                conn.Close();
            }
        }
        

    }
}
