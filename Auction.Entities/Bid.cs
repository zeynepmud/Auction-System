using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entities
{
    public class Bid : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }

        // Foreign Keys (Dış Anahtarlar)
        public int UserId { get; set; } 
        public virtual User User { get; set; } = null!;

        public int ProductId { get; set; }
       public virtual Product Product { get; set; } = null!;
    }
}