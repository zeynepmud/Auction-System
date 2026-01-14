using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Abstract; // Unit of Work için ekledik
using Auction.DAL.Concrete;
using Auction.Entities;
using System.Text.RegularExpressions;

namespace Auction.WinUI
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService _userService;

        public RegisterForm()
        {
            InitializeComponent();

            // Önce veritabaný nesnemizi (Context) oluþturuyoruz.
            var context = new Auction.DAL.AppDbContext();
            // Tüm iþlemleri tek bir merkezden yönetmek için Unit of Work oluþturuyoruz.
            IUnitOfWork uow = new UnitOfWork(context);
            // Servisimize hem Repository'yi hem de Unit of Work'ü veriyoruz (Dependency Injection mantýðý).
            _userService = new UserService(new EfRepositoryBase<User>(context), uow);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Boþluk kontrolü - Kullanýcýyý uyarmak için
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Lütfen tüm alanlarý eksiksiz doldurunuz!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email format kontrolü - Regex kullanarak geçerli bir mail mi bakýyoruz
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Geçerli bir e-posta formatý giriniz!", "Hata");
                return;
            }

            // Mükerrer Kayýt Kontrolü: Ayný maille iki kiþi olamaz
            var existingUser = _userService.GetAll().FirstOrDefault(u => u.Email == txtEmail.Text);
            if (existingUser != null)
            {
                MessageBox.Show("Bu e-posta adresi zaten kullanýmda!");
                return;
            }

            try
            {
                var user = new User
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Role = "User"
                };

                _userService.Add(user); // Önce listeye ekliyoruz
                _userService.Save();    // Unit of Work sayesinde veritabanýna þimdi mühürleniyor

                MessageBox.Show("Kayýt baþarýlý! Giriþ yapabilirsiniz.", "Bilgi");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtFirstName.Focus();
        }
    }
}