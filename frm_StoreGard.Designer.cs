namespace Sales_Management
{
    partial class frm_StoreGard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StoreGard));
            this.rbtnAllStore = new System.Windows.Forms.RadioButton();
            this.rbtnSingleStore = new System.Windows.Forms.RadioButton();
            this.cpxStore = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.DgvSearch = new System.Windows.Forms.DataGridView();
            this.txtTotalSale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalRb7h = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalBuy = new System.Windows.Forms.TextBox();
            this.btnSavePrint = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtnAllStore
            // 
            this.rbtnAllStore.AutoSize = true;
            this.rbtnAllStore.Checked = true;
            this.rbtnAllStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnAllStore.Location = new System.Drawing.Point(1044, 33);
            this.rbtnAllStore.Name = "rbtnAllStore";
            this.rbtnAllStore.Size = new System.Drawing.Size(89, 23);
            this.rbtnAllStore.TabIndex = 42;
            this.rbtnAllStore.TabStop = true;
            this.rbtnAllStore.Text = "كل المخازن";
            this.rbtnAllStore.UseVisualStyleBackColor = true;
            // 
            // rbtnSingleStore
            // 
            this.rbtnSingleStore.AutoSize = true;
            this.rbtnSingleStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnSingleStore.Location = new System.Drawing.Point(937, 33);
            this.rbtnSingleStore.Name = "rbtnSingleStore";
            this.rbtnSingleStore.Size = new System.Drawing.Size(91, 23);
            this.rbtnSingleStore.TabIndex = 41;
            this.rbtnSingleStore.Text = "مخزن محدد";
            this.rbtnSingleStore.UseVisualStyleBackColor = true;
            // 
            // cpxStore
            // 
            this.cpxStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cpxStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cpxStore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cpxStore.FormattingEnabled = true;
            this.cpxStore.Location = new System.Drawing.Point(744, 29);
            this.cpxStore.Name = "cpxStore";
            this.cpxStore.Size = new System.Drawing.Size(187, 27);
            this.cpxStore.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(854, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 19);
            this.label3.TabIndex = 77;
            this.label3.Text = "اجمالي مبالغ البيع:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.DgvSearch);
            this.groupBox1.Controls.Add(this.rbtnAllStore);
            this.groupBox1.Controls.Add(this.rbtnSingleStore);
            this.groupBox1.Controls.Add(this.cpxStore);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 544);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(204, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 79;
            this.label1.Text = "بحث بالباركود:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(6, 29);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(192, 27);
            this.txtBarcode.TabIndex = 80;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSearch.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSearch.Location = new System.Drawing.Point(6, 80);
            this.DgvSearch.Name = "DgvSearch";
            this.DgvSearch.ReadOnly = true;
            this.DgvSearch.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSearch.Size = new System.Drawing.Size(1149, 458);
            this.DgvSearch.TabIndex = 64;
            // 
            // txtTotalSale
            // 
            this.txtTotalSale.Location = new System.Drawing.Point(975, 597);
            this.txtTotalSale.Name = "txtTotalSale";
            this.txtTotalSale.ReadOnly = true;
            this.txtTotalSale.Size = new System.Drawing.Size(192, 27);
            this.txtTotalSale.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(18, 599);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 79;
            this.label2.Text = "الارباح المتوقعة:";
            // 
            // txtTotalRb7h
            // 
            this.txtTotalRb7h.Location = new System.Drawing.Point(127, 597);
            this.txtTotalRb7h.Name = "txtTotalRb7h";
            this.txtTotalRb7h.ReadOnly = true;
            this.txtTotalRb7h.Size = new System.Drawing.Size(192, 27);
            this.txtTotalRb7h.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(400, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 19);
            this.label4.TabIndex = 81;
            this.label4.Text = "اجمالي مبالغ الشراء:";
            // 
            // txtTotalBuy
            // 
            this.txtTotalBuy.Location = new System.Drawing.Point(532, 596);
            this.txtTotalBuy.Name = "txtTotalBuy";
            this.txtTotalBuy.ReadOnly = true;
            this.txtTotalBuy.Size = new System.Drawing.Size(192, 27);
            this.txtTotalBuy.TabIndex = 82;
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrint.Appearance.Options.UseFont = true;
            this.btnSavePrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePrint.ImageOptions.Image")));
            this.btnSavePrint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnSavePrint.Location = new System.Drawing.Point(468, 8);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(280, 32);
            this.btnSavePrint.TabIndex = 83;
            this.btnSavePrint.Text = "جرد";
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // frm_StoreGard
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1185, 634);
            this.Controls.Add(this.btnSavePrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalBuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalRb7h);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTotalSale);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_StoreGard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة جرد المخازن";
            this.Load += new System.EventHandler(this.frm_StoreGard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnAllStore;
        private System.Windows.Forms.RadioButton rbtnSingleStore;
        private System.Windows.Forms.ComboBox cpxStore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvSearch;
        private System.Windows.Forms.TextBox txtTotalSale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalRb7h;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalBuy;
        private DevExpress.XtraEditors.SimpleButton btnSavePrint;
    }
}