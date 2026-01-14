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

        public ProductForm()
        {
            InitializeComponent();

            // Servisimizi UoW ile besliyoruz
            var context = new Auction.DAL.AppDbContext();
            IUnitOfWork uow = new UnitOfWork(context);
            _productService = new ProductService(new EfRepositoryBase<Product>(context), uow);
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
                txtName.Clear();
                txtStartingPrice.Clear();
                txtDescription.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}