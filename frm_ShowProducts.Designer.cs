namespace Sales_Management
{
    partial class frm_ShowProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ShowProducts));
            this.DgvStore = new System.Windows.Forms.DataGridView();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.cpxGroup = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtTotalGomla = new System.Windows.Forms.TextBox();
            this.txtTotalSale = new System.Windows.Forms.TextBox();
            this.txtTotalTax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStore)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvStore
            // 
            this.DgvStore.AllowUserToAddRows = false;
            this.DgvStore.AllowUserToDeleteRows = false;
            this.DgvStore.AllowUserToResizeColumns = false;
            this.DgvStore.AllowUserToResizeRows = false;
            this.DgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvStore.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvStore.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvStore.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvStore.Location = new System.Drawing.Point(12, 62);
            this.DgvStore.Name = "DgvStore";
            this.DgvStore.ReadOnly = true;
            this.DgvStore.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvStore.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvStore.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvStore.Size = new System.Drawing.Size(1183, 371);
            this.DgvStore.TabIndex = 64;
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
            this.btnChoose.Location = new System.Drawing.Point(306, 12);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(109, 28);
            this.btnChoose.TabIndex = 65;
            this.btnChoose.Text = "بحث";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // cpxGroup
            // 
            this.cpxGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxGroup.FormattingEnabled = true;
            this.cpxGroup.Location = new System.Drawing.Point(118, 13);
            this.cpxGroup.Name = "cpxGroup";
            this.cpxGroup.Size = new System.Drawing.Size(182, 27);
            this.cpxGroup.TabIndex = 66;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(520, 12);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(173, 28);
            this.txtBarcode.TabIndex = 67;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 68;
            this.label5.Text = "بحث بالمجموعة:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(421, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 69;
            this.label1.Text = "بحث بالباركود:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(824, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 70;
            this.label2.Text = "بحث بالاسم:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 71;
            this.label3.Text = "اجمالي الكمية:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(907, 12);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 28);
            this.txtName.TabIndex = 73;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.simpleButton2.Location = new System.Drawing.Point(699, 13);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(109, 28);
            this.simpleButton2.TabIndex = 74;
            this.simpleButton2.Text = "بحث";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(869, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 19);
            this.label4.TabIndex = 75;
            this.label4.Text = "اجمالي البيع بعد الضرائب:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(555, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 19);
            this.label6.TabIndex = 76;
            this.label6.Text = "اجمالي بيع التجزئة:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(241, 447);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 19);
            this.label7.TabIndex = 77;
            this.label7.Text = "اجمالي بيع الجملة:";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(108, 444);
            this.txtTotalQty.Multiline = true;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(115, 28);
            this.txtTotalQty.TabIndex = 78;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalGomla
            // 
            this.txtTotalGomla.Location = new System.Drawing.Point(361, 444);
            this.txtTotalGomla.Multiline = true;
            this.txtTotalGomla.Name = "txtTotalGomla";
            this.txtTotalGomla.ReadOnly = true;
            this.txtTotalGomla.Size = new System.Drawing.Size(173, 28);
            this.txtTotalGomla.TabIndex = 79;
            this.txtTotalGomla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalSale
            // 
            this.txtTotalSale.Location = new System.Drawing.Point(681, 444);
            this.txtTotalSale.Multiline = true;
            this.txtTotalSale.Name = "txtTotalSale";
            this.txtTotalSale.ReadOnly = true;
            this.txtTotalSale.Size = new System.Drawing.Size(173, 28);
            this.txtTotalSale.TabIndex = 80;
            this.txtTotalSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalTax
            // 
            this.txtTotalTax.Location = new System.Drawing.Point(1022, 444);
            this.txtTotalTax.Multiline = true;
            this.txtTotalTax.Name = "txtTotalTax";
            this.txtTotalTax.ReadOnly = true;
            this.txtTotalTax.Size = new System.Drawing.Size(173, 28);
            this.txtTotalTax.TabIndex = 81;
            this.txtTotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_ShowProducts
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 488);
            this.Controls.Add(this.txtTotalTax);
            this.Controls.Add(this.txtTotalSale);
            this.Controls.Add(this.txtTotalGomla);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.cpxGroup);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.DgvStore);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ShowProducts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة عرض المنتجات";
            this.Load += new System.EventHandler(this.frm_ShowProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvStore;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private System.Windows.Forms.ComboBox cpxGroup;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtTotalGomla;
        private System.Windows.Forms.TextBox txtTotalSale;
        private System.Windows.Forms.TextBox txtTotalTax;
    }
}