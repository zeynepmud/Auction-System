using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Auction.DAL.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null!);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
