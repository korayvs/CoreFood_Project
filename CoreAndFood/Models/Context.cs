using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-F1A12T8\\KORAY; database=DbCoreFood; integrated security=true; TrustServerCertificate = True");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
