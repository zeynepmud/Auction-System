using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.BLL.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAll();
        Product GetById(int id);
    }
}
