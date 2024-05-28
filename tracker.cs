using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Sales_Management
{
    class tracker
    {
        Database db = new Database();

        public void TrackerInsert(string Frm,string Notes,string Ord)
        {
            db.executedata("insert into Tra (Frm,Notes,Ord,Date_Added,Ti,User_ID) values (N'"+Frm+"',N'"+Notes+"',N'"+Ord+"',N'"+DateTime.Now.ToString("dd/MM/yyyy")+"',N'"+DateTime.Now.ToShortTimeString()+"',"+Properties.Settings.Default.User_ID+") ","");
        }

    }
}
    
