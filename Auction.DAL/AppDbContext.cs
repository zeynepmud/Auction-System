using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.DAL
{
    public class AppDbContext : DbContext
    {
        // SQL Server bağlantı cümlesi (LocalDB en kolay kurulanıdır)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TrustServerCertificate=True; sertifika hatasını geçer.
            // Encrypt=False; ise şifreleme zorunluluğunu kaldırır, yerel çalışma için en güvenli yoldur.
            optionsBuilder.UseSqlServer("Server=DESKTOP-27ISNGQ;Database=AuctionDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
        }

        // Tablolarımız
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Bid> Bids { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Müzayede sistemindeki ilişkileri netleştiriyoruz (Normalizasyon için)
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Bids)
                .HasForeignKey(b => b.ProductId);

            //Para birimleri için hassasiyet ayarı
            // (18, 2) -> Toplam 18 basamak, bunun 2 basamağı virgülden sonra demek.
            modelBuilder.Entity<Bid>().Property(b => b.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(p => p.StartingPrice).HasPrecision(18, 2);
            // ----------------------------------------------------------------

            base.OnModelCreating(modelBuilder);
        }
    }
}
