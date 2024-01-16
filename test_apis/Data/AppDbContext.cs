using Microsoft.EntityFrameworkCore;
using test_apis.Data.Model;

namespace test_apis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Items> Items { get; set; }
    }
  


}
