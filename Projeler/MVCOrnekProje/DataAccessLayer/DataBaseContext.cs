using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Yorum> Yorum { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LocalHost;DataBase=2025Eticaret;Trusted_Connection=True;TrustServerCertificate=True");
        
        }
    }
}
