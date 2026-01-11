using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal StartingPrice { get; set; } 
        public DateTime EndDate { get; set; }

        // İlişki: Bir ürüne birden fazla teklif gelebilir.
        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}