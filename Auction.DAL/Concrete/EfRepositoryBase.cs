
using Auction.DAL.Abstract;
using System.Linq.Expressions;

namespace Auction.DAL.Concrete
{
    // Bu bir normal sınıftır. IRepository arayüzünü uygular.
    public class EfRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly AppDbContext _context;

        public EfRepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity); 
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
            return _context.Set<TEntity>().SingleOrDefault(filter)!;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null!)
        {
            
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity); 
        }
    }
}
