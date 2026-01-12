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
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
            label2.Location = new Point(39, 111);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 1;
            label2.Text = "Başlangıç Fiyatı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2, 141);
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
            txtStartingPrice.Location = new Point(163, 108);
            txtStartingPrice.Name = "txtStartingPrice";
            txtStartingPrice.Size = new Size(210, 27);
            txtStartingPrice.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(163, 141);
            dtpEndDate.Name = "dtpEndDate";
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
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvProducts);
            Controls.Add(btnProductSave);
            Controls.Add(dtpEndDate);
            Controls.Add(txtStartingPrice);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblUrunAdi);
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
    }
}