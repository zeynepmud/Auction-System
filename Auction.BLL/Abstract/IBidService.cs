using System.Collections.Generic;
using Auction.Entities;

namespace Auction.BLL.Abstract
{
    // Teklif servisimizin dış dünyaya söz verdiği metotlar listesi
    public interface IBidService
    {
        void Add(Bid bid);

        //Unit of Work kaydetme emri
        void Save();

        List<Bid> GetAll();
        List<Bid> GetBidsByProductId(int productId);
    }
}