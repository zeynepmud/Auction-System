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
        private readonly IUserService _userService;

        private Product? _selectedProduct;

        public BiddingHallForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;

            var context = new Auction.DAL.AppDbContext();
            _productService = new ProductService(new EfRepositoryBase<Product>(context));
            _bidService = new BidService(new EfRepositoryBase<Bid>(context));
            _userService = new UserService(new EfRepositoryBase<User>(context));
        }

        private void BiddingHallForm_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Text = $"Hoş geldin, {_loggedInUser.FirstName} {_loggedInUser.LastName}";
            UrunleriListele();
        }

        private void UrunleriListele()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _productService.GetAll()
                                        .Where(x => x.EndDate > DateTime.Now)
                                        .ToList();
        }

        private void EnYuksekTeklifiGoster()
        {
            if (_selectedProduct == null) return;

            var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();
            var highestBid = allBids.OrderByDescending(b => b.Amount).FirstOrDefault();

            if (highestBid != null)
            {
                var bidder = _userService.GetAll().FirstOrDefault(u => u.Id == highestBid.UserId);
                string bidderName = bidder != null ? $"{bidder.FirstName} {bidder.LastName[0]}." : "Bilinmiyor";

                lblHighBid.Text = $"En Yüksek: {highestBid.Amount} TL - {bidderName}";
            }
            else
            {
                lblHighBid.Text = $"Henüz teklif yok. (Başlangıç: {_selectedProduct.StartingPrice} TL)";
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                _selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
                lblSelectedProduct.Text = _selectedProduct.Name;

                // --- YENİ EKLENEN KISIM: AÇIKLAMA GETİRME ---
                // Eğer ürünün açıklaması boşsa kullanıcıya bilgi veriyoruz
                rtbDescription.Text = string.IsNullOrEmpty(_selectedProduct.Description)
                                      ? "Bu ürün için bir açıklama girilmemiş."
                                      : _selectedProduct.Description;
                // ------------------------------------------

                EnYuksekTeklifiGoster();
            }
        }

        private void btnPlaceBid_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Lütfen önce listeden bir ürün seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(txtBidAmount.Text, out decimal bidAmount))
            {
                var allBids = _bidService.GetAll().Where(b => b.ProductId == _selectedProduct.Id).ToList();
                decimal currentMaxBid = allBids.Any() ? allBids.Max(b => b.Amount) : _selectedProduct.StartingPrice;

                if (bidAmount <= currentMaxBid)
                {
                    MessageBox.Show($"Teklifiniz mevcut fiyattan ({currentMaxBid} TL) daha yüksek olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    MessageBox.Show("Teklifiniz başarıyla iletildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtBidAmount.Clear();

                    UrunleriListele();
                    EnYuksekTeklifiGoster();
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