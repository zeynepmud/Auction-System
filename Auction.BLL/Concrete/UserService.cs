using System.Collections.Generic;
using System.Linq;
using Auction.BLL.Abstract;
using Auction.DAL.Abstract;
using Auction.Entities;

namespace Auction.BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _uow;

        public UserService(IRepository<User> userRepository, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public void Add(User user) => _userRepository.Add(user);
        public void Update(User user) => _userRepository.Update(user);
        public void Delete(User user) => _userRepository.Delete(user);

        // Veritabanına mühürleme işlemi burada yapılır
        public void Save() => _uow.SaveChanges();

        public List<User> GetAll() => _userRepository.GetAll();

        public User GetById(int id)
        {
            // ID'ye göre tek bir kullanıcıyı bulup döndürüyoruz
            return _userRepository.Get(u => u.Id == id);
        }

        public User Login(string email, string password)
        {
            // İş kuralı: Email ve şifre ikilisi veritabanında var mı?
            return _userRepository.Get(u => u.Email == email && u.Password == password);
        }
    }
}