namespace Auction.WinUI
{
    partial class BiddingHallForm
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
            dgvProducts = new DataGridView();
            lblWelcomeUser = new Label();
            label1 = new Label();
            lblSelectedProduct = new Label();
            label2 = new Label();
            txtBidAmount = new TextBox();
            btnPlaceBid = new Button();
            lblHighBid = new Label();
            rtbDescription = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.BackgroundColor = SystemColors.ButtonFace;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(57, 105);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(300, 328);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblWelcomeUser.Location = new Point(85, 34);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(175, 35);
            lblWelcomeUser.TabIndex = 1;
            lblWelcomeUser.Text = "Hoş geldin, ...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(454, 134);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 2;
            label1.Text = "Seçili Ürün : ";
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 12F);
            lblSelectedProduct.Location = new Point(570, 134);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(0, 28);
            lblSelectedProduct.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(473, 380);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 4;
            label2.Text = "Teklifiniz : ";
            // 
            // txtBidAmount
            // 
            txtBidAmount.Location = new Point(570, 384);
            txtBidAmount.Name = "txtBidAmount";
            txtBidAmount.Size = new Size(125, 27);
            txtBidAmount.TabIndex = 5;
            // 
            // btnPlaceBid
            // 
            btnPlaceBid.BackColor = Color.FromArgb(0, 192, 0);
            btnPlaceBid.ForeColor = SystemColors.ButtonFace;
            btnPlaceBid.Location = new Point(589, 417);
            btnPlaceBid.Name = "btnPlaceBid";
            btnPlaceBid.Size = new Size(94, 29);
            btnPlaceBid.TabIndex = 6;
            btnPlaceBid.Text = "Teklif Ver";
            btnPlaceBid.UseVisualStyleBackColor = false;
            btnPlaceBid.Click += btnPlaceBid_Click;
            // 
            // lblHighBid
            // 
            lblHighBid.AutoSize = true;
            lblHighBid.Font = new Font("Segoe UI", 12F);
            lblHighBid.Location = new Point(421, 335);
            lblHighBid.Name = "lblHighBid";
            lblHighBid.Size = new Size(164, 28);
            lblHighBid.TabIndex = 7;
            lblHighBid.Text = "En Yüksek Teklif: -";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(460, 185);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(235, 120);
            rtbDescription.TabIndex = 8;
            rtbDescription.Text = "";
            // 
            // BiddingHallForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(950, 551);
            Controls.Add(rtbDescription);
            Controls.Add(lblHighBid);
            Controls.Add(btnPlaceBid);
            Controls.Add(txtBidAmount);
            Controls.Add(label2);
            Controls.Add(lblSelectedProduct);
            Controls.Add(label1);
            Controls.Add(lblWelcomeUser);
            Controls.Add(dgvProducts);
            Name = "BiddingHallForm";
            Text = "Müzayede Salonu - Teklif Ver";
            Load += BiddingHallForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private Label lblWelcomeUser;
        private Label label1;
        private Label lblSelectedProduct;
        private Label label2;
        private TextBox txtBidAmount;
        private Button btnPlaceBid;
        private Label label3;
        private Label lblHighBid;
        private RichTextBox rtbDescription;
    }
}