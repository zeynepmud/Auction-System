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
            lblWelcomeUser = new Label();
            label1 = new Label();
            lblSelectedProduct = new Label();
            label2 = new Label();
            txtBidAmount = new TextBox();
            btnPlaceBid = new Button();
            lblHighBid = new Label();
            rtbDescription = new RichTextBox();
            tabControl = new TabControl();
            tabActive = new TabPage();
            dgvActive = new DataGridView();
            tabClosed = new TabPage();
            dgvClosed = new DataGridView();
            lblTimer = new Label();
            tabControl.SuspendLayout();
            tabActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActive).BeginInit();
            tabClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClosed).BeginInit();
            SuspendLayout();
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
            label1.Location = new Point(98, 491);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 2;
            label1.Text = "Seçili Ürün : ";
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 12F);
            lblSelectedProduct.Location = new Point(214, 491);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(0, 28);
            lblSelectedProduct.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(527, 537);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 4;
            label2.Text = "Teklifiniz : ";
            // 
            // txtBidAmount
            // 
            txtBidAmount.Location = new Point(624, 541);
            txtBidAmount.Name = "txtBidAmount";
            txtBidAmount.Size = new Size(125, 27);
            txtBidAmount.TabIndex = 5;
            // 
            // btnPlaceBid
            // 
            btnPlaceBid.BackColor = Color.FromArgb(0, 192, 0);
            btnPlaceBid.ForeColor = SystemColors.ButtonFace;
            btnPlaceBid.Location = new Point(643, 574);
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
            lblHighBid.Location = new Point(475, 492);
            lblHighBid.Name = "lblHighBid";
            lblHighBid.Size = new Size(164, 28);
            lblHighBid.TabIndex = 7;
            lblHighBid.Text = "En Yüksek Teklif: -";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(98, 541);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(359, 120);
            rtbDescription.TabIndex = 8;
            rtbDescription.Text = "";
            // 
            // tabControl
            // 
            tabControl.AccessibleName = "";
            tabControl.Controls.Add(tabActive);
            tabControl.Controls.Add(tabClosed);
            tabControl.Location = new Point(98, 90);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(863, 328);
            tabControl.TabIndex = 9;
            tabControl.Tag = "";
            // 
            // tabActive
            // 
            tabActive.Controls.Add(dgvActive);
            tabActive.Location = new Point(4, 29);
            tabActive.Name = "tabActive";
            tabActive.Padding = new Padding(3);
            tabActive.Size = new Size(855, 295);
            tabActive.TabIndex = 0;
            tabActive.Text = "Aktif Müzayedeler";
            tabActive.UseVisualStyleBackColor = true;
            // 
            // dgvActive
            // 
            dgvActive.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActive.Dock = DockStyle.Fill;
            dgvActive.Location = new Point(3, 3);
            dgvActive.Name = "dgvActive";
            dgvActive.RowHeadersWidth = 51;
            dgvActive.Size = new Size(849, 289);
            dgvActive.TabIndex = 0;
            dgvActive.CellContentClick += dgvActive_CellClick;
            // 
            // tabClosed
            // 
            tabClosed.Controls.Add(dgvClosed);
            tabClosed.Location = new Point(4, 29);
            tabClosed.Name = "tabClosed";
            tabClosed.Padding = new Padding(3);
            tabClosed.Size = new Size(855, 295);
            tabClosed.TabIndex = 1;
            tabClosed.Text = "Kapanan Müzayedeler";
            tabClosed.UseVisualStyleBackColor = true;
            // 
            // dgvClosed
            // 
            dgvClosed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClosed.Dock = DockStyle.Fill;
            dgvClosed.Location = new Point(3, 3);
            dgvClosed.Name = "dgvClosed";
            dgvClosed.RowHeadersWidth = 51;
            dgvClosed.Size = new Size(849, 289);
            dgvClosed.TabIndex = 0;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.White;
            lblTimer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTimer.ForeColor = Color.Red;
            lblTimer.Location = new Point(97, 435);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(0, 46);
            lblTimer.TabIndex = 10;
            // 
            // BiddingHallForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1153, 679);
            Controls.Add(lblTimer);
            Controls.Add(tabControl);
            Controls.Add(rtbDescription);
            Controls.Add(lblHighBid);
            Controls.Add(btnPlaceBid);
            Controls.Add(txtBidAmount);
            Controls.Add(label2);
            Controls.Add(lblSelectedProduct);
            Controls.Add(label1);
            Controls.Add(lblWelcomeUser);
            Name = "BiddingHallForm";
            Text = "Müzayede Salonu - Teklif Ver";
            Load += BiddingHallForm_Load;
            tabControl.ResumeLayout(false);
            tabActive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActive).EndInit();
            tabClosed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClosed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblWelcomeUser;
        private Label label1;
        private Label lblSelectedProduct;
        private Label label2;
        private TextBox txtBidAmount;
        private Button btnPlaceBid;
        private Label label3;
        private Label lblHighBid;
        private RichTextBox rtbDescription;
        private TabControl tabControl;
        private TabPage tabActive;
        private TabPage tabClosed;
        private DataGridView dgvActive;
        private DataGridView dgvClosed;
        private Label lblTimer;
    }
}