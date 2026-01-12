using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Concrete;
using Auction.Entities;

namespace Auction.WinUI
{
    public partial class BiddingHallForm : Form
    {
        private readonly User _loggedInUser;
        private readonly IProductService _productService;
        private readonly IBidService _bidService;

        // Soru işareti (?) null olabileceğini belirtir, böylece sarı uyarıyı giderir.
        private Product? _selectedProduct;

        public BiddingHallForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user; // Form1'den gelen kullanıcıyı hafızaya alıyoruz.

            // Servis bağlantılarını kuruyoruz.
            var context = new Auction.DAL.AppDbContext();
            _productService = new ProductService(new EfRepositoryBase<Product>(context));
            _bidService = new BidService(new EfRepositoryBase<Bid>(context));
        }

        private void BiddingHallForm_Load(object sender, EventArgs e)
        {
            // Kullanıcıyı ismiyle karşılıyoruz.
            lblWelcomeUser.Text = $"Hoş geldin, {_loggedInUser.FirstName} {_loggedInUser.LastName}";
            UrunleriListele();
        }

        private void UrunleriListele()
        {
            dgvProducts.DataSource = null;
            // Sadece süresi dolmamış aktif ürünleri listeliyoruz.
            dgvProducts.DataSource = _productService.GetAll()
                                        .Where(x => x.EndDate > DateTime.Now)
                                        .ToList();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tablodan bir satır seçildiğinde o ürünü yakalıyoruz.
            if (dgvProducts.CurrentRow != null)
            {
                _selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
                lblSelectedProduct.Text = _selectedProduct.Name;
            }
        }

        private void btnPlaceBid_Click(object sender, EventArgs e)
        {
            // 1. Ürün seçili mi kontrolü.
            if (_selectedProduct == null)
            {
                MessageBox.Show("Lütfen önce listeden bir ürün seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Sayısal değer kontrolü.
            if (decimal.TryParse(txtBidAmount.Text, out decimal bidAmount))
            {
                // 3. Mevcut en yüksek teklifi bulma mantığı.
                var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();

                // Eğer hiç teklif yoksa başlangıç fiyatını baz al, varsa en yükseğini bul.
                decimal currentMaxBid = allBids.Any() ? allBids.Max(b => b.Amount) : _selectedProduct.StartingPrice;

                // 4. Teklif geçerlilik kontrolü.
                if (bidAmount <= currentMaxBid)
                {
                    MessageBox.Show($"Teklifiniz mevcut fiyattan ({currentMaxBid} TL) daha yüksek olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // 5. Yeni teklif nesnesini oluşturup kaydediyoruz.
                    var newBid = new Bid
                    {
                        Amount = bidAmount,
                        BidTime = DateTime.Now, // Bid.cs içindeki isme (BidTime) göre güncelledik.
                        ProductId = _selectedProduct.Id,
                        UserId = _loggedInUser.Id
                    };

                    _bidService.Add(newBid);

                    MessageBox.Show("Teklifiniz başarıyla iletildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // İşlem bitince kutuyu temizle ve listeyi tazele.
                    txtBidAmount.Clear();
                    UrunleriListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Teklif kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayısal tutar giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}