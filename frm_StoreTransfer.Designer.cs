namespace Sales_Management
{
    partial class frm_StoreTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StoreTransfer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cpxUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NudQty = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cpxStoreFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cpxProducts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cpxStoreTo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.NudSalePrice = new System.Windows.Forms.NumericUpDown();
            this.NudBuyPrice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudQty)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBuyPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cpxUnit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NudQty);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cpxStoreFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cpxProducts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 308);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المخزن المحول منه";
            // 
            // cpxUnit
            // 
            this.cpxUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxUnit.FormattingEnabled = true;
            this.cpxUnit.Location = new System.Drawing.Point(18, 263);
            this.cpxUnit.Name = "cpxUnit";
            this.cpxUnit.Size = new System.Drawing.Size(192, 27);
            this.cpxUnit.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(217, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 88;
            this.label5.Text = "الوحدة:";
            // 
            // NudQty
            // 
            this.NudQty.DecimalPlaces = 2;
            this.NudQty.Location = new System.Drawing.Point(18, 211);
            this.NudQty.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudQty.Name = "NudQty";
            this.NudQty.Size = new System.Drawing.Size(192, 27);
            this.NudQty.TabIndex = 57;
            this.NudQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(230, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 87;
            this.label4.Text = "الكمية:";
            // 
            // cpxStoreFrom
            // 
            this.cpxStoreFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStoreFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStoreFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStoreFrom.FormattingEnabled = true;
            this.cpxStoreFrom.Location = new System.Drawing.Point(18, 159);
            this.cpxStoreFrom.Name = "cpxStoreFrom";
            this.cpxStoreFrom.Size = new System.Drawing.Size(192, 27);
            this.cpxStoreFrom.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(216, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 19);
            this.label3.TabIndex = 85;
            this.label3.Text = "اسم المخزن المحول منه:";
            // 
            // cpxProducts
            // 
            this.cpxProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxProducts.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxProducts.FormattingEnabled = true;
            this.cpxProducts.Location = new System.Drawing.Point(18, 107);
            this.cpxProducts.Name = "cpxProducts";
            this.cpxProducts.Size = new System.Drawing.Size(192, 27);
            this.cpxProducts.TabIndex = 81;
            this.cpxProducts.SelectionChangeCommitted += new System.EventHandler(this.cpxProducts_SelectionChangeCommitted);
            this.cpxProducts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cpxProducts_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(219, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 84;
            this.label2.Text = "المنتج:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(18, 55);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(192, 27);
            this.txtBarcode.TabIndex = 83;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(219, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 82;
            this.label1.Text = "الباركود:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cpxStoreTo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 92);
            this.groupBox2.TabIndex = 90;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "المخزن المحول له";
            // 
            // cpxStoreTo
            // 
            this.cpxStoreTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStoreTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStoreTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStoreTo.FormattingEnabled = true;
            this.cpxStoreTo.Location = new System.Drawing.Point(6, 37);
            this.cpxStoreTo.Name = "cpxStoreTo";
            this.cpxStoreTo.Size = new System.Drawing.Size(192, 27);
            this.cpxStoreTo.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(204, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 19);
            this.label8.TabIndex = 85;
            this.label8.Text = "اسم المخزن المحول له:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtpDate);
            this.groupBox3.Controls.Add(this.txtReason);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.NudSalePrice);
            this.groupBox3.Controls.Add(this.NudBuyPrice);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(440, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 390);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بيانات العميلة:";
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(6, 156);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(221, 27);
            this.DtpDate.TabIndex = 92;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(6, 263);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(221, 104);
            this.txtReason.TabIndex = 92;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 210);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 27);
            this.txtName.TabIndex = 90;
            // 
            // NudSalePrice
            // 
            this.NudSalePrice.DecimalPlaces = 2;
            this.NudSalePrice.Location = new System.Drawing.Point(6, 108);
            this.NudSalePrice.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudSalePrice.Name = "NudSalePrice";
            this.NudSalePrice.Size = new System.Drawing.Size(221, 27);
            this.NudSalePrice.TabIndex = 91;
            this.NudSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudSalePrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudBuyPrice
            // 
            this.NudBuyPrice.DecimalPlaces = 2;
            this.NudBuyPrice.Location = new System.Drawing.Point(6, 56);
            this.NudBuyPrice.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudBuyPrice.Name = "NudBuyPrice";
            this.NudBuyPrice.Size = new System.Drawing.Size(221, 27);
            this.NudBuyPrice.TabIndex = 90;
            this.NudBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudBuyPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(233, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 88;
            this.label6.Text = "سبب التحويل:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(233, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 87;
            this.label7.Text = "المسؤول عن التحويل:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(230, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 85;
            this.label9.Text = "التاريخ:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(233, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 19);
            this.label10.TabIndex = 84;
            this.label10.Text = "سعر البيع:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(233, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 19);
            this.label11.TabIndex = 82;
            this.label11.Text = "سعر الشراء:";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnAdd.Location = new System.Drawing.Point(585, 408);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(221, 32);
            this.btnAdd.TabIndex = 91;
            this.btnAdd.Text = "اتمام العميلة";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frm_StoreTransfer
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(824, 451);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_StoreTransfer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة تحويل المنتجات بين المخازن";
            this.Load += new System.EventHandler(this.frm_StoreTransfer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudQty)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBuyPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cpxProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cpxStoreFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudQty;
        private System.Windows.Forms.ComboBox cpxUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cpxStoreTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown NudSalePrice;
        private System.Windows.Forms.NumericUpDown NudBuyPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtReason;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.DateTimePicker DtpDate;
    }
}