namespace Auction.WinUI
{
    partial class AdminDashboardForm
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
            panel1 = new Panel();
            label1 = new Label();
            lblTotalUsers = new Label();
            panel2 = new Panel();
            lblActiveAuctions = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblTotalVolume = new Label();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnActivateUser = new Button();
            btnSuspendUser = new Button();
            dgvUsers = new DataGridView();
            tabPage2 = new TabPage();
            splitContainer1 = new SplitContainer();
            dgvHistory = new DataGridView();
            dgvBidDetails = new DataGridView();
            tpLiveTracking = new TabPage();
            splitContainer2 = new SplitContainer();
            dgvActiveMonitor = new DataGridView();
            dgvActiveBids = new DataGridView();
            btnManageProducts = new Button();
            menuStrip1 = new MenuStrip();
            işlemlerToolStripMenuItem = new ToolStripMenuItem();
            çıkışYapToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBidDetails).BeginInit();
            tpLiveTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveMonitor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveBids).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTotalUsers);
            panel1.Location = new Point(37, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 109);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 11);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 2;
            label1.Text = "Toplam Kullanıcı";
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Location = new Point(89, 58);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(0, 20);
            lblTotalUsers.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Chocolate;
            panel2.Controls.Add(lblActiveAuctions);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(365, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 109);
            panel2.TabIndex = 1;
            // 
            // lblActiveAuctions
            // 
            lblActiveAuctions.AutoSize = true;
            lblActiveAuctions.Location = new Point(98, 58);
            lblActiveAuctions.Name = "lblActiveAuctions";
            lblActiveAuctions.Size = new Size(0, 20);
            lblActiveAuctions.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 11);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 3;
            label3.Text = "Aktif Müzayedeler";
            // 
            // panel3
            // 
            panel3.BackColor = Color.MediumSeaGreen;
            panel3.Controls.Add(lblTotalVolume);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(694, 34);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 109);
            panel3.TabIndex = 1;
            // 
            // lblTotalVolume
            // 
            lblTotalVolume.AutoSize = true;
            lblTotalVolume.Location = new Point(102, 58);
            lblTotalVolume.Name = "lblTotalVolume";
            lblTotalVolume.Size = new Size(0, 20);
            lblTotalVolume.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 11);
            label4.Name = "label4";
            label4.Size = new Size(145, 20);
            label4.TabIndex = 4;
            label4.Text = "Toplam Teklif Hacmi";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tpLiveTracking);
            tabControl1.Location = new Point(0, 167);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(990, 431);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnActivateUser);
            tabPage1.Controls.Add(btnSuspendUser);
            tabPage1.Controls.Add(dgvUsers);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(982, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kullanıcı Yönetimi";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnActivateUser
            // 
            btnActivateUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnActivateUser.BackColor = Color.MediumSeaGreen;
            btnActivateUser.Location = new Point(486, 366);
            btnActivateUser.Name = "btnActivateUser";
            btnActivateUser.Size = new Size(135, 29);
            btnActivateUser.TabIndex = 3;
            btnActivateUser.Text = "Hesabı Aktif Et";
            btnActivateUser.UseVisualStyleBackColor = false;
            btnActivateUser.Click += btnActivateUser_Click;
            // 
            // btnSuspendUser
            // 
            btnSuspendUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSuspendUser.BackColor = Color.IndianRed;
            btnSuspendUser.Location = new Point(334, 366);
            btnSuspendUser.Name = "btnSuspendUser";
            btnSuspendUser.Size = new Size(135, 29);
            btnSuspendUser.TabIndex = 1;
            btnSuspendUser.Text = "Hesabı Askıya Al";
            btnSuspendUser.UseVisualStyleBackColor = false;
            btnSuspendUser.Click += btnSuspendUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(-4, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(986, 364);
            dgvUsers.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(982, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Müzayede Geçmişi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvHistory);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvBidDetails);
            splitContainer1.Size = new Size(976, 392);
            splitContainer1.SplitterDistance = 150;
            splitContainer1.TabIndex = 1;
            // 
            // dgvHistory
            // 
            dgvHistory.BackgroundColor = SystemColors.ButtonHighlight;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.Location = new Point(0, 0);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(976, 150);
            dgvHistory.TabIndex = 0;
            dgvHistory.CellClick += dgvHistory_CellClick;
            // 
            // dgvBidDetails
            // 
            dgvBidDetails.BackgroundColor = SystemColors.ButtonHighlight;
            dgvBidDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBidDetails.Dock = DockStyle.Fill;
            dgvBidDetails.Location = new Point(0, 0);
            dgvBidDetails.Name = "dgvBidDetails";
            dgvBidDetails.RowHeadersWidth = 51;
            dgvBidDetails.Size = new Size(976, 238);
            dgvBidDetails.TabIndex = 0;
            // 
            // tpLiveTracking
            // 
            tpLiveTracking.Controls.Add(splitContainer2);
            tpLiveTracking.Location = new Point(4, 29);
            tpLiveTracking.Name = "tpLiveTracking";
            tpLiveTracking.Size = new Size(982, 398);
            tpLiveTracking.TabIndex = 2;
            tpLiveTracking.Text = "Aktif Müzayedeler";
            tpLiveTracking.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dgvActiveMonitor);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvActiveBids);
            splitContainer2.Size = new Size(982, 398);
            splitContainer2.SplitterDistance = 187;
            splitContainer2.TabIndex = 4;
            // 
            // dgvActiveMonitor
            // 
            dgvActiveMonitor.BackgroundColor = SystemColors.ButtonHighlight;
            dgvActiveMonitor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveMonitor.Dock = DockStyle.Fill;
            dgvActiveMonitor.Location = new Point(0, 0);
            dgvActiveMonitor.Name = "dgvActiveMonitor";
            dgvActiveMonitor.RowHeadersWidth = 51;
            dgvActiveMonitor.Size = new Size(982, 187);
            dgvActiveMonitor.TabIndex = 0;
            dgvActiveMonitor.CellClick += dgvActiveMonitor_CellClick;
            // 
            // dgvActiveBids
            // 
            dgvActiveBids.BackgroundColor = SystemColors.ButtonHighlight;
            dgvActiveBids.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveBids.Dock = DockStyle.Fill;
            dgvActiveBids.Location = new Point(0, 0);
            dgvActiveBids.Name = "dgvActiveBids";
            dgvActiveBids.RowHeadersWidth = 51;
            dgvActiveBids.Size = new Size(982, 207);
            dgvActiveBids.TabIndex = 0;
            // 
            // btnManageProducts
            // 
            btnManageProducts.Location = new Point(723, 148);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(197, 29);
            btnManageProducts.TabIndex = 3;
            btnManageProducts.Text = "Ürün Ekle/Düzenle";
            btnManageProducts.UseVisualStyleBackColor = true;
            btnManageProducts.Click += btnManageProducts_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { işlemlerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(990, 26);
            menuStrip1.TabIndex = 4;
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
            çıkışYapToolStripMenuItem.Text = "Çıkış yap";
            çıkışYapToolStripMenuItem.Click += çıkışYapToolStripMenuItem_Click;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 611);
            Controls.Add(btnManageProducts);
            Controls.Add(tabControl1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminDashboardForm";
            Text = "Yönetici Kontrol Paneli";
            Load += AdminDashboardForm_Load;
            Click += AdminDashboardForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabPage2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBidDetails).EndInit();
            tpLiveTracking.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActiveMonitor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveBids).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lblTotalUsers;
        private Panel panel2;
        private Label lblActiveAuctions;
        private Label label3;
        private Panel panel3;
        private Label lblTotalVolume;
        private Label label4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgvUsers;
        private TabPage tabPage2;
        private Button btnActivateUser;
        private Button btnSuspendUser;
        private Button btnManageProducts;
        private SplitContainer splitContainer1;
        private DataGridView dgvHistory;
        private TabPage tpLiveTracking;
        private SplitContainer splitContainer2;
        private DataGridView dgvActiveMonitor;
        private DataGridView dgvActiveBids;
        private DataGridView dgvBidDetails;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem işlemlerToolStripMenuItem;
        private ToolStripMenuItem çıkışYapToolStripMenuItem;
    }
}