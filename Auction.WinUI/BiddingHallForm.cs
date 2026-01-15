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
    public partial class BiddingHallForm : Form
    {
        private readonly User _loggedInUser;
        private readonly IProductService _productService;
        private readonly IBidService _bidService;
        private readonly IUserService _userService;

        private Product? _selectedProduct;
        private System.Windows.Forms.Timer _auctionTimer; // Geri sayım motorumuz

        public BiddingHallForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;

            // Mimari Kurulum: Tüm servisler aynı Unit of Work'ü kullanıyor
            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);

            _productService = new ProductService(new EfRepositoryBase<Product>(context), uow);
            _bidService = new BidService(new EfRepositoryBase<Bid>(context), uow);
            _userService = new UserService(new EfRepositoryBase<User>(context), uow);

            // Timer ayarları
            _auctionTimer = new System.Windows.Forms.Timer();
            _auctionTimer.Interval = 1000; // 1 saniyede bir çalış
            _auctionTimer.Tick += AuctionTimer_Tick; // Her saniye ne yapacağını söyleyen metot

        }


        private void BiddingHallForm_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = $"Hoş geldin, {_loggedInUser.FirstName} {_loggedInUser.LastName}";
            UrunleriListele();
            TekliflerimiListele();
        }

        // --- PROFESYONEL LİSTELEME MANTIGI ---
        private void UrunleriListele()
        {
            var tumUrunler = _productService.GetAll();
            var simdi = DateTime.Now;

            // 1. AKTİF MÜZAYEDELERİ FİLTRELE VE DOLDUR
            var aktifListesi = tumUrunler
                .Where(p => p.EndDate > simdi)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    UrunAdi = p.Name,
                    Aciklama = p.Description,
                    BaslangicFiyati = p.StartingPrice,
                    AcilisTarihi = p.CreatedDate,
                    BitisTarihi = p.EndDate,
                    // O ürüne gelen en yüksek teklifi buluyoruz
                    EnYuksekTeklif = _bidService.GetAll().Where(b => b.ProductId == p.Id).Any()
                                     ? _bidService.GetAll().Where(b => b.ProductId == p.Id).Max(b => b.Amount)
                                     : p.StartingPrice
                }).ToList();

            dgvActive.DataSource = aktifListesi;
            dgvActive.Columns["Id"].Visible = false; // Id gizlensin
            dgvActive.Columns["Kazanan"].Visible = false; // Aktiflerde kazanan sütunu görünmesin

            // 2. KAPANAN MÜZAYEDELERİ FİLTRELE VE DOLDUR
            var kapananListesi = tumUrunler
                .Where(p => p.EndDate <= simdi)
                .Select(p =>
                {
                    // Kapanan ürün için en yüksek teklifi ve vereni buluyoruz
                    var enYuksekBid = _bidService.GetAll()
                                        .Where(b => b.ProductId == p.Id)
                                        .OrderByDescending(b => b.Amount)
                                        .FirstOrDefault();

                    var kazananKisi = enYuksekBid != null
                                      ? _userService.GetById(enYuksekBid.UserId).FirstName + " " + _userService.GetById(enYuksekBid.UserId).LastName
                                      : "Satılamadı";

                    return new ProductViewModel
                    {
                        Id = p.Id,
                        UrunAdi = p.Name,
                        Aciklama = p.Description,
                        BaslangicFiyati = p.StartingPrice,
                        EnYuksekTeklif = enYuksekBid?.Amount ?? 0,
                        Kazanan = kazananKisi, // Kazananın adı burada
                        AcilisTarihi = p.CreatedDate,
                        BitisTarihi = p.EndDate
                    };
                }).ToList();

            dgvClosed.DataSource = kapananListesi;
            dgvClosed.Columns["Id"].Visible = false;
        }

        // Aktif tabloya tıklandığında teklif verme alanını doldurur
        private void dgvActive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActive.CurrentRow != null)
            {
                // ViewModel'den Id'yi alıp gerçek ürünü servisten çekiyoruz
                int selectedId = (int)dgvActive.CurrentRow.Cells["Id"].Value;
                _selectedProduct = _productService.GetById(selectedId);

                lblSelectedProduct.Text = _selectedProduct.Name;
                rtbDescription.Text = _selectedProduct.Description ?? "Açıklama yok.";

                EnYuksekTeklifiGoster();
                btnPlaceBid.Enabled = true; // Yeni ürün seçilince butonu aç
                _auctionTimer.Start();
            }
        }

        private void EnYuksekTeklifiGoster()
        {
            if (_selectedProduct == null) return;

            var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();
            var highestBid = allBids.OrderByDescending(b => b.Amount).FirstOrDefault();

            if (highestBid != null)
            {
                var bidder = _userService.GetById(highestBid.UserId);
                string bidderName = bidder != null ? $"{bidder.FirstName} {bidder.LastName[0]}." : "Bilinmiyor";
                lblHighBid.Text = $"En Yüksek: {highestBid.Amount} TL - {bidderName}";
            }
            else
            {
                lblHighBid.Text = $"Henüz teklif yok. (Başlangıç: {_selectedProduct.StartingPrice} TL)";
            }
        }

        private void btnPlaceBid_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Lütfen önce listeden aktif bir ürün seçiniz!");
                return;
            }

            if (decimal.TryParse(txtBidAmount.Text, out decimal bidAmount))
            {
                var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();
                decimal currentMax = allBids.Any() ? allBids.Max(b => b.Amount) : _selectedProduct.StartingPrice;

                if (bidAmount <= currentMax)
                {
                    MessageBox.Show($"Teklifiniz {currentMax} TL'den yüksek olmalıdır!");
                    return;
                }

                try
                {
                    var newBid = new Bid
                    {
                        Amount = bidAmount,
                        BidTime = DateTime.Now,
                        ProductId = _selectedProduct.Id,
                        UserId = _loggedInUser.Id
                    };

                    _bidService.Add(newBid);
                    _bidService.Save(); // Unit of Work ile kalıcı kayıt

                    MessageBox.Show("Teklifiniz iletildi!");
                    txtBidAmount.Clear();
                    UrunleriListele(); // Tabloları anlık güncelle
                    EnYuksekTeklifiGoster();
                    TekliflerimiListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

        }

        // Her saniye çalışan metot
        private void AuctionTimer_Tick(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                TimeSpan kalanSure = _selectedProduct.EndDate - DateTime.Now; //

                if (kalanSure.TotalSeconds > 0)
                {
                    lblTimer.Text = $"Kalan Süre: {kalanSure.Hours:D2}:{kalanSure.Minutes:D2}:{kalanSure.Seconds:D2}";
                    lblTimer.ForeColor = Color.Red;
                }
                else
                {
                    _auctionTimer.Stop();
                    lblTimer.Text = "MÜZAYEDE BİTTİ!";
                    btnPlaceBid.Enabled = false; // Teklif vermeyi kapat
                    UrunleriListele(); // Listeleri tazele
                }
            }
        }



        // --- TEKLİFLERİM SEKMESİ İÇİN LİSTELEME MODELİ ---
        private Bid? _selectedMyBid; // Seçilen teklifi tutacak

        private void TekliflerimiListele()
        {
            // Sadece giriş yapan kullanıcıya ait teklifleri çekiyoruz
            var myBids = _bidService.GetAll()
                .Where(b => b.UserId == _loggedInUser.Id)
                .Select(b =>
                {
                    var product = _productService.GetById(b.ProductId);
                    return new MyBidViewModel
                    {
                        BidId = b.Id,
                        UrunAdi = product.Name,
                        Teklifim = b.Amount,
                        BitisTarihi = product.EndDate,
                        Durum = product.EndDate > DateTime.Now ? "Devam Ediyor" : "Bitti"
                    };
                }).ToList();

            dgvMyBids.DataSource = null;
            dgvMyBids.DataSource = myBids;
            dgvMyBids.Columns["BidId"].Visible = false; // ID'yi sakla
        }

        private void btnMyBidDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMyBid != null)
            {
                var result = MessageBox.Show("Teklifinizi çekmek (silmek) istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _bidService.Delete(_selectedMyBid);
                    _bidService.Save(); // UoW ile kaydet
                    MessageBox.Show("Teklifiniz silindi.");
                    TekliflerimiListele(); // Listeyi tazele
                    UrunleriListele(); // Ana ürün listesini de güncelle (en yüksek teklif değişmiş olabilir)
                }
            }
        }

        private void btnMyBidUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMyBid != null && decimal.TryParse(txtMyBidAmount.Text, out decimal newAmount))
            {
                // Burada istersen "yeni tutar mevcut en yüksekten küçük olamaz" kontrolü ekleyebilirsin
                _selectedMyBid.Amount = newAmount;
                _selectedMyBid.BidTime = DateTime.Now;

                _bidService.Update(_selectedMyBid);
                _bidService.Save();
                MessageBox.Show("Teklifiniz güncellendi.");
                TekliflerimiListele();
                UrunleriListele();
            }
        }

        private void tabPageMyBids_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kullanıcı "Tekliflerim" sekmesine (3. sekme, yani index 2) geçtiyse listeyi yenile
            if (tabPageMyBids.SelectedIndex == 2)
            {
                TekliflerimiListele();
            }
        }

        private void dgvMyBids_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMyBids.CurrentRow != null && e.RowIndex >= 0)
            {
                // ID'yi yakalıyoruz
                int selectedBidId = (int)dgvMyBids.CurrentRow.Cells["BidId"].Value;

                // Servis üzerinden teklifi buluyoruz
                _selectedMyBid = _bidService.GetAll().FirstOrDefault(x => x.Id == selectedBidId);

                // Kutucuğa yazdırıyoruz
                if (_selectedMyBid != null)
                {
                    txtMyBidAmount.Text = _selectedMyBid.Amount.ToString();
                }
            }
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Kullanıcıya soruyoruz
            DialogResult result = MessageBox.Show(
                "Çıkış yapmak istediğinize emin misiniz?",
                "Çıkış Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // 2. Eğer "Evet" derse uygulamayı kapat veya Login ekranına dön
            if (result == DialogResult.Yes)
            {

                // Not: Eğer sadece Login formuna dönmek istersen şu yolu izleyebilirsin:
                 this.Close(); 
                 var loginForm = new LoginForm(); 
                 loginForm.Show();
            }
        }
    }
}

    public class ProductViewModel
    {
        public int Id { get; set; } // Arka planda lazım ama gizliyoruz
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal BaslangicFiyati { get; set; }
        public decimal EnYuksekTeklif { get; set; }
        public string Kazanan { get; set; } // Sadece bitenlerde görünecek
        public DateTime AcilisTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }

    public class MyBidViewModel
    {
        public int BidId { get; set; } // Arka planda silme/güncelleme için lazım
        public string UrunAdi { get; set; }
        public decimal Teklifim { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Durum { get; set; } // "Devam Ediyor" veya "Bitti"
    }

