using Microsoft.EntityFrameworkCore;
using WebApplication4.Model;

namespace WebApplication4.Controllers.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Orcamento> Orcamento { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemOrcamento> ItemOrcamento { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
