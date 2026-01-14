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

        public BiddingHallForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;

            // Tüm servislerin aynı Context'i paylaşması için merkezi bir Unit of Work kuruyoruz.
            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);

            // Servislerimizi oluştururken hem Repository'yi hem de Unit of Work'ü veriyoruz. 
            // Böylece CS7036 parametre hatasını çözmüş oluyoruz.
            _productService = new ProductService(new EfRepositoryBase<Product>(context), uow);
            _bidService = new BidService(new EfRepositoryBase<Bid>(context), uow);
            _userService = new UserService(new EfRepositoryBase<User>(context), uow);
        }

        private void BiddingHallForm_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = $"Hoş geldin, {_loggedInUser.FirstName} {_loggedInUser.LastName}";
            UrunleriListele();
        }

        private void UrunleriListele()
        {
            // Veritabanından bitiş tarihi geçmemiş ürünleri listeleyelim.
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _productService.GetAll()
                                        .Where(x => x.EndDate > DateTime.Now)
                                        .ToList();
        }

        // Grid üzerinden bir ürün seçildiğinde detaylarını getiren metot
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                // Seçili satırdaki nesneyi Product tipine çevirip alıyoruz
                _selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
                lblSelectedProduct.Text = _selectedProduct.Name;

                // Ürün açıklamasını kontrol edip RichTextBox'a yazıyoruz
                rtbDescription.Text = string.IsNullOrEmpty(_selectedProduct.Description)
                                      ? "Bu ürün için bir açıklama girilmemiş."
                                      : _selectedProduct.Description;

                // Seçilen ürün için mevcut en yüksek teklifi ekrana yazdıralım
                EnYuksekTeklifiGoster();
            }
        }

        private void EnYuksekTeklifiGoster()
        {
            if (_selectedProduct == null) return;

            // Bu ürüne ait tüm teklifleri çekip fiyata göre azalan sıralıyoruz.
            var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();
            var highestBid = allBids.OrderByDescending(b => b.Amount).FirstOrDefault();

            if (highestBid != null)
            {
                // Teklifi kimin verdiğini kullanıcı servisinden buluyoruz
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
                MessageBox.Show("Lütfen önce bir ürün seçiniz!", "Uyarı");
                return;
            }

            if (decimal.TryParse(txtBidAmount.Text, out decimal bidAmount))
            {
                // Mevcut en yüksek fiyatı kontrol ediyoruz (StartingPrice'ı baz alarak)
                var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();
                decimal currentMax = allBids.Any() ? allBids.Max(b => b.Amount) : _selectedProduct.StartingPrice;

                if (bidAmount <= currentMax)
                {
                    MessageBox.Show($"Teklifiniz {currentMax} TL'den daha yüksek olmalıdır!", "Hata");
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

                    _bidService.Add(newBid); // Önce bellekte listeye ekle
                    _bidService.Save();    // Unit of Work sayesinde veritabanına mühürle!

                    MessageBox.Show("Teklifiniz başarıyla kaydedildi!", "Bilgi");
                    txtBidAmount.Clear();
                    EnYuksekTeklifiGoster();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Teklif kaydedilirken hata: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz!", "Uyarı");
            }
        }
    }
}