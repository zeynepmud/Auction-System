using System.Collections.Generic;
using Auction.Entities;

namespace Auction.BLL.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        // Değişiklikleri veritabanına mühürlemek için
        void Save();

        List<Product> GetAll();
        Product GetById(int id);
    }
}