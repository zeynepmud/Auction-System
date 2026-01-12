using System;
using System.Windows.Forms;

namespace Auction.WinUI
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // Kullanıcı Kayıt ve Giriş Butonu İçin
        private void btnUserEntry_Click(object sender, EventArgs e)
        {
            Form1 userForm = new Form1();
            userForm.Show(); // Form1'i açar
        }

      
    }
}