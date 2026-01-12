using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Concrete;
using Auction.Entities;

namespace Auction.WinUI
{
    public partial class Form1 : Form
    {
        private readonly IUserService _userService;

        public Form1()
        {
            InitializeComponent();
            // Veritabaný baðlantýsý ve servis kurulumu
            _userService = new UserService(new EfRepositoryBase<User>(new Auction.DAL.AppDbContext()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Tabloyu doldurur
            Listele();

            // 2. TEST ÝÇÝN ÖNEMLÝ: Eðer veritabanýnda hiç Admin yoksa otomatik oluþturur
            var admins = _userService.GetAll().Where(u => u.Role == "Admin").ToList();
            if (admins.Count == 0)
            {
                var defaultAdmin = new User
                {
                    FirstName = "Sistem",
                    LastName = "Yöneticisi",
                    Email = "admin@auction.com",
                    Password = "admin",
                    Role = "Admin"
                };
                _userService.Add(defaultAdmin);
                Listele(); // Listeyi güncelle ki admini görelim
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Lütfen ad ve e-posta alanlarýný boþ býrakmayýn!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Role = "User" // Buradan kayýt olan herkes standart kullanýcýdýr
                };

                _userService.Add(user);
                MessageBox.Show("Kayýt baþarýlý! Giriþ yapabilirsiniz.", "Bilgi");
                Listele();
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Veritabanýndaki tüm kullanýcýlarý çekiyoruz
            var users = _userService.GetAll();

            // 2. E-posta ve þifre kontrolü
            var loggedInUser = users.FirstOrDefault(u => u.Email == txtEmail.Text && u.Password == txtPassword.Text);

            if (loggedInUser != null)
            {
                MessageBox.Show($"Hoþ geldin, {loggedInUser.FirstName}!", "Giriþ Baþarýlý");

                // 3. ROL KONTROLÜ VE YÖNLENDÝRME
                if (loggedInUser.Role == "Admin")
                {
                    // Eðer giriþ yapan Admin ise Ürün Yönetim ekranýna gider
                    ProductForm adminForm = new ProductForm();
                    adminForm.Show();
                }
                else
                {
                    // Eðer giriþ yapan normal bir kullanýcý (User) ise Müzayede Salonuna gider
                    BiddingHallForm hall = new BiddingHallForm(loggedInUser);
                    hall.Show();
                }

                this.Hide(); // Giriþ ekranýný gizler
            }
            else
            {
                MessageBox.Show("E-posta veya þifre hatalý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Listele()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _userService.GetAll();

            // Þifre ve Id kolonlarýný gizleyelim
            if (dgvUsers.Columns["Password"] != null) dgvUsers.Columns["Password"].Visible = false;
            if (dgvUsers.Columns["Id"] != null) dgvUsers.Columns["Id"].Visible = false;
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
