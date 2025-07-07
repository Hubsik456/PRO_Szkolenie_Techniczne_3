using Hotel.Rezerwacja.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Rezerwacja
{
    public class ReservationDbContext : DbContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<Place> Places { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ReservationDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=w67259_Reservations;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "w67259_PRO_ST3"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
