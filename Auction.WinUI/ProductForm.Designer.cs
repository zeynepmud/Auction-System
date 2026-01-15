namespace Auction.WinUI
{
    partial class ProductForm
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
            lblUrunAdi = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtStartingPrice = new TextBox();
            dtpEndDate = new DateTimePicker();
            btnProductSave = new Button();
            dgvProducts = new DataGridView();
            Açıklama = new Label();
            txtDescription = new TextBox();
            Delete = new Button();
            Update = new Button();
            menuStrip1 = new MenuStrip();
            işlemlerToolStripMenuItem = new ToolStripMenuItem();
            çıkışYapToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUrunAdi
            // 
            lblUrunAdi.AutoSize = true;
            lblUrunAdi.Location = new Point(83, 79);
            lblUrunAdi.Name = "lblUrunAdi";
            lblUrunAdi.Size = new Size(74, 20);
            lblUrunAdi.TabIndex = 0;
            lblUrunAdi.Text = "Ürün Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 113);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 1;
            label2.Text = "Başlangıç Fiyatı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 185);
            label3.Name = "label3";
            label3.Size = new Size(155, 20);
            label3.TabIndex = 2;
            label3.Text = "Müzayede Bitiş Tarihi :";
            // 
            // txtName
            // 
            txtName.Location = new Point(163, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(210, 27);
            txtName.TabIndex = 3;
            // 
            // txtStartingPrice
            // 
            txtStartingPrice.Location = new Point(163, 110);
            txtStartingPrice.Name = "txtStartingPrice";
            txtStartingPrice.Size = new Size(210, 27);
            txtStartingPrice.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(163, 185);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.ShowUpDown = true;
            dtpEndDate.Size = new Size(210, 27);
            dtpEndDate.TabIndex = 5;
            // 
            // btnProductSave
            // 
            btnProductSave.Location = new Point(213, 223);
            btnProductSave.Name = "btnProductSave";
            btnProductSave.Size = new Size(94, 29);
            btnProductSave.TabIndex = 6;
            btnProductSave.Text = "Kaydet";
            btnProductSave.UseVisualStyleBackColor = true;
            btnProductSave.Click += btnProductSave_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(425, 64);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(300, 188);
            dgvProducts.TabIndex = 7;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // Açıklama
            // 
            Açıklama.AutoSize = true;
            Açıklama.Location = new Point(83, 154);
            Açıklama.Name = "Açıklama";
            Açıklama.Size = new Size(70, 20);
            Açıklama.TabIndex = 8;
            Açıklama.Text = "Açıklama";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(163, 147);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(210, 34);
            txtDescription.TabIndex = 9;
            // 
            // Delete
            // 
            Delete.Location = new Point(122, 268);
            Delete.Margin = new Padding(2);
            Delete.Name = "Delete";
            Delete.Size = new Size(91, 29);
            Delete.TabIndex = 10;
            Delete.Text = "Sil";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Update
            // 
            Update.Location = new Point(303, 268);
            Update.Margin = new Padding(2);
            Update.Name = "Update";
            Update.Size = new Size(90, 29);
            Update.TabIndex = 11;
            Update.Text = "Güncelle";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { işlemlerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1300, 42);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            işlemlerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { çıkışYapToolStripMenuItem });
            işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            işlemlerToolStripMenuItem.Size = new Size(117, 38);
            işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // çıkışYapToolStripMenuItem
            // 
            çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
            çıkışYapToolStripMenuItem.Size = new Size(359, 44);
            çıkışYapToolStripMenuItem.Text = "Çıkış yap";
            çıkışYapToolStripMenuItem.Click += çıkışYapToolStripMenuItem_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Update);
            Controls.Add(Delete);
            Controls.Add(txtDescription);
            Controls.Add(Açıklama);
            Controls.Add(dgvProducts);
            Controls.Add(btnProductSave);
            Controls.Add(dtpEndDate);
            Controls.Add(txtStartingPrice);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblUrunAdi);
            Name = "ProductForm";
            Text = "Ürün Yönetim Paneli";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUrunAdi;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtStartingPrice;
        private DateTimePicker dtpEndDate;
        private Button btnProductSave;
        private DataGridView dgvProducts;
        private Label label1;
        private TextBox txtDescription;
        private Label Açıklama;
        private Button Delete;
        private Button Update;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem işlemlerToolStripMenuItem;
        private ToolStripMenuItem çıkışYapToolStripMenuItem;
    }
}