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
    public class BidService : IBidService
    {
        private readonly IRepository<Bid> _bidRepository;

        public BidService(IRepository<Bid> bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public void Add(Bid bid) => _bidRepository.Add(bid);
        public List<Bid> GetAll() => _bidRepository.GetAll();

        public List<Bid> GetBidsByProductId(int productId)
        {
            // Belirli bir ürüne gelen tüm teklifleri filtreleyerek getirir
            return _bidRepository.GetAll(b => b.ProductId == productId);
        }
    }
}
