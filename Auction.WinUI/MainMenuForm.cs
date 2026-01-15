

namespace Auction.WinUI
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        // Giriş Yap Butonu
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

        }

        // Kayıt Ol Butonu
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}