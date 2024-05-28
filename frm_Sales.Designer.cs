namespace Sales_Management
{
    partial class frm_Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Sales));
            this.DgvSale = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الوحدة = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpDateReminder = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteItems = new DevExpress.XtraEditors.SimpleButton();
            this.btnItems = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxItems = new System.Windows.Forms.ComboBox();
            this.btnCustomersBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.CpxCustomers = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.rbtnCustAagel = new System.Windows.Forms.RadioButton();
            this.rbtnCustNakdy = new System.Windows.Forms.RadioButton();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rbtnnakdyname = new System.Windows.Forms.RadioButton();
            this.CpxCustomers2 = new System.Windows.Forms.ComboBox();
            this.btn2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSale)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvSale
            // 
            this.DgvSale.AllowUserToAddRows = false;
            this.DgvSale.AllowUserToDeleteRows = false;
            this.DgvSale.AllowUserToResizeColumns = false;
            this.DgvSale.AllowUserToResizeRows = false;
            this.DgvSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSale.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSale.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.الوحدة,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSale.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSale.Location = new System.Drawing.Point(17, 158);
            this.DgvSale.Name = "DgvSale";
            this.DgvSale.ReadOnly = true;
            this.DgvSale.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvSale.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvSale.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSale.Size = new System.Drawing.Size(1037, 407);
            this.DgvSale.TabIndex = 52;
            this.DgvSale.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSale_CellValueChanged);
            this.DgvSale.DoubleClick += new System.EventHandler(this.DgvSale_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "رقم المنتج";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "اسم المنتج";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // الوحدة
            // 
            this.الوحدة.HeaderText = "الوحدة";
            this.الوحدة.Name = "الوحدة";
            this.الوحدة.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "الكمية";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "السعر شامل الضريبة";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "الخصم";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "الاجمالي";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(534, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 21);
            this.label10.TabIndex = 51;
            this.label10.Text = "لتعديل الكمية دبل كلك او F11";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(287, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 21);
            this.label9.TabIndex = 50;
            this.label9.Text = "لدفع و حفظ و طباعة الفاتورة اضغط F12";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(343, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 21);
            this.label8.TabIndex = 49;
            this.label8.Text = "F1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(851, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 21);
            this.label7.TabIndex = 48;
            this.label7.Text = "Delete";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(758, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 21);
            this.label6.TabIndex = 47;
            this.label6.Text = "F2";
            // 
            // DtpDateReminder
            // 
            this.DtpDateReminder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDateReminder.Location = new System.Drawing.Point(898, 44);
            this.DtpDateReminder.Name = "DtpDateReminder";
            this.DtpDateReminder.Size = new System.Drawing.Size(131, 27);
            this.DtpDateReminder.TabIndex = 46;
            // 
            // btnDeleteItems
            // 
            this.btnDeleteItems.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItems.Appearance.Options.UseFont = true;
            this.btnDeleteItems.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItems.ImageOptions.Image")));
            this.btnDeleteItems.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDeleteItems.Location = new System.Drawing.Point(800, 115);
            this.btnDeleteItems.Name = "btnDeleteItems";
            this.btnDeleteItems.Size = new System.Drawing.Size(45, 27);
            this.btnDeleteItems.TabIndex = 45;
            this.btnDeleteItems.Click += new System.EventHandler(this.btnDeleteItems_Click);
            // 
            // btnItems
            // 
            this.btnItems.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Appearance.Options.UseFont = true;
            this.btnItems.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnItems.ImageOptions.Image")));
            this.btnItems.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnItems.Location = new System.Drawing.Point(707, 115);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(45, 27);
            this.btnItems.TabIndex = 44;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(429, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 43;
            this.label5.Text = "اختر منتج:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(449, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 42;
            // 
            // cbxItems
            // 
            this.cbxItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxItems.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbxItems.FormattingEnabled = true;
            this.cbxItems.Location = new System.Drawing.Point(506, 115);
            this.cbxItems.Name = "cbxItems";
            this.cbxItems.Size = new System.Drawing.Size(195, 27);
            this.cbxItems.TabIndex = 41;
            // 
            // btnCustomersBrowse
            // 
            this.btnCustomersBrowse.Location = new System.Drawing.Point(814, 19);
            this.btnCustomersBrowse.Name = "btnCustomersBrowse";
            this.btnCustomersBrowse.Size = new System.Drawing.Size(31, 27);
            this.btnCustomersBrowse.TabIndex = 40;
            this.btnCustomersBrowse.Text = "....";
            this.btnCustomersBrowse.Click += new System.EventHandler(this.btnCustomersBrowse_Click);
            // 
            // CpxCustomers
            // 
            this.CpxCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CpxCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CpxCustomers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CpxCustomers.FormattingEnabled = true;
            this.CpxCustomers.Location = new System.Drawing.Point(613, 19);
            this.CpxCustomers.Name = "CpxCustomers";
            this.CpxCustomers.Size = new System.Drawing.Size(195, 27);
            this.CpxCustomers.TabIndex = 38;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(111, 118);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBarcode.Size = new System.Drawing.Size(226, 27);
            this.txtBarcode.TabIndex = 34;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(15, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 37;
            this.label2.Text = "باركود المنتج:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 36;
            this.label3.Text = "رقم الفاتورة:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(111, 68);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(170, 27);
            this.txtID.TabIndex = 35;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnCustAagel
            // 
            this.rbtnCustAagel.AutoSize = true;
            this.rbtnCustAagel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnCustAagel.Location = new System.Drawing.Point(526, 20);
            this.rbtnCustAagel.Name = "rbtnCustAagel";
            this.rbtnCustAagel.Size = new System.Drawing.Size(81, 23);
            this.rbtnCustAagel.TabIndex = 53;
            this.rbtnCustAagel.Text = "عميل آجل";
            this.rbtnCustAagel.UseVisualStyleBackColor = true;
            this.rbtnCustAagel.CheckedChanged += new System.EventHandler(this.rbtnCustAagel_CheckedChanged);
            // 
            // rbtnCustNakdy
            // 
            this.rbtnCustNakdy.AutoSize = true;
            this.rbtnCustNakdy.Checked = true;
            this.rbtnCustNakdy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnCustNakdy.Location = new System.Drawing.Point(28, 20);
            this.rbtnCustNakdy.Name = "rbtnCustNakdy";
            this.rbtnCustNakdy.Size = new System.Drawing.Size(88, 23);
            this.rbtnCustNakdy.TabIndex = 54;
            this.rbtnCustNakdy.TabStop = true;
            this.rbtnCustNakdy.Text = "عميل نقدي";
            this.rbtnCustNakdy.UseVisualStyleBackColor = true;
            this.rbtnCustNakdy.CheckedChanged += new System.EventHandler(this.rbtnCustNakdy_CheckedChanged);
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblItemsCount.Location = new System.Drawing.Point(115, 593);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(27, 21);
            this.lblItemsCount.TabIndex = 60;
            this.lblItemsCount.Text = "....";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(17, 594);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 21);
            this.label14.TabIndex = 59;
            this.label14.Text = "عدد المنتجات:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(759, 588);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 62;
            this.label15.Text = "اجمالي المطلوب:";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(869, 571);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(185, 56);
            this.txtTotal.TabIndex = 61;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(910, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 19);
            this.label13.TabIndex = 63;
            this.label13.Text = "تاريخ الاستحقاق:";
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(923, 115);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(131, 27);
            this.DtpDate.TabIndex = 64;
            this.DtpDate.Visible = false;
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp.Location = new System.Drawing.Point(570, 588);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(131, 27);
            this.dtp.TabIndex = 65;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(531, 571);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(185, 56);
            this.textBox1.TabIndex = 66;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnnakdyname
            // 
            this.rbtnnakdyname.AutoSize = true;
            this.rbtnnakdyname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnnakdyname.Location = new System.Drawing.Point(135, 20);
            this.rbtnnakdyname.Name = "rbtnnakdyname";
            this.rbtnnakdyname.Size = new System.Drawing.Size(117, 23);
            this.rbtnnakdyname.TabIndex = 67;
            this.rbtnnakdyname.Text = "عميل نقدي بأسم";
            this.rbtnnakdyname.UseVisualStyleBackColor = true;
            this.rbtnnakdyname.CheckedChanged += new System.EventHandler(this.rbtnnakdyname_CheckedChanged);
            // 
            // CpxCustomers2
            // 
            this.CpxCustomers2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CpxCustomers2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CpxCustomers2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CpxCustomers2.FormattingEnabled = true;
            this.CpxCustomers2.Location = new System.Drawing.Point(254, 19);
            this.CpxCustomers2.Name = "CpxCustomers2";
            this.CpxCustomers2.Size = new System.Drawing.Size(195, 27);
            this.CpxCustomers2.TabIndex = 68;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(455, 19);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(31, 27);
            this.btn2.TabIndex = 69;
            this.btn2.Text = "....";
            this.btn2.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // frm_Sales
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1066, 635);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.CpxCustomers2);
            this.Controls.Add(this.rbtnnakdyname);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblItemsCount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.rbtnCustNakdy);
            this.Controls.Add(this.rbtnCustAagel);
            this.Controls.Add(this.DgvSale);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtpDateReminder);
            this.Controls.Add(this.btnDeleteItems);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxItems);
            this.Controls.Add(this.btnCustomersBrowse);
            this.Controls.Add(this.CpxCustomers);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Sales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " نافذة المبيعات";
            this.Load += new System.EventHandler(this.frm_Sales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Sales_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DgvSale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpDateReminder;
        private DevExpress.XtraEditors.SimpleButton btnDeleteItems;
        private DevExpress.XtraEditors.SimpleButton btnItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxItems;
        private DevExpress.XtraEditors.SimpleButton btnCustomersBrowse;
        public System.Windows.Forms.ComboBox CpxCustomers;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RadioButton rbtnCustAagel;
        private System.Windows.Forms.RadioButton rbtnCustNakdy;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn الوحدة;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rbtnnakdyname;
        public System.Windows.Forms.ComboBox CpxCustomers2;
        private DevExpress.XtraEditors.SimpleButton btn2;
    }
}