
using System.Data;
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
        private System.Windows.Forms.Timer _auctionTimer;

        public BiddingHallForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;


            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);

            _productService = new ProductService(new EfRepositoryBase<Product>(context), uow);
            _bidService = new BidService(new EfRepositoryBase<Bid>(context), uow);
            _userService = new UserService(new EfRepositoryBase<User>(context), uow);

            // Timer ayarları
            _auctionTimer = new System.Windows.Forms.Timer();
            _auctionTimer.Interval = 1000; 
            _auctionTimer.Tick += AuctionTimer_Tick; 

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

            // AKTİF MÜZAYEDELERİ FİLTRELE VE DOLDUR
            var aktifListesi = tumUrunler
                .Where(p => p.EndDate > simdi)
                .Select(p => new DTO_BiddingHall.ProductViewModel
                {
                    Id = p.Id,
                    UrunAdi = p.Name,
                    Aciklama = p.Description,
                    BaslangicFiyati = p.StartingPrice,
                    AcilisTarihi = p.CreatedDate,
                    BitisTarihi = p.EndDate,
                    EnYuksekTeklif = _bidService.GetAll().Where(b => b.ProductId == p.Id).Any()
                                     ? _bidService.GetAll().Where(b => b.ProductId == p.Id).Max(b => b.Amount)
                                     : p.StartingPrice
                }).ToList();

            dgvActive.DataSource = aktifListesi;
            dgvActive.Columns["Id"].Visible = false; 
            dgvActive.Columns["Kazanan"].Visible = false; 

            //KAPANAN MÜZAYEDELERİ FİLTRELE VE DOLDUR
            var kapananListesi = tumUrunler
                .Where(p => p.EndDate <= simdi)
                .Select(p =>
                {
                    var enYuksekBid = _bidService.GetAll()
                                        .Where(b => b.ProductId == p.Id)
                                        .OrderByDescending(b => b.Amount)
                                        .FirstOrDefault();

                    var kazananKisi = enYuksekBid != null
                                      ? _userService.GetById(enYuksekBid.UserId).FirstName + " " + _userService.GetById(enYuksekBid.UserId).LastName
                                      : "Satılamadı";

                    return new DTO_BiddingHall.ProductViewModel
                    {
                        Id = p.Id,
                        UrunAdi = p.Name,
                        Aciklama = p.Description,
                        BaslangicFiyati = p.StartingPrice,
                        EnYuksekTeklif = enYuksekBid?.Amount ?? 0,
                        Kazanan = kazananKisi, 
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
                
                int selectedId = (int)dgvActive.CurrentRow.Cells["Id"].Value;
                _selectedProduct = _productService.GetById(selectedId);

                lblSelectedProduct.Text = _selectedProduct.Name;
                rtbDescription.Text = _selectedProduct.Description ?? "Açıklama yok.";

                EnYuksekTeklifiGoster();
                btnPlaceBid.Enabled = true; 
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
                    _bidService.Save(); 

                    MessageBox.Show("Teklifiniz iletildi!");
                    txtBidAmount.Clear();
                    UrunleriListele(); 
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
                // Hedef tarihten şu anki zamanı çıkararak farkı (TimeSpan) buluyoruz
                TimeSpan kalanSure = _selectedProduct.EndDate - DateTime.Now;

                if (kalanSure.TotalSeconds > 0)
                {
                    // Gün, Saat, Dakika ve Saniye formatını birleştiriyoruz
                    lblTimer.Text = $"Kalan Süre: {kalanSure.Days} Gün {kalanSure.Hours:D2}:{kalanSure.Minutes:D2}:{kalanSure.Seconds:D2}";
                    lblTimer.ForeColor = Color.Red;
                }
                else
                {
                    // Süre bittiğinde yapılacak işlemler
                    _auctionTimer.Stop();
                    lblTimer.Text = "MÜZAYEDE BİTTİ!";
                    btnPlaceBid.Enabled = false;
                    UrunleriListele(); // Listeyi yenileyerek ürünü "Kapananlar" kısmına gönderiyoruz
                }
            }
        }


        // --- TEKLİFLERİM SEKMESİ İÇİN LİSTELEME MODELİ ---
        private Bid? _selectedMyBid; 

        private void TekliflerimiListele()
        {
            // Sadece giriş yapan kullanıcıya ait teklifleri çekiyoruz
            var myBids = _bidService.GetAll()
                .Where(b => b.UserId == _loggedInUser.Id)
                .Select(b =>
                {
                    var product = _productService.GetById(b.ProductId);
                    return new DTO_BiddingHall.MyBidViewModel
                    {
                        BidId = b.Id,
                        UrunAdi = product.Name,
                        Teklifim = b.Amount,
                        BitisTarihi = product.EndDate,
                        Durum = (b.Product.EndDate > DateTime.Now) ? "Aktif" : "Müzayede Bitti"
                    };
                }).ToList();

            dgvMyBids.DataSource = null;
            dgvMyBids.DataSource = myBids;
            dgvMyBids.Columns["BidId"].Visible = false; 
        }

        //tekliflerim silme butonu 
        private void btnMyBidDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMyBid != null)
            {
                var product = _productService.GetById(_selectedMyBid.ProductId);

                // Süre bittiyse silmeyi engelle
                if (product != null && product.EndDate < DateTime.Now)
                {
                    MessageBox.Show("Süresi dolmuş bir müzayededen teklifinizi geri çekemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show("Teklifinizi çekmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _bidService.Delete(_selectedMyBid);
                    _bidService.Save();
                    MessageBox.Show("Teklifiniz silindi.");
                    TekliflerimiListele();
                    UrunleriListele();
                }
            }
        }

        //tekliflerim güncelleme butonu
        private void btnMyBidUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMyBid != null)
            {
                var product = _productService.GetById(_selectedMyBid.ProductId);

                //  Müzayede bitmişse güncellemeyi engelle
                if (product != null && product.EndDate < DateTime.Now)
                {
                    MessageBox.Show("Süresi dolmuş bir müzayedede teklifinizi güncelleyemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //  Kutudaki yeni değeri alıyoruz
                if (decimal.TryParse(txtMyBidAmount.Text, out decimal newAmount))
                {
                    _selectedMyBid.Amount = newAmount; // Nesneyi güncelledik
                    _selectedMyBid.BidTime = DateTime.Now;

                    _bidService.Update(_selectedMyBid); 
                    _bidService.Save();

                    MessageBox.Show("Teklifiniz başarıyla güncellendi.");
                    TekliflerimiListele();
                    UrunleriListele();
                }
            }
        }

        private void tabPageMyBids_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tc = sender as TabControl;

            if (tc != null)
            {              
                pnlBidding.Visible = (tc.SelectedIndex == 0);
                if (tc.SelectedIndex == 2)
                {
                    TekliflerimiListele();
                }
            }
        }

        private void dgvMyBids_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMyBids.CurrentRow != null && e.RowIndex >= 0)
            {
                
                int selectedBidId = (int)dgvMyBids.CurrentRow.Cells["BidId"].Value;

                
                _selectedMyBid = _bidService.GetAll().FirstOrDefault(x => x.Id == selectedBidId);

                
                if (_selectedMyBid != null)
                {
                    txtMyBidAmount.Text = _selectedMyBid.Amount.ToString();
                }
            }
            var product = _productService.GetById(_selectedMyBid.ProductId);
            if (product != null && product.EndDate < DateTime.Now)
            {
                btnMyBidUpdate.Enabled = false; // Butonu gri yapar ve tıklanamaz hale getirir
                btnMyBidDelete.Enabled = false;
            }
            else
            {
                btnMyBidUpdate.Enabled = true;
                btnMyBidDelete.Enabled = true;
            }
        }

        //üst bar işlemler çıkış yap kısmı metodu 
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var tc = sender as TabControl;

            if (tc != null)
            {
                
                if (tc.SelectedIndex == 0)
                {
                    pnlBidding.Visible = true;
                }
                else
                {
                    
                    pnlBidding.Visible = false;

                    if (_auctionTimer != null)
                        _auctionTimer.Stop(); 
                }
            }
        }
    }
}

   