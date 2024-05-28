namespace Sales_Management
{
    partial class frm_Return
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Return));
            this.label9 = new System.Windows.Forms.Label();
            this.rbtnSales = new System.Windows.Forms.RadioButton();
            this.rbtnBuy = new System.Windows.Forms.RadioButton();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMadfou3 = new System.Windows.Forms.TextBox();
            this.DgvSearch = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaky = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalOrderAfterTex = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalTex = new System.Windows.Forms.TextBox();
            this.btnReturnAll = new DevExpress.XtraEditors.SimpleButton();
            this.lblName1 = new System.Windows.Forms.Label();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.CpxStore1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NudQty = new System.Windows.Forms.NumericUpDown();
            this.lblName2 = new System.Windows.Forms.Label();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cpxStore2 = new System.Windows.Forms.ComboBox();
            this.btnReturnItemOnly = new DevExpress.XtraEditors.SimpleButton();
            this.rbtnReturnQtyOnly = new System.Windows.Forms.RadioButton();
            this.rbtnReturnItemOnly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(406, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 33);
            this.label9.TabIndex = 32;
            this.label9.Text = "ادارة المرتجعات";
            // 
            // rbtnSales
            // 
            this.rbtnSales.AutoSize = true;
            this.rbtnSales.Checked = true;
            this.rbtnSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnSales.Location = new System.Drawing.Point(12, 69);
            this.rbtnSales.Name = "rbtnSales";
            this.rbtnSales.Size = new System.Drawing.Size(118, 23);
            this.rbtnSales.TabIndex = 42;
            this.rbtnSales.TabStop = true;
            this.rbtnSales.Text = "مرتجعات مبيعات";
            this.rbtnSales.UseVisualStyleBackColor = true;
            this.rbtnSales.CheckedChanged += new System.EventHandler(this.rbtnSales_CheckedChanged);
            // 
            // rbtnBuy
            // 
            this.rbtnBuy.AutoSize = true;
            this.rbtnBuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnBuy.Location = new System.Drawing.Point(145, 69);
            this.rbtnBuy.Name = "rbtnBuy";
            this.rbtnBuy.Size = new System.Drawing.Size(129, 23);
            this.rbtnBuy.TabIndex = 43;
            this.rbtnBuy.Text = "مرتجعات مشتريات";
            this.rbtnBuy.UseVisualStyleBackColor = true;
            this.rbtnBuy.CheckedChanged += new System.EventHandler(this.rbtnBuy_CheckedChanged);
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(406, 65);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(155, 27);
            this.DtpDate.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(298, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 46;
            this.label1.Text = "تاريخ الارجاع:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(737, 65);
            this.txtID.Name = "txtID";
            this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtID.Size = new System.Drawing.Size(234, 27);
            this.txtID.TabIndex = 47;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(609, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "بحث برقم الفاتورة:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(78, 428);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 19);
            this.label15.TabIndex = 50;
            this.label15.Text = "المبلغ المدفوع:";
            // 
            // txtMadfou3
            // 
            this.txtMadfou3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMadfou3.Location = new System.Drawing.Point(31, 454);
            this.txtMadfou3.Name = "txtMadfou3";
            this.txtMadfou3.ReadOnly = true;
            this.txtMadfou3.Size = new System.Drawing.Size(185, 27);
            this.txtMadfou3.TabIndex = 49;
            this.txtMadfou3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSearch.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSearch.Location = new System.Drawing.Point(12, 98);
            this.DgvSearch.Name = "DgvSearch";
            this.DgvSearch.ReadOnly = true;
            this.DgvSearch.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSearch.Size = new System.Drawing.Size(959, 312);
            this.DgvSearch.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(80, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 53;
            this.label3.Text = "المبلغ المتبقي:";
            // 
            // txtBaky
            // 
            this.txtBaky.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaky.Location = new System.Drawing.Point(31, 528);
            this.txtBaky.Name = "txtBaky";
            this.txtBaky.ReadOnly = true;
            this.txtBaky.Size = new System.Drawing.Size(185, 27);
            this.txtBaky.TabIndex = 52;
            this.txtBaky.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(27, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 19);
            this.label4.TabIndex = 55;
            this.label4.Text = "اجمالي الفاتورة بدون الضرائب:";
            // 
            // txtTotalOrder
            // 
            this.txtTotalOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalOrder.Location = new System.Drawing.Point(31, 615);
            this.txtTotalOrder.Name = "txtTotalOrder";
            this.txtTotalOrder.ReadOnly = true;
            this.txtTotalOrder.Size = new System.Drawing.Size(185, 27);
            this.txtTotalOrder.TabIndex = 54;
            this.txtTotalOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(49, 758);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 19);
            this.label5.TabIndex = 57;
            this.label5.Text = "الاجمالي بعد الضرائب:";
            // 
            // txtTotalOrderAfterTex
            // 
            this.txtTotalOrderAfterTex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalOrderAfterTex.Location = new System.Drawing.Point(31, 795);
            this.txtTotalOrderAfterTex.Name = "txtTotalOrderAfterTex";
            this.txtTotalOrderAfterTex.ReadOnly = true;
            this.txtTotalOrderAfterTex.Size = new System.Drawing.Size(185, 27);
            this.txtTotalOrderAfterTex.TabIndex = 56;
            this.txtTotalOrderAfterTex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(67, 670);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 19);
            this.label6.TabIndex = 59;
            this.label6.Text = "اجمالي الضرائب:";
            // 
            // txtTotalTex
            // 
            this.txtTotalTex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalTex.Location = new System.Drawing.Point(31, 701);
            this.txtTotalTex.Name = "txtTotalTex";
            this.txtTotalTex.ReadOnly = true;
            this.txtTotalTex.Size = new System.Drawing.Size(185, 27);
            this.txtTotalTex.TabIndex = 58;
            this.txtTotalTex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReturnAll
            // 
            this.btnReturnAll.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnAll.Appearance.Options.UseFont = true;
            this.btnReturnAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnAll.ImageOptions.Image")));
            this.btnReturnAll.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnReturnAll.Location = new System.Drawing.Point(20, 126);
            this.btnReturnAll.Name = "btnReturnAll";
            this.btnReturnAll.Size = new System.Drawing.Size(200, 33);
            this.btnReturnAll.TabIndex = 60;
            this.btnReturnAll.Text = "ارجاع الفاتورة بالكامل";
            this.btnReturnAll.Click += new System.EventHandler(this.btnReturnAll_Click);
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblName1.Location = new System.Drawing.Point(231, 37);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(73, 19);
            this.lblName1.TabIndex = 62;
            this.lblName1.Text = "اسم العميل:";
            // 
            // txtName1
            // 
            this.txtName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName1.Location = new System.Drawing.Point(20, 35);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(200, 27);
            this.txtName1.TabIndex = 61;
            this.txtName1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CpxStore1
            // 
            this.CpxStore1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CpxStore1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CpxStore1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CpxStore1.FormattingEnabled = true;
            this.CpxStore1.Location = new System.Drawing.Point(20, 86);
            this.CpxStore1.Name = "CpxStore1";
            this.CpxStore1.Size = new System.Drawing.Size(200, 27);
            this.CpxStore1.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(236, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 19);
            this.label8.TabIndex = 64;
            this.label8.Text = "الى المخزن:";
            // 
            // NudQty
            // 
            this.NudQty.DecimalPlaces = 3;
            this.NudQty.Location = new System.Drawing.Point(10, 58);
            this.NudQty.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudQty.Name = "NudQty";
            this.NudQty.Size = new System.Drawing.Size(83, 27);
            this.NudQty.TabIndex = 67;
            this.NudQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblName2.Location = new System.Drawing.Point(222, 124);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(73, 19);
            this.lblName2.TabIndex = 69;
            this.lblName2.Text = "اسم العميل:";
            // 
            // txtName2
            // 
            this.txtName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName2.Location = new System.Drawing.Point(26, 122);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(184, 27);
            this.txtName2.TabIndex = 68;
            this.txtName2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(244, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 19);
            this.label11.TabIndex = 71;
            this.label11.Text = "الى المخزن:";
            // 
            // cpxStore2
            // 
            this.cpxStore2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStore2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStore2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStore2.FormattingEnabled = true;
            this.cpxStore2.Location = new System.Drawing.Point(25, 166);
            this.cpxStore2.Name = "cpxStore2";
            this.cpxStore2.Size = new System.Drawing.Size(200, 27);
            this.cpxStore2.TabIndex = 70;
            // 
            // btnReturnItemOnly
            // 
            this.btnReturnItemOnly.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnItemOnly.Appearance.Options.UseFont = true;
            this.btnReturnItemOnly.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnItemOnly.ImageOptions.Image")));
            this.btnReturnItemOnly.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnReturnItemOnly.Location = new System.Drawing.Point(26, 212);
            this.btnReturnItemOnly.Name = "btnReturnItemOnly";
            this.btnReturnItemOnly.Size = new System.Drawing.Size(199, 28);
            this.btnReturnItemOnly.TabIndex = 72;
            this.btnReturnItemOnly.Text = "ارجاع الصنف المحدد فقط";
            this.btnReturnItemOnly.Click += new System.EventHandler(this.btnReturnItemOnly_Click);
            // 
            // rbtnReturnQtyOnly
            // 
            this.rbtnReturnQtyOnly.AutoSize = true;
            this.rbtnReturnQtyOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnReturnQtyOnly.Location = new System.Drawing.Point(99, 62);
            this.rbtnReturnQtyOnly.Name = "rbtnReturnQtyOnly";
            this.rbtnReturnQtyOnly.Size = new System.Drawing.Size(216, 23);
            this.rbtnReturnQtyOnly.TabIndex = 74;
            this.rbtnReturnQtyOnly.Text = "ارجاع جزء من كمية المنتج المحدد";
            this.rbtnReturnQtyOnly.UseVisualStyleBackColor = true;
            // 
            // rbtnReturnItemOnly
            // 
            this.rbtnReturnItemOnly.AutoSize = true;
            this.rbtnReturnItemOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnReturnItemOnly.Location = new System.Drawing.Point(130, 17);
            this.rbtnReturnItemOnly.Name = "rbtnReturnItemOnly";
            this.rbtnReturnItemOnly.Size = new System.Drawing.Size(181, 23);
            this.rbtnReturnItemOnly.TabIndex = 75;
            this.rbtnReturnItemOnly.Text = "ارجاع المنتج المحدد بالكامل";
            this.rbtnReturnItemOnly.UseVisualStyleBackColor = true;
            this.rbtnReturnItemOnly.CheckedChanged += new System.EventHandler(this.rbtnReturnItemOnly_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnReturnItemOnly);
            this.groupBox1.Controls.Add(this.rbtnReturnQtyOnly);
            this.groupBox1.Controls.Add(this.NudQty);
            this.groupBox1.Location = new System.Drawing.Point(16, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 90);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtName1);
            this.groupBox2.Controls.Add(this.lblName1);
            this.groupBox2.Controls.Add(this.CpxStore1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnReturnAll);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(250, 439);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 182);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ارجاع الفاتورة بالكامل";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.btnReturnItemOnly);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cpxStore2);
            this.groupBox3.Controls.Add(this.lblName2);
            this.groupBox3.Controls.Add(this.txtName2);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(605, 439);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 259);
            this.groupBox3.TabIndex = 79;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ارجاع اجزاء من الفاتورة";
            // 
            // frm_Return
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(983, 830);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBaky);
            this.Controls.Add(this.txtMadfou3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotalOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalTex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalOrderAfterTex);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DgvSearch);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.rbtnBuy);
            this.Controls.Add(this.rbtnSales);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Return";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة المرتجعات";
            this.Load += new System.EventHandler(this.frm_Return_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudQty)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtnSales;
        private System.Windows.Forms.RadioButton rbtnBuy;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMadfou3;
        public System.Windows.Forms.DataGridView DgvSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBaky;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalOrderAfterTex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalTex;
        private DevExpress.XtraEditors.SimpleButton btnReturnAll;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.ComboBox CpxStore1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NudQty;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cpxStore2;
        private DevExpress.XtraEditors.SimpleButton btnReturnItemOnly;
        private System.Windows.Forms.RadioButton rbtnReturnQtyOnly;
        private System.Windows.Forms.RadioButton rbtnReturnItemOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}