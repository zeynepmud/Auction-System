

namespace Auction.Entities
{
    public class DTO_BiddingHall
    {
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string UrunAdi { get; set; }
            public string Aciklama { get; set; }
            public decimal BaslangicFiyati { get; set; }
            public decimal EnYuksekTeklif { get; set; }
            public string Kazanan { get; set; }
            public DateTime AcilisTarihi { get; set; }
            public DateTime BitisTarihi { get; set; }
        }

        public class MyBidViewModel
        {
            public int BidId { get; set; }
            public string UrunAdi { get; set; }
            public decimal Teklifim { get; set; }
            public DateTime BitisTarihi { get; set; }
            public string Durum { get; set; }
        }


    }
}
