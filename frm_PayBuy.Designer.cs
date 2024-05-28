namespace Sales_Management
{
    partial class frm_PayBuy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PayBuy));
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.txtBakey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMadfou3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatloub = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.ImageOptions.Image")));
            this.btnReturn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnReturn.Location = new System.Drawing.Point(85, 243);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(226, 32);
            this.btnReturn.TabIndex = 32;
            this.btnReturn.Text = "رجوع";
            this.btnReturn.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Appearance.Options.UseFont = true;
            this.btnEnter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnter.ImageOptions.Image")));
            this.btnEnter.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnEnter.Location = new System.Drawing.Point(85, 198);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(226, 32);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "للحفظ و الطباعة اضغط انتر";
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtBakey
            // 
            this.txtBakey.Location = new System.Drawing.Point(85, 146);
            this.txtBakey.Name = "txtBakey";
            this.txtBakey.ReadOnly = true;
            this.txtBakey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBakey.Size = new System.Drawing.Size(226, 30);
            this.txtBakey.TabIndex = 4;
            this.txtBakey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBakey.TextChanged += new System.EventHandler(this.txtBakey_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(21, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "الباقي:";
            // 
            // txtMadfou3
            // 
            this.txtMadfou3.Location = new System.Drawing.Point(85, 77);
            this.txtMadfou3.Name = "txtMadfou3";
            this.txtMadfou3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMadfou3.Size = new System.Drawing.Size(226, 30);
            this.txtMadfou3.TabIndex = 0;
            this.txtMadfou3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMadfou3.TextChanged += new System.EventHandler(this.txtMadfou3_TextChanged);
            this.txtMadfou3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMadfou3_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "المطلوب:";
            // 
            // txtMatloub
            // 
            this.txtMatloub.Location = new System.Drawing.Point(85, 12);
            this.txtMatloub.Name = "txtMatloub";
            this.txtMatloub.ReadOnly = true;
            this.txtMatloub.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatloub.Size = new System.Drawing.Size(226, 30);
            this.txtMatloub.TabIndex = 27;
            this.txtMatloub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "المدفوع:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(19, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "Enter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(32, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "F12";
            // 
            // frm_PayBuy
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(333, 287);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtBakey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMadfou3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatloub);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_PayBuy";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_PayBuy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PayBuy_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
        private System.Windows.Forms.TextBox txtBakey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMadfou3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatloub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}