using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.Abstract;
using Auction.DAL.Abstract;
using Auction.Entities;

namespace Auction.BLL.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product) => _productRepository.Add(product);
        public void Update(Product product) => _productRepository.Update(product);
        public void Delete(Product product) => _productRepository.Delete(product);
        public List<Product> GetAll() => _productRepository.GetAll();
        public Product GetById(int id) => _productRepository.Get(p => p.Id == id);
    }
}
