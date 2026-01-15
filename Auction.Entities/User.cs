using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!; 
        public bool IsActive { get; set; } = true;

        // Bir kullanıcının birden fazla teklifi olabilir.
        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}