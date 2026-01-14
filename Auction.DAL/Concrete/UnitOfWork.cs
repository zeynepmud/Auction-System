using Auction.DAL.Abstract;
using System;

namespace Auction.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context; // Aynı DbContext'i paylaşarak transaction bütünlüğü sağlar.
        }

        public int SaveChanges()
        {
            // Gerçek veritabanı kaydı sadece burada tetiklenir.
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}