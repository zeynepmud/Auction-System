using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Concrete;
using Auction.Entities;

namespace Auction.WinUI
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;

        public ProductForm()
        {
            InitializeComponent();
            // Product servisini DAL ve BLL katmanlarıyla bağlıyoruz
            _productService = new ProductService(new EfRepositoryBase<Product>(new Auction.DAL.AppDbContext()));
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            UrunListele();
        }

        private void UrunListele()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _productService.GetAll();
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. DOĞRULAMA: lblUrunAdi değil, txtName (TextBox) kullanılmalı
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtStartingPrice.Text))
                {
                    MessageBox.Show("Lütfen ürün adını ve başlangıç fiyatını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = new Product
                {
                    // 2. ATAMA: Veriyi Label'dan değil TextBox'tan (txtName) alıyoruz
                    Name = txtName.Text,
                    StartingPrice = decimal.Parse(txtStartingPrice.Text),
                    EndDate = dtpEndDate.Value
                };

                _productService.Add(product);

                MessageBox.Show("Ürün müzayedeye başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UrunListele();

                // 3. TEMİZLEME: lblUrunAdi.Clear() HATALIDIR. txtName.Clear() DOĞRUDUR.
                txtName.Clear();
                txtStartingPrice.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Başlangıç fiyatı için geçerli bir sayı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
    
}