using Hotel.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel
{
    public class ClientDbContext : DbContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<Client> Clients { get; set; }

        public ClientDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=w67259;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "w67259_PRO_ST3"));
        }
    }
}
