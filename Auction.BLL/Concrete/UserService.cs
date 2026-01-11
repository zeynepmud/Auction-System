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
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        // Constructor Injection: Repository'yi dışarıdan alıyoruz
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user) => _userRepository.Add(user);
        public void Update(User user) => _userRepository.Update(user);
        public void Delete(User user) => _userRepository.Delete(user);
        public List<User> GetAll() => _userRepository.GetAll();
        public User GetById(int id) => _userRepository.Get(u => u.Id == id);

        public User Login(string email, string password)
        {
            // İş kuralı: Email ve şifre uyuşuyor mu?
            return _userRepository.Get(u => u.Email == email && u.Password == password);
        }
    }
}

