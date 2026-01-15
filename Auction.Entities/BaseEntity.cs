

namespace Auction.Entities
{
    // abstract yaparak bu sınıfın tek başına bir tablo olmasını engelliyoruz.
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
