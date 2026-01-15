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
            pnlBidding = new Panel();
            tabPageMyBids.SuspendLayout();
            tabActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActive).BeginInit();
            tabClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClosed).BeginInit();
            tabMyBids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyBids).BeginInit();
            menuStrip1.SuspendLayout();
            pnlBidding.SuspendLayout();
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
            label1.Location = new Point(27, 89);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 2;
            label1.Text = "Seçili Ürün : ";
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 12F);
            lblSelectedProduct.Location = new Point(140, 89);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(0, 28);
            lblSelectedProduct.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(495, 89);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 4;
            label2.Text = "Teklifiniz : ";
            // 
            // txtBidAmount
            // 
            txtBidAmount.Location = new Point(599, 93);
            txtBidAmount.Name = "txtBidAmount";
            txtBidAmount.Size = new Size(125, 27);
            txtBidAmount.TabIndex = 5;
            // 
            // btnPlaceBid
            // 
            btnPlaceBid.BackColor = Color.FromArgb(0, 192, 0);
            btnPlaceBid.ForeColor = SystemColors.ButtonFace;
            btnPlaceBid.Location = new Point(500, 138);
            btnPlaceBid.Name = "btnPlaceBid";
            btnPlaceBid.Size = new Size(102, 38);
            btnPlaceBid.TabIndex = 6;
            btnPlaceBid.Text = "Teklif Ver";
            btnPlaceBid.UseVisualStyleBackColor = false;
            btnPlaceBid.Click += btnPlaceBid_Click;
            // 
            // lblHighBid
            // 
            lblHighBid.AutoSize = true;
            lblHighBid.Font = new Font("Segoe UI", 12F);
            lblHighBid.Location = new Point(495, 29);
            lblHighBid.Name = "lblHighBid";
            lblHighBid.Size = new Size(164, 28);
            lblHighBid.TabIndex = 7;
            lblHighBid.Text = "En Yüksek Teklif: -";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(27, 120);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(330, 76);
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
            tabPageMyBids.Location = new Point(98, 90);
            tabPageMyBids.Name = "tabPageMyBids";
            tabPageMyBids.SelectedIndex = 0;
            tabPageMyBids.Size = new Size(863, 328);
            tabPageMyBids.TabIndex = 9;
            tabPageMyBids.Tag = "";
            tabPageMyBids.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
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
            dgvActive.BackgroundColor = SystemColors.ButtonHighlight;
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
            dgvClosed.BackgroundColor = SystemColors.ButtonHighlight;
            dgvClosed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClosed.Dock = DockStyle.Fill;
            dgvClosed.Location = new Point(3, 3);
            dgvClosed.Name = "dgvClosed";
            dgvClosed.RowHeadersWidth = 51;
            dgvClosed.Size = new Size(849, 289);
            dgvClosed.TabIndex = 0;
            // 
            // tabMyBids
            // 
            tabMyBids.Controls.Add(btnMyBidDelete);
            tabMyBids.Controls.Add(btnMyBidUpdate);
            tabMyBids.Controls.Add(txtMyBidAmount);
            tabMyBids.Controls.Add(dgvMyBids);
            tabMyBids.Location = new Point(4, 29);
            tabMyBids.Margin = new Padding(2);
            tabMyBids.Name = "tabMyBids";
            tabMyBids.Padding = new Padding(2);
            tabMyBids.Size = new Size(855, 295);
            tabMyBids.TabIndex = 2;
            tabMyBids.Text = "Tekliflerim";
            tabMyBids.UseVisualStyleBackColor = true;
            // 
            // btnMyBidDelete
            // 
            btnMyBidDelete.Location = new Point(721, 242);
            btnMyBidDelete.Margin = new Padding(2);
            btnMyBidDelete.Name = "btnMyBidDelete";
            btnMyBidDelete.Size = new Size(81, 24);
            btnMyBidDelete.TabIndex = 3;
            btnMyBidDelete.Text = "Sil";
            btnMyBidDelete.UseVisualStyleBackColor = true;
            btnMyBidDelete.Click += btnMyBidDelete_Click;
            // 
            // btnMyBidUpdate
            // 
            btnMyBidUpdate.Location = new Point(633, 242);
            btnMyBidUpdate.Margin = new Padding(2);
            btnMyBidUpdate.Name = "btnMyBidUpdate";
            btnMyBidUpdate.Size = new Size(76, 24);
            btnMyBidUpdate.TabIndex = 2;
            btnMyBidUpdate.Text = "Güncelle";
            btnMyBidUpdate.UseVisualStyleBackColor = true;
            btnMyBidUpdate.Click += btnMyBidUpdate_Click;
            // 
            // txtMyBidAmount
            // 
            txtMyBidAmount.Location = new Point(505, 242);
            txtMyBidAmount.Margin = new Padding(2);
            txtMyBidAmount.Name = "txtMyBidAmount";
            txtMyBidAmount.Size = new Size(114, 27);
            txtMyBidAmount.TabIndex = 1;
            // 
            // dgvMyBids
            // 
            dgvMyBids.BackgroundColor = SystemColors.ButtonHighlight;
            dgvMyBids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyBids.Location = new Point(-5, 0);
            dgvMyBids.Margin = new Padding(2);
            dgvMyBids.Name = "dgvMyBids";
            dgvMyBids.RowHeadersWidth = 82;
            dgvMyBids.Size = new Size(856, 207);
            dgvMyBids.TabIndex = 0;
            dgvMyBids.CellClick += dgvMyBids_CellClick;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.White;
            lblTimer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTimer.ForeColor = Color.Red;
            lblTimer.Location = new Point(25, 9);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(0, 46);
            lblTimer.TabIndex = 10;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { işlemlerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(1153, 26);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            işlemlerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { çıkışYapToolStripMenuItem });
            işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            işlemlerToolStripMenuItem.Size = new Size(75, 24);
            işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // çıkışYapToolStripMenuItem
            // 
            çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
            çıkışYapToolStripMenuItem.Size = new Size(150, 26);
            çıkışYapToolStripMenuItem.Text = "Çıkış Yap";
            çıkışYapToolStripMenuItem.Click += çıkışYapToolStripMenuItem_Click;
            // 
            // pnlBidding
            // 
            pnlBidding.Controls.Add(label1);
            pnlBidding.Controls.Add(lblTimer);
            pnlBidding.Controls.Add(rtbDescription);
            pnlBidding.Controls.Add(lblHighBid);
            pnlBidding.Controls.Add(lblSelectedProduct);
            pnlBidding.Controls.Add(btnPlaceBid);
            pnlBidding.Controls.Add(label2);
            pnlBidding.Controls.Add(txtBidAmount);
            pnlBidding.Location = new Point(106, 445);
            pnlBidding.Margin = new Padding(2);
            pnlBidding.Name = "pnlBidding";
            pnlBidding.Size = new Size(863, 199);
            pnlBidding.TabIndex = 12;
            // 
            // BiddingHallForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1153, 684);
            Controls.Add(pnlBidding);
            Controls.Add(tabPageMyBids);
            Controls.Add(lblWelcomeUser);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
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
            pnlBidding.ResumeLayout(false);
            pnlBidding.PerformLayout();
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
        private Panel pnlBidding;
    }
}