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
    public partial class frm_Serial : DevExpress.XtraEditors.XtraForm
    {
        public frm_Serial()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == "")
            {
                MessageBox.Show("رجاءا قم بأدخال الرقم التسلسلي", "تنبيه!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtkey.Text == x)
            {
                Properties.Settings.Default.Product_Key = "Yes";
                Properties.Settings.Default.Save();
                MessageBox.Show("تم تفعيل البرنامج بنجاح!", "تأكيد !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("كود التفعيل غير صحيح", "تنبيه !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
        }


        private string Identifier(string wmiclass, string wmiproperty)
        {
            //return hardware identifier 

            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiclass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            { 
            //only get the first one 
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiproperty].ToString();
                        break;
                    }
                    catch (Exception) { }
                }
            }
            return result; ;
        }

        string x = "0";
        private void frm_Serial_Load(object sender, EventArgs e)
        {
            string si = Identifier("Win32_DiskDrive", "SerialNumber");
          string signature=Identifier("Win32_DiskDrive","signature");
          label2.Text = signature;
          x =("99" + "29" + signature + "25" + signature + "8").ToString();
          label1.Text ="8" + "99" + si + "29" + "99";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }
    }
}