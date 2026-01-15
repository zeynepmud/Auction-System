
using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Abstract;
using Auction.DAL.Concrete;
using Auction.Entities;

namespace Auction.WinUI
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public LoginForm()
        {
            InitializeComponent();


            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);
            _userService = new UserService(new EfRepositoryBase<User>(context), uow);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Eğer sistemde hiç admin yoksa test amaçlı bir tane oluşturuyoruz
            if (!_userService.GetAll().Any(u => u.Role == "Admin"))
            {
                _userService.Add(new User
                {
                    FirstName = "Sistem",
                    LastName = "Yöneticisi",
                    Email = "admin@auction.com",
                    Password = "admin",
                    Role = "Admin",
                    IsActive = true // Admin hesabı varsayılan olarak aktif olmalı
                });
                _userService.Save();
            }
        }
        //Girişte hesap kontrol ayarları
        private void btnLogin_Click(object sender, EventArgs e)
        {

            var user = _userService.GetAll()
                .FirstOrDefault(u => u.Email == txtEmail.Text && u.Password == txtPassword.Text);

            if (user != null)
            {

                if (!user.IsActive)
                {
                    MessageBox.Show("Hesabınız yönetici tarafından dondurulmuştur. Giriş yapamazsınız.",
                                    "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; 
                }

                MessageBox.Show($"Hoş geldin, {user.FirstName}!");

                
                if (user.Role == "Admin")
                {
                   
                    new AdminDashboardForm().Show();
                }
                else
                {
                    
                    new BiddingHallForm(user).Show();
                }

                this.Hide(); // Giriş formunu gizle
            }
            else
            {
                MessageBox.Show("E-posta veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}