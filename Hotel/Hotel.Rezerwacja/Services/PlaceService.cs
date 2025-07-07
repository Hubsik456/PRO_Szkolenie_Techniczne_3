using Hotel.Rezerwacja.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Rezerwacja.Services
{
    public class PlaceService
    {
        private readonly ReservationDbContext _context;

        public PlaceService(ReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Place?> GetByID(int ID)
        {
            return await _context.Places
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<IEnumerable<Place>> Get()
        {
            return await _context.Places
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Add(Place entity)
        {
            _context.Set<Place>()
                .Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Place entity)
        {
            var ExistingPlace = await _context.Places.FirstOrDefaultAsync(x => x.ID == entity.ID);

            if (ExistingPlace == null)
            {
                return false;
            }

            ExistingPlace.Name = entity.Name;
            ExistingPlace.Address = entity.Address;
            ExistingPlace.Desciption = entity.Desciption;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int ID)
        {
            var ExistingPlace = await _context.Places.FirstOrDefaultAsync(x => x.ID == ID);

            if (ExistingPlace == null)
            {
                return false;   
            }

            _context.Places.Remove(ExistingPlace);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
