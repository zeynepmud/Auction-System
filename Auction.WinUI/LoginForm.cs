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

            // --- SOLID UYUMU ---
            // Tek bir context üzerinden servisleri bağlıyoruz.
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
                    Role = "Admin"
                });
                _userService.Save(); // Ekledikten sonra kaydettik
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kullanıcıyı veritabanında mail ve şifreyle sorguluyoruz
            var user = _userService.GetAll()
                .FirstOrDefault(u => u.Email == txtEmail.Text && u.Password == txtPassword.Text);

            if (user != null)
            {
                MessageBox.Show($"Hoş geldin, {user.FirstName}!");

                if (user.Role == "Admin")
                {
                    new ProductForm().Show(); // Adminse ürün ekleme paneli
                }
                else
                {
                    new BiddingHallForm(user).Show(); // Alıcıysa müzayede salonu
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("E-posta veya şifre hatalı!", "Hata");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }
    }
}