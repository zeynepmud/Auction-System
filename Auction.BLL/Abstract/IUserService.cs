using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.BLL.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetAll();
        User GetById(int id);
        User Login(string email, string password); // İş kuralı örneği
    }
}

