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
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // lblUrunAdi
            // 
            lblUrunAdi.AutoSize = true;
            lblUrunAdi.Location = new Point(135, 126);
            lblUrunAdi.Margin = new Padding(5, 0, 5, 0);
            lblUrunAdi.Name = "lblUrunAdi";
            lblUrunAdi.Size = new Size(120, 32);
            lblUrunAdi.TabIndex = 0;
            lblUrunAdi.Text = "Ürün Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 181);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(188, 32);
            label2.TabIndex = 1;
            label2.Text = "Başlangıç Fiyatı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 296);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(251, 32);
            label3.TabIndex = 2;
            label3.Text = "Müzayede Bitiş Tarihi :";
            // 
            // txtName
            // 
            txtName.Location = new Point(265, 120);
            txtName.Margin = new Padding(5);
            txtName.Name = "txtName";
            txtName.Size = new Size(339, 39);
            txtName.TabIndex = 3;
            // 
            // txtStartingPrice
            // 
            txtStartingPrice.Location = new Point(265, 176);
            txtStartingPrice.Margin = new Padding(5);
            txtStartingPrice.Name = "txtStartingPrice";
            txtStartingPrice.Size = new Size(339, 39);
            txtStartingPrice.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(265, 296);
            dtpEndDate.Margin = new Padding(5);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(339, 39);
            dtpEndDate.TabIndex = 5;
            // 
            // btnProductSave
            // 
            btnProductSave.Location = new Point(346, 357);
            btnProductSave.Margin = new Padding(5);
            btnProductSave.Name = "btnProductSave";
            btnProductSave.Size = new Size(153, 46);
            btnProductSave.TabIndex = 6;
            btnProductSave.Text = "Kaydet";
            btnProductSave.UseVisualStyleBackColor = true;
            btnProductSave.Click += btnProductSave_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(691, 102);
            dgvProducts.Margin = new Padding(5);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(488, 301);
            dgvProducts.TabIndex = 7;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // Açıklama
            // 
            Açıklama.AutoSize = true;
            Açıklama.Location = new Point(135, 246);
            Açıklama.Margin = new Padding(5, 0, 5, 0);
            Açıklama.Name = "Açıklama";
            Açıklama.Size = new Size(109, 32);
            Açıklama.TabIndex = 8;
            Açıklama.Text = "Açıklama";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(265, 235);
            txtDescription.Margin = new Padding(5);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(339, 52);
            txtDescription.TabIndex = 9;
            // 
            // Delete
            // 
            Delete.Location = new Point(198, 429);
            Delete.Name = "Delete";
            Delete.Size = new Size(148, 46);
            Delete.TabIndex = 10;
            Delete.Text = "Sil";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Update
            // 
            Update.Location = new Point(492, 429);
            Update.Name = "Update";
            Update.Size = new Size(147, 46);
            Update.TabIndex = 11;
            Update.Text = "Güncelle";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 720);
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
            Margin = new Padding(5);
            Name = "ProductForm";
            Text = "Ürün Yönetim Ekranı";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
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
    }
}