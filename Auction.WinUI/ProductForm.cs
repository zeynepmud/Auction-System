using Auction.BLL.Abstract;
using Auction.BLL.Concrete;
using Auction.DAL.Abstract;
using Auction.DAL.Concrete;
using Auction.Entities;

namespace Auction.WinUI
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private Product _selectedProduct;

        public ProductForm()
        {
            InitializeComponent();

            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);
            _productService = new ProductService(new EfRepositoryBase<Product>(context), uow);

            UrunListele();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                _selectedProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
                txtName.Text = _selectedProduct.Name;
                txtStartingPrice.Text = _selectedProduct.StartingPrice.ToString();
                txtDescription.Text = _selectedProduct.Description;
                dtpEndDate.Value = _selectedProduct.EndDate;
            }
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

        //--kaydetme butonu --
        private void btnProductSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtStartingPrice.Text))
                {
                    MessageBox.Show("Lütfen zorunlu alanları doldurunuz!");
                    return;
                }

                var product = new Product
                {
                    Name = txtName.Text,
                    StartingPrice = decimal.Parse(txtStartingPrice.Text),
                    EndDate = dtpEndDate.Value,
                    Description = txtDescription.Text
                };

                _productService.Add(product);
                _productService.Save(); // Ürünü DB'ye kalıcı olarak işliyoruz

                MessageBox.Show("Ürün başarıyla eklendi!");
                UrunListele();

                // Temizlik - Yeni ürün için yer açalım
                TemizleVeListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        //--Silme butonu--
        private void Delete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                var result = MessageBox.Show($"{_selectedProduct.Name} isimli ürünü silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _productService.Delete(_selectedProduct);
                        _productService.Save();

                        MessageBox.Show("Ürün başarıyla silindi.", "Bilgi");
                        TemizleVeListele();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce listeden silinecek ürünü seçiniz!");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                _selectedProduct.Name = txtName.Text;
                _selectedProduct.StartingPrice = decimal.Parse(txtStartingPrice.Text);
                _selectedProduct.Description = txtDescription.Text;
                _selectedProduct.EndDate = dtpEndDate.Value;

                _productService.Update(_selectedProduct);
                _productService.Save();
                UrunListele();
                MessageBox.Show("Ürün güncellendi.");
                TemizleVeListele();
            }
        }

        // --- YARDIMCI METOT: EKRANI SIFIRLAR VE LİSTEYİ TAZELEMEZ ---
        private void TemizleVeListele()
        {
            txtName.Clear();
            txtStartingPrice.Clear();
            txtDescription.Clear();
            dtpEndDate.Value = DateTime.Now;
            _selectedProduct = null;
            UrunListele();
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

        private void ProductForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}