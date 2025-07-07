using Hotel.Zniżka.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Zniżka
{
    public class DiscountDbContext : DbContext
    {
        private IConfiguration _conConfiguration { get; }

        public DbSet<Discount> Discounts { get; set; }

        public DiscountDbContext(IConfiguration configuration) : base()
        {
            _conConfiguration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=w67259_Discounts;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "w67259_PRO_ST3"));
        }
    }
}
