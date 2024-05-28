namespace Sales_Management
{
    partial class frm_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Setting));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBuyPrint = new System.Windows.Forms.CheckBox();
            this.checkSalePrint = new System.Windows.Forms.CheckBox();
            this.checkDiscount = new System.Windows.Forms.CheckBox();
            this.checkTaxes = new System.Windows.Forms.CheckBox();
            this.btnSaveGeneralSetting = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnA4Buy = new System.Windows.Forms.RadioButton();
            this.rbtn8cmBuy = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnA4Sales = new System.Windows.Forms.RadioButton();
            this.rbtn8cmSales = new System.Windows.Forms.RadioButton();
            this.NudBuyNumber = new System.Windows.Forms.NumericUpDown();
            this.NudSaleNumber = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtnValue = new System.Windows.Forms.RadioButton();
            this.rbtnPresent = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.btnSaveOrder = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cpxPrinter = new System.Windows.Forms.ComboBox();
            this.btnSavePrint = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudBuyNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSaleNumber)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBuyPrint);
            this.tabPage3.Controls.Add(this.checkSalePrint);
            this.tabPage3.Controls.Add(this.checkDiscount);
            this.tabPage3.Controls.Add(this.checkTaxes);
            this.tabPage3.Controls.Add(this.btnSaveGeneralSetting);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.NudBuyNumber);
            this.tabPage3.Controls.Add(this.NudSaleNumber);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.rbtnValue);
            this.tabPage3.Controls.Add(this.rbtnPresent);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(856, 291);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "اعدادات عامة";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBuyPrint
            // 
            this.checkBuyPrint.AutoSize = true;
            this.checkBuyPrint.Location = new System.Drawing.Point(643, 261);
            this.checkBuyPrint.Name = "checkBuyPrint";
            this.checkBuyPrint.Size = new System.Drawing.Size(195, 23);
            this.checkBuyPrint.TabIndex = 61;
            this.checkBuyPrint.Text = "تفعيل طباعة فواتير المشتريات";
            this.checkBuyPrint.UseVisualStyleBackColor = true;
            // 
            // checkSalePrint
            // 
            this.checkSalePrint.AutoSize = true;
            this.checkSalePrint.Location = new System.Drawing.Point(654, 234);
            this.checkSalePrint.Name = "checkSalePrint";
            this.checkSalePrint.Size = new System.Drawing.Size(184, 23);
            this.checkSalePrint.TabIndex = 60;
            this.checkSalePrint.Text = "تفعيل طباعة فواتير المبيعات";
            this.checkSalePrint.UseVisualStyleBackColor = true;
            // 
            // checkDiscount
            // 
            this.checkDiscount.AutoSize = true;
            this.checkDiscount.Location = new System.Drawing.Point(540, 207);
            this.checkDiscount.Name = "checkDiscount";
            this.checkDiscount.Size = new System.Drawing.Size(298, 23);
            this.checkDiscount.TabIndex = 59;
            this.checkDiscount.Text = "تفعيل امكانية الخصم على فواتير المبيعات للكاشير";
            this.checkDiscount.UseVisualStyleBackColor = true;
            // 
            // checkTaxes
            // 
            this.checkTaxes.AutoSize = true;
            this.checkTaxes.Location = new System.Drawing.Point(654, 180);
            this.checkTaxes.Name = "checkTaxes";
            this.checkTaxes.Size = new System.Drawing.Size(184, 23);
            this.checkTaxes.TabIndex = 58;
            this.checkTaxes.Text = "تفعيل ضريبة القيمة المضافة";
            this.checkTaxes.UseVisualStyleBackColor = true;
            // 
            // btnSaveGeneralSetting
            // 
            this.btnSaveGeneralSetting.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGeneralSetting.Appearance.Options.UseFont = true;
            this.btnSaveGeneralSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveGeneralSetting.ImageOptions.Image")));
            this.btnSaveGeneralSetting.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnSaveGeneralSetting.Location = new System.Drawing.Point(80, 234);
            this.btnSaveGeneralSetting.Name = "btnSaveGeneralSetting";
            this.btnSaveGeneralSetting.Size = new System.Drawing.Size(194, 32);
            this.btnSaveGeneralSetting.TabIndex = 57;
            this.btnSaveGeneralSetting.Text = "حفظ بيانات الاعدادات";
            this.btnSaveGeneralSetting.Click += new System.EventHandler(this.btnSaveGeneralSetting_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnA4Buy);
            this.groupBox2.Controls.Add(this.rbtn8cmBuy);
            this.groupBox2.Location = new System.Drawing.Point(16, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 94);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "طباعة فواتير المشتريات";
            // 
            // rbtnA4Buy
            // 
            this.rbtnA4Buy.AutoSize = true;
            this.rbtnA4Buy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rbtnA4Buy.Location = new System.Drawing.Point(29, 39);
            this.rbtnA4Buy.Name = "rbtnA4Buy";
            this.rbtnA4Buy.Size = new System.Drawing.Size(85, 23);
            this.rbtnA4Buy.TabIndex = 51;
            this.rbtnA4Buy.TabStop = true;
            this.rbtnA4Buy.Text = "طباعة A4";
            this.rbtnA4Buy.UseVisualStyleBackColor = true;
            // 
            // rbtn8cmBuy
            // 
            this.rbtn8cmBuy.AutoSize = true;
            this.rbtn8cmBuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rbtn8cmBuy.Location = new System.Drawing.Point(167, 39);
            this.rbtn8cmBuy.Name = "rbtn8cmBuy";
            this.rbtn8cmBuy.Size = new System.Drawing.Size(154, 23);
            this.rbtn8cmBuy.TabIndex = 50;
            this.rbtn8cmBuy.TabStop = true;
            this.rbtn8cmBuy.Text = "طباعة حراري(8 سنتم)";
            this.rbtn8cmBuy.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnA4Sales);
            this.groupBox1.Controls.Add(this.rbtn8cmSales);
            this.groupBox1.Location = new System.Drawing.Point(16, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 94);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "طباعة فواتير المبيعات";
            // 
            // rbtnA4Sales
            // 
            this.rbtnA4Sales.AutoSize = true;
            this.rbtnA4Sales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rbtnA4Sales.Location = new System.Drawing.Point(29, 39);
            this.rbtnA4Sales.Name = "rbtnA4Sales";
            this.rbtnA4Sales.Size = new System.Drawing.Size(85, 23);
            this.rbtnA4Sales.TabIndex = 51;
            this.rbtnA4Sales.TabStop = true;
            this.rbtnA4Sales.Text = "طباعة A4";
            this.rbtnA4Sales.UseVisualStyleBackColor = true;
            // 
            // rbtn8cmSales
            // 
            this.rbtn8cmSales.AutoSize = true;
            this.rbtn8cmSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rbtn8cmSales.Location = new System.Drawing.Point(167, 39);
            this.rbtn8cmSales.Name = "rbtn8cmSales";
            this.rbtn8cmSales.Size = new System.Drawing.Size(154, 23);
            this.rbtn8cmSales.TabIndex = 50;
            this.rbtn8cmSales.TabStop = true;
            this.rbtn8cmSales.Text = "طباعة حراري(8 سنتم)";
            this.rbtn8cmSales.UseVisualStyleBackColor = true;
            // 
            // NudBuyNumber
            // 
            this.NudBuyNumber.DecimalPlaces = 2;
            this.NudBuyNumber.Location = new System.Drawing.Point(540, 140);
            this.NudBuyNumber.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudBuyNumber.Name = "NudBuyNumber";
            this.NudBuyNumber.Size = new System.Drawing.Size(88, 27);
            this.NudBuyNumber.TabIndex = 54;
            this.NudBuyNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudBuyNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudSaleNumber
            // 
            this.NudSaleNumber.DecimalPlaces = 2;
            this.NudSaleNumber.Location = new System.Drawing.Point(540, 103);
            this.NudSaleNumber.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.NudSaleNumber.Name = "NudSaleNumber";
            this.NudSaleNumber.Size = new System.Drawing.Size(88, 27);
            this.NudSaleNumber.TabIndex = 53;
            this.NudSaleNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudSaleNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(634, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(208, 19);
            this.label10.TabIndex = 51;
            this.label10.Text = "عدد طباعة نسخة فواتير المشتريات:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(634, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 19);
            this.label9.TabIndex = 50;
            this.label9.Text = "عدد طباعة نسخة فواتير المبيعات:";
            // 
            // rbtnValue
            // 
            this.rbtnValue.AutoSize = true;
            this.rbtnValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rbtnValue.Location = new System.Drawing.Point(575, 59);
            this.rbtnValue.Name = "rbtnValue";
            this.rbtnValue.Size = new System.Drawing.Size(102, 23);
            this.rbtnValue.TabIndex = 49;
            this.rbtnValue.Text = "قيمة من المال";
            this.rbtnValue.UseVisualStyleBackColor = true;
            // 
            // rbtnPresent
            // 
            this.rbtnPresent.AutoSize = true;
            this.rbtnPresent.Checked = true;
            this.rbtnPresent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.rbtnPresent.Location = new System.Drawing.Point(700, 59);
            this.rbtnPresent.Name = "rbtnPresent";
            this.rbtnPresent.Size = new System.Drawing.Size(90, 23);
            this.rbtnPresent.TabIndex = 48;
            this.rbtnPresent.TabStop = true;
            this.rbtnPresent.Text = "نسبة مئوية";
            this.rbtnPresent.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(451, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(380, 19);
            this.label8.TabIndex = 47;
            this.label8.Text = "هل تريد ان يكون الخصم على المنتج نسبة مئوية ام قيمة من المال ؟ ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtDescription);
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Controls.Add(this.txtAddress);
            this.tabPage2.Controls.Add(this.txtPhone2);
            this.tabPage2.Controls.Add(this.txtPhone1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Controls.Add(this.btnChoose);
            this.tabPage2.Controls.Add(this.pictureLogo);
            this.tabPage2.Controls.Add(this.btnSaveOrder);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(856, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "اعدادات الفاتورة";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 107);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(273, 80);
            this.txtDescription.TabIndex = 58;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(496, 185);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 30);
            this.txtName.TabIndex = 53;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(496, 229);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(264, 30);
            this.txtAddress.TabIndex = 52;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(6, 62);
            this.txtPhone2.Multiline = true;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(273, 30);
            this.txtPhone2.TabIndex = 51;
            this.txtPhone2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(6, 20);
            this.txtPhone1.Multiline = true;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(273, 30);
            this.txtPhone1.TabIndex = 50;
            this.txtPhone1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(285, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 19);
            this.label7.TabIndex = 59;
            this.label7.Text = "جملة في اسفل الفاتورة:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(766, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 57;
            this.label6.Text = "عنوان المحل:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(764, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "اسم المحل:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(285, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 55;
            this.label3.Text = "رقم هاتف 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(285, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "رقم هاتف 1:";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnDelete.Location = new System.Drawing.Point(496, 137);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 32);
            this.btnDelete.TabIndex = 49;
            this.btnDelete.Text = "مسح الصورة";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnChoose.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnChoose.Appearance.Options.UseBackColor = true;
            this.btnChoose.Appearance.Options.UseFont = true;
            this.btnChoose.Appearance.Options.UseForeColor = true;
            this.btnChoose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnChoose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChoose.ImageOptions.Image")));
            this.btnChoose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnChoose.Location = new System.Drawing.Point(638, 137);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(122, 32);
            this.btnChoose.TabIndex = 48;
            this.btnChoose.Text = "اختر صورة";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // pictureLogo
            // 
            this.pictureLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureLogo.Location = new System.Drawing.Point(496, 23);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(264, 108);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 47;
            this.pictureLogo.TabStop = false;
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOrder.Appearance.Options.UseFont = true;
            this.btnSaveOrder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveOrder.ImageOptions.Image")));
            this.btnSaveOrder.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnSaveOrder.Location = new System.Drawing.Point(50, 226);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(194, 30);
            this.btnSaveOrder.TabIndex = 45;
            this.btnSaveOrder.Text = "حفظ بيانات الفاتورة";
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(766, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "لوجو:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cpxPrinter);
            this.tabPage1.Controls.Add(this.btnSavePrint);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(856, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اعدادات الطابعات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cpxPrinter
            // 
            this.cpxPrinter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxPrinter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxPrinter.FormattingEnabled = true;
            this.cpxPrinter.Location = new System.Drawing.Point(276, 94);
            this.cpxPrinter.Name = "cpxPrinter";
            this.cpxPrinter.Size = new System.Drawing.Size(333, 27);
            this.cpxPrinter.TabIndex = 48;
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrint.Appearance.Options.UseFont = true;
            this.btnSavePrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePrint.ImageOptions.Image")));
            this.btnSavePrint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnSavePrint.Location = new System.Drawing.Point(276, 148);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(333, 32);
            this.btnSavePrint.TabIndex = 45;
            this.btnSavePrint.Text = "حفظ بيانات الطابعة";
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(296, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 19);
            this.label4.TabIndex = 46;
            this.label4.Text = "اختر طابعة لكي تكون هي الطابعة الرئيسية للبرنامج";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 323);
            this.tabControl1.TabIndex = 0;
            // 
            // frm_Setting
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(888, 341);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Setting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة اعدادات";
            this.Load += new System.EventHandler(this.frm_Setting_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudBuyNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSaleNumber)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBuyPrint;
        private System.Windows.Forms.CheckBox checkSalePrint;
        private System.Windows.Forms.CheckBox checkDiscount;
        private System.Windows.Forms.CheckBox checkTaxes;
        private DevExpress.XtraEditors.SimpleButton btnSaveGeneralSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnA4Buy;
        private System.Windows.Forms.RadioButton rbtn8cmBuy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnA4Sales;
        private System.Windows.Forms.RadioButton rbtn8cmSales;
        private System.Windows.Forms.NumericUpDown NudBuyNumber;
        private System.Windows.Forms.NumericUpDown NudSaleNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtnValue;
        private System.Windows.Forms.RadioButton rbtnPresent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private System.Windows.Forms.PictureBox pictureLogo;
        private DevExpress.XtraEditors.SimpleButton btnSaveOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cpxPrinter;
        private DevExpress.XtraEditors.SimpleButton btnSavePrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
    }
}