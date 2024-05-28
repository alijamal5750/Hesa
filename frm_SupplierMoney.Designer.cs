namespace Sales_Management
{
    partial class frm_SupplierMoney
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SupplierMoney));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DgvSearch = new System.Windows.Forms.DataGridView();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.rbtnAllSup = new System.Windows.Forms.RadioButton();
            this.rbtnOneSup = new System.Windows.Forms.RadioButton();
            this.cpxSuppliers = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NudMiniQty = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnPayAll = new System.Windows.Forms.RadioButton();
            this.rbtnPayPart = new System.Windows.Forms.RadioButton();
            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudMiniQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(377, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "المبالغ المتبقية للموردين";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.DgvSearch);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.rbtnAllSup);
            this.groupBox1.Controls.Add(this.rbtnOneSup);
            this.groupBox1.Controls.Add(this.cpxSuppliers);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(938, 456);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(738, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 56);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // DgvSearch
            // 
            this.DgvSearch.AllowUserToAddRows = false;
            this.DgvSearch.AllowUserToDeleteRows = false;
            this.DgvSearch.AllowUserToResizeColumns = false;
            this.DgvSearch.AllowUserToResizeRows = false;
            this.DgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSearch.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSearch.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSearch.Location = new System.Drawing.Point(6, 75);
            this.DgvSearch.Name = "DgvSearch";
            this.DgvSearch.ReadOnly = true;
            this.DgvSearch.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSearch.Size = new System.Drawing.Size(926, 374);
            this.DgvSearch.TabIndex = 45;
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnNew.Location = new System.Drawing.Point(127, 31);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(250, 32);
            this.btnNew.TabIndex = 43;
            this.btnNew.Text = "بحث";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // rbtnAllSup
            // 
            this.rbtnAllSup.AutoSize = true;
            this.rbtnAllSup.Checked = true;
            this.rbtnAllSup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnAllSup.Location = new System.Drawing.Point(837, 39);
            this.rbtnAllSup.Name = "rbtnAllSup";
            this.rbtnAllSup.Size = new System.Drawing.Size(95, 23);
            this.rbtnAllSup.TabIndex = 42;
            this.rbtnAllSup.TabStop = true;
            this.rbtnAllSup.Text = "كل الموردين";
            this.rbtnAllSup.UseVisualStyleBackColor = true;
            // 
            // rbtnOneSup
            // 
            this.rbtnOneSup.AutoSize = true;
            this.rbtnOneSup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnOneSup.Location = new System.Drawing.Point(744, 39);
            this.rbtnOneSup.Name = "rbtnOneSup";
            this.rbtnOneSup.Size = new System.Drawing.Size(87, 23);
            this.rbtnOneSup.TabIndex = 41;
            this.rbtnOneSup.Text = "مورد محدد";
            this.rbtnOneSup.UseVisualStyleBackColor = true;
            // 
            // cpxSuppliers
            // 
            this.cpxSuppliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxSuppliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxSuppliers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxSuppliers.FormattingEnabled = true;
            this.cpxSuppliers.Location = new System.Drawing.Point(494, 35);
            this.cpxSuppliers.Name = "cpxSuppliers";
            this.cpxSuppliers.Size = new System.Drawing.Size(244, 27);
            this.cpxSuppliers.TabIndex = 23;
            this.cpxSuppliers.SelectedIndexChanged += new System.EventHandler(this.cbxItems_SelectedIndexChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(793, 536);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(151, 27);
            this.txtTotal.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(694, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "اجمالي المبالغ:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NudMiniQty);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.rbtnPayAll);
            this.groupBox3.Controls.Add(this.rbtnPayPart);
            this.groupBox3.Location = new System.Drawing.Point(12, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(532, 59);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // NudMiniQty
            // 
            this.NudMiniQty.DecimalPlaces = 3;
            this.NudMiniQty.Location = new System.Drawing.Point(6, 26);
            this.NudMiniQty.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudMiniQty.Name = "NudMiniQty";
            this.NudMiniQty.Size = new System.Drawing.Size(226, 27);
            this.NudMiniQty.TabIndex = 46;
            this.NudMiniQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudMiniQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(49, 466);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 56);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            // 
            // rbtnPayAll
            // 
            this.rbtnPayAll.AutoSize = true;
            this.rbtnPayAll.Checked = true;
            this.rbtnPayAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPayAll.Location = new System.Drawing.Point(387, 30);
            this.rbtnPayAll.Name = "rbtnPayAll";
            this.rbtnPayAll.Size = new System.Drawing.Size(137, 23);
            this.rbtnPayAll.TabIndex = 45;
            this.rbtnPayAll.TabStop = true;
            this.rbtnPayAll.Text = "تسديد المبلغ بالكامل";
            this.rbtnPayAll.UseVisualStyleBackColor = true;
            // 
            // rbtnPayPart
            // 
            this.rbtnPayPart.AutoSize = true;
            this.rbtnPayPart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPayPart.Location = new System.Drawing.Point(238, 30);
            this.rbtnPayPart.Name = "rbtnPayPart";
            this.rbtnPayPart.Size = new System.Drawing.Size(143, 23);
            this.rbtnPayPart.TabIndex = 44;
            this.rbtnPayPart.Text = "تسديد جزء من المبلغ";
            this.rbtnPayPart.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Appearance.Options.UseFont = true;
            this.btnPay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.ImageOptions.Image")));
            this.btnPay.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnPay.Location = new System.Drawing.Point(544, 538);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(131, 27);
            this.btnPay.TabIndex = 46;
            this.btnPay.Text = "تسديد";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(20, 12);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(120, 27);
            this.DtpDate.TabIndex = 47;
            this.DtpDate.Visible = false;
            // 
            // frm_SupplierMoney
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(962, 582);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SupplierMoney";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حسابات الموردين آجل";
            this.Load += new System.EventHandler(this.frm_SupplierMoney_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudMiniQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cpxSuppliers;
        private System.Windows.Forms.RadioButton rbtnAllSup;
        private System.Windows.Forms.RadioButton rbtnOneSup;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.DataGridView DgvSearch;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnPayAll;
        private System.Windows.Forms.RadioButton rbtnPayPart;
        private System.Windows.Forms.NumericUpDown NudMiniQty;
        private DevExpress.XtraEditors.SimpleButton btnPay;
        private System.Windows.Forms.DateTimePicker DtpDate;
    }
}