global using Microsoft.EntityFrameworkCore;

namespace MicroService1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Stock;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
