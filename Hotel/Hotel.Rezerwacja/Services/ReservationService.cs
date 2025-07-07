using Hotel.Rezerwacja.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Rezerwacja.Services
{
    public class ReservationService
    {
        private readonly ReservationDbContext _context;

        public ReservationService(ReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation?> GetByID(int ID)
        {
            return await _context.Reservations
                .Include(x => x.Place)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _context.Reservations
                .Include(x => x.Place)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Add(Reservation entity)
        {
            _context.Set<Reservation>()
                .Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Reservation entity)
        {
            var ExistingReservation = await _context.Reservations.FirstOrDefaultAsync(x => x.ID == entity.ID);

            if (ExistingReservation == null)
            {
                return false;
            }

            ExistingReservation.ClientID = entity.ClientID;
            ExistingReservation.Place = entity.Place;
            ExistingReservation.IsConfirmed = entity.IsConfirmed;
            ExistingReservation.Price = entity.Price;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int ID)
        {
            // Rezerwacja może zostać usunieta tylko kiedy nie ma do niej przypisanych żadnych lokalizacji.

            var ExistingReservation = await _context.Reservations.FirstOrDefaultAsync(x => x.ID == ID);

            if (ExistingReservation == null)
            {
                return false;
            }

            _context.Reservations.Remove(ExistingReservation);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
