using System;

namespace Auction.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        // Tüm repository'lerin yaptığı değişiklikleri tek bir transaction ile DB'ye yazar.
        int SaveChanges();
    }
}