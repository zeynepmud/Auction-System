using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.BLL.Abstract
{
    public interface IBidService
    {
        void Add(Bid bid);
        List<Bid> GetBidsByProductId(int productId);
        List<Bid> GetAll();
    }
}
