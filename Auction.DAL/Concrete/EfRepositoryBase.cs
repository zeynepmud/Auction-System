using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auction.DAL.Concrete
{
    // Bu bir normal sınıftır (Class). IRepository arayüzünü uygular (implement eder).
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
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            // Veritabanında filtreye uyan tek bir kaydı getirir.
            return _context.Set<TEntity>().SingleOrDefault(filter)!;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null!)
        {
            // Filtre yoksa tümünü, varsa filtreye uyanları liste olarak getirir.
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
