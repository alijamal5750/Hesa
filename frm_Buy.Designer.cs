namespace Sales_Management
{
    partial class frm_Buy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Buy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cpxSupplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSupplierBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxItems = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnItems = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteItems = new DevExpress.XtraEditors.SimpleButton();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DgvBuy = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.rbtnAagel = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.DtpAagel = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cpxStore = new System.Windows.Forms.ComboBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(15, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "رقم الفاتورة:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(102, 50);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(226, 27);
            this.txtID.TabIndex = 13;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(102, 83);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBarcode.Size = new System.Drawing.Size(226, 27);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "باركود المنتج:";
            // 
            // cpxSupplier
            // 
            this.cpxSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxSupplier.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxSupplier.FormattingEnabled = true;
            this.cpxSupplier.Location = new System.Drawing.Point(456, 25);
            this.cpxSupplier.Name = "cpxSupplier";
            this.cpxSupplier.Size = new System.Drawing.Size(195, 27);
            this.cpxSupplier.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(399, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "المورد:";
            // 
            // btnSupplierBrowse
            // 
            this.btnSupplierBrowse.Location = new System.Drawing.Point(657, 25);
            this.btnSupplierBrowse.Name = "btnSupplierBrowse";
            this.btnSupplierBrowse.Size = new System.Drawing.Size(45, 27);
            this.btnSupplierBrowse.TabIndex = 19;
            this.btnSupplierBrowse.Text = "....";
            this.btnSupplierBrowse.Click += new System.EventHandler(this.btnSupplierBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(399, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 21;
            // 
            // cbxItems
            // 
            this.cbxItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxItems.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbxItems.FormattingEnabled = true;
            this.cbxItems.Location = new System.Drawing.Point(456, 83);
            this.cbxItems.Name = "cbxItems";
            this.cbxItems.Size = new System.Drawing.Size(195, 27);
            this.cbxItems.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(379, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "اختر منتج:";
            // 
            // btnItems
            // 
            this.btnItems.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Appearance.Options.UseFont = true;
            this.btnItems.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnItems.ImageOptions.Image")));
            this.btnItems.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnItems.Location = new System.Drawing.Point(657, 83);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(45, 27);
            this.btnItems.TabIndex = 23;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnDeleteItems
            // 
            this.btnDeleteItems.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItems.Appearance.Options.UseFont = true;
            this.btnDeleteItems.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItems.ImageOptions.Image")));
            this.btnDeleteItems.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDeleteItems.Location = new System.Drawing.Point(755, 83);
            this.btnDeleteItems.Name = "btnDeleteItems";
            this.btnDeleteItems.Size = new System.Drawing.Size(45, 27);
            this.btnDeleteItems.TabIndex = 24;
            this.btnDeleteItems.Click += new System.EventHandler(this.btnDeleteItems_Click);
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(871, 83);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(120, 27);
            this.DtpDate.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(708, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "F2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(806, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = "Delete";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(334, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 21);
            this.label8.TabIndex = 30;
            this.label8.Text = "F1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(737, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 21);
            this.label9.TabIndex = 31;
            this.label9.Text = "لدفع و حفظ و طباعة الفاتورة اضغط F12";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(738, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "لتعديل الكمية دبل كلك او F11";
            // 
            // DgvBuy
            // 
            this.DgvBuy.AllowUserToAddRows = false;
            this.DgvBuy.AllowUserToDeleteRows = false;
            this.DgvBuy.AllowUserToResizeColumns = false;
            this.DgvBuy.AllowUserToResizeRows = false;
            this.DgvBuy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvBuy.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvBuy.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvBuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBuy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
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
            this.DgvBuy.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvBuy.Location = new System.Drawing.Point(10, 128);
            this.DgvBuy.Name = "DgvBuy";
            this.DgvBuy.ReadOnly = true;
            this.DgvBuy.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvBuy.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvBuy.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvBuy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBuy.Size = new System.Drawing.Size(981, 390);
            this.DgvBuy.TabIndex = 33;
            this.DgvBuy.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBuy_CellValueChanged);
            this.DgvBuy.DoubleClick += new System.EventHandler(this.DgvBuy_DoubleClick);
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
            // Column7
            // 
            this.Column7.HeaderText = "الوحدة";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
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
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblItemsCount.Location = new System.Drawing.Point(102, 555);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(27, 21);
            this.lblItemsCount.TabIndex = 37;
            this.lblItemsCount.Text = "....";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(6, 555);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 21);
            this.label14.TabIndex = 36;
            this.label14.Text = "عدد المنتجات:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(696, 546);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 39;
            this.label15.Text = "اجمالي المطلوب:";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(806, 529);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(185, 56);
            this.txtTotal.TabIndex = 38;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnCash
            // 
            this.rbtnCash.AutoSize = true;
            this.rbtnCash.Checked = true;
            this.rbtnCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnCash.Location = new System.Drawing.Point(172, 532);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.Size = new System.Drawing.Size(123, 23);
            this.rbtnCash.TabIndex = 40;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "دفع الفاتورة كاش";
            this.rbtnCash.UseVisualStyleBackColor = true;
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.rbtnCash_CheckedChanged);
            // 
            // rbtnAagel
            // 
            this.rbtnAagel.AutoSize = true;
            this.rbtnAagel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnAagel.Location = new System.Drawing.Point(172, 576);
            this.rbtnAagel.Name = "rbtnAagel";
            this.rbtnAagel.Size = new System.Drawing.Size(119, 23);
            this.rbtnAagel.TabIndex = 41;
            this.rbtnAagel.Text = "دفع الفاتورة آجل";
            this.rbtnAagel.UseVisualStyleBackColor = true;
            this.rbtnAagel.CheckedChanged += new System.EventHandler(this.rbtnAagel_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(297, 578);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 19);
            this.label16.TabIndex = 42;
            this.label16.Text = "تاريخ الاستحقاق:";
            // 
            // DtpAagel
            // 
            this.DtpAagel.Enabled = false;
            this.DtpAagel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAagel.Location = new System.Drawing.Point(409, 576);
            this.DtpAagel.Name = "DtpAagel";
            this.DtpAagel.Size = new System.Drawing.Size(120, 27);
            this.DtpAagel.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(405, 534);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 19);
            this.label12.TabIndex = 46;
            this.label12.Text = "اختر مخزن:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(438, 531);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 19);
            this.label13.TabIndex = 45;
            // 
            // cpxStore
            // 
            this.cpxStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStore.FormattingEnabled = true;
            this.cpxStore.Location = new System.Drawing.Point(487, 529);
            this.cpxStore.Name = "cpxStore";
            this.cpxStore.Size = new System.Drawing.Size(191, 27);
            this.cpxStore.TabIndex = 44;
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.date.Location = new System.Drawing.Point(570, 578);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(120, 27);
            this.date.TabIndex = 47;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(570, 578);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(132, 30);
            this.textBox1.TabIndex = 48;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_Buy
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1002, 611);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cpxStore);
            this.Controls.Add(this.DtpAagel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.rbtnAagel);
            this.Controls.Add(this.rbtnCash);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblItemsCount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DgvBuy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.btnDeleteItems);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxItems);
            this.Controls.Add(this.btnSupplierBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cpxSupplier);
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
            this.Name = "frm_Buy";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المشتريات";
            this.Load += new System.EventHandler(this.frm_Buy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Buy_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnSupplierBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxItems;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnItems;
        private DevExpress.XtraEditors.SimpleButton btnDeleteItems;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.RadioButton rbtnAagel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker DtpAagel;
        public System.Windows.Forms.ComboBox cpxSupplier;
        public System.Windows.Forms.DataGridView DgvBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cpxStore;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.TextBox textBox1;
    }
}