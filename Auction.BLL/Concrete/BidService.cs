using System.Collections.Generic;
using System.Linq;
using Auction.BLL.Abstract;
using Auction.DAL.Abstract; // Unit of Work ve Repo için
using Auction.Entities;

namespace Auction.BLL.Concrete
{
    public class BidService : IBidService
    {
        private readonly IRepository<Bid> _bidRepository;
        private readonly IUnitOfWork _uow; // Değişiklikleri toplu kaydeden arkadaşımız

        // Constructor Injection: Repository ve UoW dışarıdan enjekte ediliyor
        public BidService(IRepository<Bid> bidRepository, IUnitOfWork uow)
        {
            _bidRepository = bidRepository;
            _uow = uow;
        }

        public void Add(Bid bid) => _bidRepository.Add(bid);

        // UI katmanından çağrılınca her şeyi DB'ye yazar
        public void Save() => _uow.SaveChanges();

        public List<Bid> GetAll() => _bidRepository.GetAll();

        public List<Bid> GetBidsByProductId(int productId)
        {
            // Lambda ifadesiyle filtreleme yapıyoruz
            return _bidRepository.GetAll(b => b.ProductId == productId);
        }

        public void Update(Bid entity)
        {
            _bidRepository.Update(entity);
        }

        public void Delete(Bid entity)
        {
            _bidRepository.Delete(entity);
        }
    }
}