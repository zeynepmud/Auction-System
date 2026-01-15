using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Abstract;
using Auction.DAL.Concrete;
using Auction.Entities;

namespace Auction.WinUI
{
    public partial class AdminDashboardForm : Form
    {
        // Servis katmanlarımızı readonly olarak tanımlıyoruz 
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IBidService _bidService;

        public AdminDashboardForm()
        {
            InitializeComponent();

            // --- MERKEZİ MİMARİ KURULUM  ---
            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);

            _productService = new ProductService(new EfRepositoryBase<Product>(context), uow);
            _userService = new UserService(new EfRepositoryBase<User>(context), uow);
            _bidService = new BidService(new EfRepositoryBase<Bid>(context), uow);
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            TumVerileriTazele();
        }

        // Tüm istatistikleri hesaplayan ve tabloları güncelleyen merkezi metot.
        private void TumVerileriTazele()
        {
            try
            {
                var tumUrunler = _productService.GetAll();
                var tumTeklifler = _bidService.GetAll();
                var tumKullanicilar = _userService.GetAll();

                lblTotalUsers.Text = tumKullanicilar.Count().ToString();
                lblActiveAuctions.Text = tumUrunler.Count(p => p.EndDate > DateTime.Now).ToString();

                decimal gercekEkonomikHacim = tumUrunler.Sum(p =>
                    tumTeklifler
                        .Where(b => b.ProductId == p.Id)
                        .OrderByDescending(b => b.Amount)
                        .Select(b => b.Amount)
                        .FirstOrDefault()
                );

                lblTotalVolume.Text = gercekEkonomikHacim.ToString("C2"); // ₺ Para formatı

                // KULLANICI YÖNETİMİ TABLOSU (Sekme 1)
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = tumKullanicilar.Select(u => new
                {
                    u.Id,
                    Ad = u.FirstName,
                    Soyad = u.LastName,
                    Eposta = u.Email,
                    Durum = u.IsActive ? "Aktif" : "Askıda"
                }).ToList();

                //  MÜZAYEDE GEÇMİŞİ TABLOSU (Sekme 2)
                dgvHistory.DataSource = null;
                dgvHistory.DataSource = tumUrunler
                    .Where(p => p.EndDate <= DateTime.Now)
                    .Select(p => new
                    {
                        p.Id,
                        UrunAdi = p.Name,
                        BaslangicFiyati = p.StartingPrice,
                        BitisTarihi = p.EndDate
                    }).ToList();

                // CANLI TAKİBİ (Sekme 3)
                if (dgvActiveMonitor != null)
                {
                    dgvActiveMonitor.DataSource = null;
                    dgvActiveMonitor.DataSource = tumUrunler
                        .Where(p => p.EndDate > DateTime.Now)
                        .Select(p => new
                        {
                            p.Id,
                            UrunAdi = p.Name,
                            BitisTarihi = p.EndDate,
                            KalanSure = (p.EndDate - DateTime.Now).ToString(@"hh\:mm\:ss")
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri tazeleme sırasında hata: " + ex.Message);
            }
        }

        
        // Seçilen ürünün tekliflerini, kullanıcı isimleriyle beraber getiren yardımcı metot.
        private void TeklifDetaylariniGetir(int productId, DataGridView hedefGrid)
        {
            var kullaniciSozlugu = _userService.GetAll().ToDictionary(u => u.Id, u => $"{u.FirstName} {u.LastName}");

            hedefGrid.DataSource = _bidService.GetAll()
                .Where(b => b.ProductId == productId)
                .OrderByDescending(b => b.Amount)
                .Select(b => new
                {
                    Teklif = b.Amount, 
                    Zaman = b.BidTime,
                    Kullanici = kullaniciSozlugu.ContainsKey(b.UserId) ? kullaniciSozlugu[b.UserId] : "Bilinmiyor"
                }).ToList();
        }

        // --- HÜCRE TIKLAMA OLAYLARI ---

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistory.CurrentRow != null)
            {
                int productId = (int)dgvHistory.CurrentRow.Cells["Id"].Value;
                TeklifDetaylariniGetir(productId, dgvBidDetails);
            }
        }

        private void dgvActiveMonitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActiveMonitor.CurrentRow != null)
            {
                int productId = (int)dgvActiveMonitor.CurrentRow.Cells["Id"].Value;
                TeklifDetaylariniGetir(productId, dgvActiveBids);
            }
        }

        // --- KULLANICI DURUM YÖNETİMİ ---

        private void btnSuspendUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int userId = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
                var user = _userService.GetById(userId);
                if (user != null)
                {
                    user.IsActive = false;
                    _userService.Update(user);
                    _userService.Save();
                    MessageBox.Show("Kullanıcı hesabı donduruldu.");
                    TumVerileriTazele();
                }
            }
        }

        private void btnActivateUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int userId = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
                var user = _userService.GetById(userId);
                if (user != null)
                {
                    user.IsActive = true;
                    _userService.Update(user);
                    _userService.Save();
                    MessageBox.Show("Kullanıcı hesabı aktif edildi.");
                    TumVerileriTazele();
                }
            }
        }

        // --- ÜRÜN YÖNETİM MODÜLÜNE GEÇİŞ ---
        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.ShowDialog();
            TumVerileriTazele();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show(
                "Çıkış yapmak istediğinize emin misiniz?",
                "Çıkış Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            
            if (result == DialogResult.Yes)
            {

                
                this.Close();
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}