using System.Collections.Generic;
using Auction.BLL.Abstract;
using Auction.DAL.Abstract;
using Auction.Entities;

namespace Auction.BLL.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _uow;

        public ProductService(IRepository<Product> productRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        // Repository'ye "ekle" diyoruz ama Save gelene kadar DB'ye gitmiyor
        public void Add(Product product) => _productRepository.Add(product);
        public void Update(Product product) => _productRepository.Update(product);
        public void Delete(Product product) => _productRepository.Delete(product);

        public void Save() => _uow.SaveChanges();

        public List<Product> GetAll() => _productRepository.GetAll();
        public Product GetById(int id) => _productRepository.Get(p => p.Id == id);
    }
}