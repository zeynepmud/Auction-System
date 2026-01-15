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
            tabPageMyBids = new TabControl();
            tabActive = new TabPage();
            dgvActive = new DataGridView();
            tabClosed = new TabPage();
            dgvClosed = new DataGridView();
            tabMyBids = new TabPage();
            btnMyBidDelete = new Button();
            btnMyBidUpdate = new Button();
            txtMyBidAmount = new TextBox();
            dgvMyBids = new DataGridView();
            lblTimer = new Label();
            menuStrip1 = new MenuStrip();
            işlemlerToolStripMenuItem = new ToolStripMenuItem();
            çıkışYapToolStripMenuItem = new ToolStripMenuItem();
            tabPageMyBids.SuspendLayout();
            tabActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActive).BeginInit();
            tabClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClosed).BeginInit();
            tabMyBids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyBids).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblWelcomeUser.Location = new Point(138, 54);
            lblWelcomeUser.Margin = new Padding(5, 0, 5, 0);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(280, 54);
            lblWelcomeUser.TabIndex = 1;
            lblWelcomeUser.Text = "Hoş geldin, ...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(159, 786);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(196, 45);
            label1.TabIndex = 2;
            label1.Text = "Seçili Ürün : ";
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 12F);
            lblSelectedProduct.Location = new Point(348, 786);
            lblSelectedProduct.Margin = new Padding(5, 0, 5, 0);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(0, 45);
            lblSelectedProduct.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(856, 859);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 45);
            label2.TabIndex = 4;
            label2.Text = "Teklifiniz : ";
            // 
            // txtBidAmount
            // 
            txtBidAmount.Location = new Point(1014, 866);
            txtBidAmount.Margin = new Padding(5);
            txtBidAmount.Name = "txtBidAmount";
            txtBidAmount.Size = new Size(201, 39);
            txtBidAmount.TabIndex = 5;
            // 
            // btnPlaceBid
            // 
            btnPlaceBid.BackColor = Color.FromArgb(0, 192, 0);
            btnPlaceBid.ForeColor = SystemColors.ButtonFace;
            btnPlaceBid.Location = new Point(1045, 918);
            btnPlaceBid.Margin = new Padding(5);
            btnPlaceBid.Name = "btnPlaceBid";
            btnPlaceBid.Size = new Size(153, 46);
            btnPlaceBid.TabIndex = 6;
            btnPlaceBid.Text = "Teklif Ver";
            btnPlaceBid.UseVisualStyleBackColor = false;
            btnPlaceBid.Click += btnPlaceBid_Click;
            // 
            // lblHighBid
            // 
            lblHighBid.AutoSize = true;
            lblHighBid.Font = new Font("Segoe UI", 12F);
            lblHighBid.Location = new Point(772, 787);
            lblHighBid.Margin = new Padding(5, 0, 5, 0);
            lblHighBid.Name = "lblHighBid";
            lblHighBid.Size = new Size(273, 45);
            lblHighBid.TabIndex = 7;
            lblHighBid.Text = "En Yüksek Teklif: -";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(159, 866);
            rtbDescription.Margin = new Padding(5);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(581, 190);
            rtbDescription.TabIndex = 8;
            rtbDescription.Text = "";
            // 
            // tabPageMyBids
            // 
            tabPageMyBids.AccessibleName = "";
            tabPageMyBids.Controls.Add(tabActive);
            tabPageMyBids.Controls.Add(tabClosed);
            tabPageMyBids.Controls.Add(tabMyBids);
            tabPageMyBids.Cursor = Cursors.VSplit;
            tabPageMyBids.Location = new Point(159, 144);
            tabPageMyBids.Margin = new Padding(5);
            tabPageMyBids.Name = "tabPageMyBids";
            tabPageMyBids.SelectedIndex = 0;
            tabPageMyBids.Size = new Size(1402, 525);
            tabPageMyBids.TabIndex = 9;
            tabPageMyBids.Tag = "";
            tabPageMyBids.SelectedIndexChanged += tabPageMyBids_SelectedIndexChanged;
            // 
            // tabActive
            // 
            tabActive.Controls.Add(dgvActive);
            tabActive.Location = new Point(8, 46);
            tabActive.Margin = new Padding(5);
            tabActive.Name = "tabActive";
            tabActive.Padding = new Padding(5);
            tabActive.Size = new Size(1386, 471);
            tabActive.TabIndex = 0;
            tabActive.Text = "Aktif Müzayedeler";
            tabActive.UseVisualStyleBackColor = true;
            // 
            // dgvActive
            // 
            dgvActive.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActive.Dock = DockStyle.Fill;
            dgvActive.Location = new Point(5, 5);
            dgvActive.Margin = new Padding(5);
            dgvActive.Name = "dgvActive";
            dgvActive.RowHeadersWidth = 51;
            dgvActive.Size = new Size(1376, 461);
            dgvActive.TabIndex = 0;
            dgvActive.CellContentClick += dgvActive_CellClick;
            // 
            // tabClosed
            // 
            tabClosed.Controls.Add(dgvClosed);
            tabClosed.Location = new Point(8, 46);
            tabClosed.Margin = new Padding(5);
            tabClosed.Name = "tabClosed";
            tabClosed.Padding = new Padding(5);
            tabClosed.Size = new Size(1386, 471);
            tabClosed.TabIndex = 1;
            tabClosed.Text = "Kapanan Müzayedeler";
            tabClosed.UseVisualStyleBackColor = true;
            // 
            // dgvClosed
            // 
            dgvClosed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClosed.Dock = DockStyle.Fill;
            dgvClosed.Location = new Point(5, 5);
            dgvClosed.Margin = new Padding(5);
            dgvClosed.Name = "dgvClosed";
            dgvClosed.RowHeadersWidth = 51;
            dgvClosed.Size = new Size(1376, 461);
            dgvClosed.TabIndex = 0;
            // 
            // tabMyBids
            // 
            tabMyBids.Controls.Add(btnMyBidDelete);
            tabMyBids.Controls.Add(btnMyBidUpdate);
            tabMyBids.Controls.Add(txtMyBidAmount);
            tabMyBids.Controls.Add(dgvMyBids);
            tabMyBids.Location = new Point(8, 46);
            tabMyBids.Name = "tabMyBids";
            tabMyBids.Padding = new Padding(3);
            tabMyBids.Size = new Size(1386, 471);
            tabMyBids.TabIndex = 2;
            tabMyBids.Text = "Tekliflerim";
            tabMyBids.UseVisualStyleBackColor = true;
            // 
            // btnMyBidDelete
            // 
            btnMyBidDelete.Location = new Point(1172, 388);
            btnMyBidDelete.Name = "btnMyBidDelete";
            btnMyBidDelete.Size = new Size(132, 39);
            btnMyBidDelete.TabIndex = 3;
            btnMyBidDelete.Text = "Sil";
            btnMyBidDelete.UseVisualStyleBackColor = true;
            btnMyBidDelete.Click += btnMyBidDelete_Click;
            // 
            // btnMyBidUpdate
            // 
            btnMyBidUpdate.Location = new Point(1028, 388);
            btnMyBidUpdate.Name = "btnMyBidUpdate";
            btnMyBidUpdate.Size = new Size(124, 39);
            btnMyBidUpdate.TabIndex = 2;
            btnMyBidUpdate.Text = "Güncelle";
            btnMyBidUpdate.UseVisualStyleBackColor = true;
            btnMyBidUpdate.Click += btnMyBidUpdate_Click;
            // 
            // txtMyBidAmount
            // 
            txtMyBidAmount.Location = new Point(821, 388);
            txtMyBidAmount.Name = "txtMyBidAmount";
            txtMyBidAmount.Size = new Size(183, 39);
            txtMyBidAmount.TabIndex = 1;
            // 
            // dgvMyBids
            // 
            dgvMyBids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBids.Location = new Point(3, 0);
            dgvMyBids.Name = "dgvMyBids";
            dgvMyBids.RowHeadersWidth = 82;
            dgvMyBids.Size = new Size(1391, 331);
            dgvMyBids.TabIndex = 0;
            dgvMyBids.CellClick += dgvMyBids_CellClick;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.White;
            lblTimer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTimer.ForeColor = Color.Red;
            lblTimer.Location = new Point(158, 696);
            lblTimer.Margin = new Padding(5, 0, 5, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(0, 72);
            lblTimer.TabIndex = 10;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { işlemlerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1874, 42);
            menuStrip1.TabIndex = 11;
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
            çıkışYapToolStripMenuItem.Text = "Çıkış Yap";
            çıkışYapToolStripMenuItem.Click += çıkışYapToolStripMenuItem_Click;
            // 
            // BiddingHallForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1874, 1086);
            Controls.Add(lblTimer);
            Controls.Add(tabPageMyBids);
            Controls.Add(rtbDescription);
            Controls.Add(lblHighBid);
            Controls.Add(btnPlaceBid);
            Controls.Add(txtBidAmount);
            Controls.Add(label2);
            Controls.Add(lblSelectedProduct);
            Controls.Add(label1);
            Controls.Add(lblWelcomeUser);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            Name = "BiddingHallForm";
            Text = "Müzayede Salonu - Teklif Ver";
            Load += BiddingHallForm_Load;
            tabPageMyBids.ResumeLayout(false);
            tabActive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActive).EndInit();
            tabClosed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClosed).EndInit();
            tabMyBids.ResumeLayout(false);
            tabMyBids.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyBids).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private TabControl tabPageMyBids;
        private TabPage tabActive;
        private TabPage tabClosed;
        private DataGridView dgvActive;
        private DataGridView dgvClosed;
        private Label lblTimer;
        private TabPage tabMyBids;
        private Button btnMyBidDelete;
        private Button btnMyBidUpdate;
        private TextBox txtMyBidAmount;
        private DataGridView dgvMyBids;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem işlemlerToolStripMenuItem;
        private ToolStripMenuItem çıkışYapToolStripMenuItem;
    }
}