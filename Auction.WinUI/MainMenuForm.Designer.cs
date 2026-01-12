namespace Auction.WinUI
{
    partial class MainMenuForm
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
            btnUserEntry = new Button();
            lblWelcome = new Label();
            SuspendLayout();
            // 
            // btnUserEntry
            // 
            btnUserEntry.Location = new Point(291, 185);
            btnUserEntry.Name = "btnUserEntry";
            btnUserEntry.Size = new Size(184, 78);
            btnUserEntry.TabIndex = 0;
            btnUserEntry.Text = "Giriş";
            btnUserEntry.UseVisualStyleBackColor = true;
            btnUserEntry.Click += btnUserEntry_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(157, 110);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(466, 25);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Online Müzayede Sistemine Hoş Geldiniz";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWelcome);
            Controls.Add(btnUserEntry);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUserEntry;
        private Label lblWelcome;
    }
}