namespace Sales_Management
{
    partial class frm_productsTransferReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_productsTransferReport));
            this.label3 = new System.Windows.Forms.Label();
            this.DgvSearch = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.rbtnAllStoreFrom = new System.Windows.Forms.RadioButton();
            this.rbtnOneStoreFrom = new System.Windows.Forms.RadioButton();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cpxStoreFrom = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.rbtnAllStoreTo = new System.Windows.Forms.RadioButton();
            this.rbtnSingleStoreTo = new System.Windows.Forms.RadioButton();
            this.cpxStoreTo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(860, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 19);
            this.label3.TabIndex = 70;
            this.label3.Text = "اجمالي الكميات المحولة:";
            // 
            // DgvSearch
            // 
            this.DgvSearch.AllowUserToAddRows = false;
            this.DgvSearch.AllowUserToDeleteRows = false;
            this.DgvSearch.AllowUserToResizeColumns = false;
            this.DgvSearch.AllowUserToResizeRows = false;
            this.DgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.DgvSearch.Location = new System.Drawing.Point(6, 13);
            this.DgvSearch.Name = "DgvSearch";
            this.DgvSearch.ReadOnly = true;
            this.DgvSearch.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSearch.Size = new System.Drawing.Size(1166, 385);
            this.DgvSearch.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(930, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 19);
            this.label4.TabIndex = 59;
            this.label4.Text = "من:";
            // 
            // DtpFrom
            // 
            this.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFrom.Location = new System.Drawing.Point(976, 82);
            this.DtpFrom.Name = "DtpFrom";
            this.DtpFrom.Size = new System.Drawing.Size(208, 27);
            this.DtpFrom.TabIndex = 62;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(738, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 56);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(480, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 31);
            this.label2.TabIndex = 65;
            this.label2.Text = "اجمالي المنتجات المحولة";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnSearch.Location = new System.Drawing.Point(486, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(222, 28);
            this.btnSearch.TabIndex = 43;
            this.btnSearch.Text = "بحث";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbtnAllStoreFrom
            // 
            this.rbtnAllStoreFrom.AutoSize = true;
            this.rbtnAllStoreFrom.Checked = true;
            this.rbtnAllStoreFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnAllStoreFrom.Location = new System.Drawing.Point(328, 41);
            this.rbtnAllStoreFrom.Name = "rbtnAllStoreFrom";
            this.rbtnAllStoreFrom.Size = new System.Drawing.Size(89, 23);
            this.rbtnAllStoreFrom.TabIndex = 42;
            this.rbtnAllStoreFrom.TabStop = true;
            this.rbtnAllStoreFrom.Text = "كل المخازن";
            this.rbtnAllStoreFrom.UseVisualStyleBackColor = true;
            // 
            // rbtnOneStoreFrom
            // 
            this.rbtnOneStoreFrom.AutoSize = true;
            this.rbtnOneStoreFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnOneStoreFrom.Location = new System.Drawing.Point(231, 41);
            this.rbtnOneStoreFrom.Name = "rbtnOneStoreFrom";
            this.rbtnOneStoreFrom.Size = new System.Drawing.Size(91, 23);
            this.rbtnOneStoreFrom.TabIndex = 41;
            this.rbtnOneStoreFrom.Text = "مخزن محدد";
            this.rbtnOneStoreFrom.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(1016, 592);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(168, 27);
            this.txtTotal.TabIndex = 71;
            // 
            // cpxStoreFrom
            // 
            this.cpxStoreFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStoreFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStoreFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStoreFrom.FormattingEnabled = true;
            this.cpxStoreFrom.Location = new System.Drawing.Point(6, 37);
            this.cpxStoreFrom.Name = "cpxStoreFrom";
            this.cpxStoreFrom.Size = new System.Drawing.Size(219, 27);
            this.cpxStoreFrom.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvSearch);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 404);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(929, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 60;
            this.label1.Text = "الى:";
            // 
            // DtpTo
            // 
            this.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpTo.Location = new System.Drawing.Point(976, 129);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(208, 27);
            this.DtpTo.TabIndex = 63;
            // 
            // rbtnAllStoreTo
            // 
            this.rbtnAllStoreTo.AutoSize = true;
            this.rbtnAllStoreTo.Checked = true;
            this.rbtnAllStoreTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnAllStoreTo.Location = new System.Drawing.Point(319, 41);
            this.rbtnAllStoreTo.Name = "rbtnAllStoreTo";
            this.rbtnAllStoreTo.Size = new System.Drawing.Size(89, 23);
            this.rbtnAllStoreTo.TabIndex = 76;
            this.rbtnAllStoreTo.TabStop = true;
            this.rbtnAllStoreTo.Text = "كل المخازن";
            this.rbtnAllStoreTo.UseVisualStyleBackColor = true;
            // 
            // rbtnSingleStoreTo
            // 
            this.rbtnSingleStoreTo.AutoSize = true;
            this.rbtnSingleStoreTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnSingleStoreTo.Location = new System.Drawing.Point(222, 38);
            this.rbtnSingleStoreTo.Name = "rbtnSingleStoreTo";
            this.rbtnSingleStoreTo.Size = new System.Drawing.Size(91, 23);
            this.rbtnSingleStoreTo.TabIndex = 75;
            this.rbtnSingleStoreTo.Text = "مخزن محدد";
            this.rbtnSingleStoreTo.UseVisualStyleBackColor = true;
            // 
            // cpxStoreTo
            // 
            this.cpxStoreTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStoreTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStoreTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStoreTo.FormattingEnabled = true;
            this.cpxStoreTo.Location = new System.Drawing.Point(6, 37);
            this.cpxStoreTo.Name = "cpxStoreTo";
            this.cpxStoreTo.Size = new System.Drawing.Size(210, 27);
            this.cpxStoreTo.TabIndex = 74;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnAllStoreFrom);
            this.groupBox3.Controls.Add(this.rbtnOneStoreFrom);
            this.groupBox3.Controls.Add(this.cpxStoreFrom);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(12, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 100);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "المخازن المحولة منها";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnAllStoreTo);
            this.groupBox4.Controls.Add(this.rbtnSingleStoreTo);
            this.groupBox4.Controls.Add(this.cpxStoreTo);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(486, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(423, 100);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "المخازن المحولة لها";
            // 
            // frm_productsTransferReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 634);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_productsTransferReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة تقرير تحويل المنتجات بين المخازن";
            this.Load += new System.EventHandler(this.frm_productsTransferReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.RadioButton rbtnAllStoreFrom;
        private System.Windows.Forms.RadioButton rbtnOneStoreFrom;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cpxStoreFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.RadioButton rbtnAllStoreTo;
        private System.Windows.Forms.RadioButton rbtnSingleStoreTo;
        private System.Windows.Forms.ComboBox cpxStoreTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}