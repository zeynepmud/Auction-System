
using Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.DAL
{
    public class AppDbContext : DbContext
    {
        // SQL Server bağlantı cümlesi 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AuctionDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
        }

        // Tablolarımız
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Bid> Bids { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Bids)
                .HasForeignKey(b => b.ProductId);


            modelBuilder.Entity<Bid>().Property(b => b.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(p => p.StartingPrice).HasPrecision(18, 2);
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
