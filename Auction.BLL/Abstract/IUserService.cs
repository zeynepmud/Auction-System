using Auction.Entities;

namespace Auction.BLL.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);

        // Save metodu
        void Save();

        List<User> GetAll();
        User GetById(int id);
        User Login(string email, string password);
    }
}