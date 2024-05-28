namespace Sales_Management
{
    partial class frm_StockTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StockTransfer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMoney2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cpxStockTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMoney1 = new System.Windows.Forms.Label();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.NudPrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cpxStockFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMoney2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cpxStockTo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblMoney1);
            this.groupBox1.Controls.Add(this.btnTransfer);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DtpDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NudPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cpxStockFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 508);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات التحويل";
            // 
            // lblMoney2
            // 
            this.lblMoney2.AutoSize = true;
            this.lblMoney2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMoney2.Location = new System.Drawing.Point(64, 175);
            this.lblMoney2.Name = "lblMoney2";
            this.lblMoney2.Size = new System.Drawing.Size(33, 19);
            this.lblMoney2.TabIndex = 33;
            this.lblMoney2.Text = "......";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(103, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 19);
            this.label9.TabIndex = 32;
            this.label9.Text = "رصيد الخزنة الحالي هو:";
            // 
            // cpxStockTo
            // 
            this.cpxStockTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpxStockTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStockTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStockTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpxStockTo.FormattingEnabled = true;
            this.cpxStockTo.Location = new System.Drawing.Point(11, 141);
            this.cpxStockTo.Name = "cpxStockTo";
            this.cpxStockTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cpxStockTo.Size = new System.Drawing.Size(235, 27);
            this.cpxStockTo.TabIndex = 30;
            this.cpxStockTo.SelectionChangeCommitted += new System.EventHandler(this.cpxStockTo_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(250, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "تحويل الى خزنة:";
            // 
            // lblMoney1
            // 
            this.lblMoney1.AutoSize = true;
            this.lblMoney1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMoney1.Location = new System.Drawing.Point(66, 88);
            this.lblMoney1.Name = "lblMoney1";
            this.lblMoney1.Size = new System.Drawing.Size(33, 19);
            this.lblMoney1.TabIndex = 29;
            this.lblMoney1.Text = "......";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Appearance.Options.UseFont = true;
            this.btnTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.Image")));
            this.btnTransfer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnTransfer.Location = new System.Drawing.Point(3, 470);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(238, 32);
            this.btnTransfer.TabIndex = 28;
            this.btnTransfer.Text = "تحويل";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(3, 366);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(238, 87);
            this.txtReason.TabIndex = 27;
            this.txtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(256, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "سبب التحويل:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 322);
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(238, 27);
            this.txtName.TabIndex = 25;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(256, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "اسم المحول:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(247, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "تاريخ التحويل:";
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(6, 271);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(235, 27);
            this.DtpDate.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(247, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "مبلغ التحويل:";
            // 
            // NudPrice
            // 
            this.NudPrice.DecimalPlaces = 3;
            this.NudPrice.Location = new System.Drawing.Point(6, 222);
            this.NudPrice.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudPrice.Name = "NudPrice";
            this.NudPrice.Size = new System.Drawing.Size(235, 27);
            this.NudPrice.TabIndex = 20;
            this.NudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(105, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "رصيد الخزنة الحالي هو:";
            // 
            // cpxStockFrom
            // 
            this.cpxStockFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpxStockFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStockFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStockFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpxStockFrom.FormattingEnabled = true;
            this.cpxStockFrom.Location = new System.Drawing.Point(11, 48);
            this.cpxStockFrom.Name = "cpxStockFrom";
            this.cpxStockFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cpxStockFrom.Size = new System.Drawing.Size(235, 27);
            this.cpxStockFrom.TabIndex = 17;
            this.cpxStockFrom.SelectionChangeCommitted += new System.EventHandler(this.cpxStockFrom_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(250, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "تحويل من خزنة:";
            // 
            // frm_StockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 532);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_StockTransfer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحويل رصيد بين الخزنات";
            this.Load += new System.EventHandler(this.frm_StockTransfer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMoney1;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NudPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cpxStockFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMoney2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cpxStockTo;
        private System.Windows.Forms.Label label7;
    }
}