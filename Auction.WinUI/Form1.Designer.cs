namespace Auction.WinUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnSave = new Button();
            dgvUsers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(34, 26);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(34, 59);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(34, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(34, 125);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(51, 185);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(271, 26);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(300, 188);
            dgvUsers.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvUsers);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnSave;
        private DataGridView dgvUsers;
    }
}
