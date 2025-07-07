using Hotel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class ClientService
    {
        private ClientDbContext _context;

        public ClientService(ClientDbContext context)
        {
            _context = context;
        }

        public async Task<Client?> GetById(int ID)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task Add(Client entity)
        {
            _context.Set<Client>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Client entity)
        {
            var ExistingClient = await _context.Clients.FirstOrDefaultAsync(x => x.ID == entity.ID);

            if (ExistingClient == null) // Jeśli nie ma takiego klienta
            {
                return false;
            }

            ExistingClient.FirstName = entity.FirstName;
            ExistingClient.LastName = entity.LastName;
            ExistingClient.DateOfBirth = entity.DateOfBirth;
            ExistingClient.PhoneNumber = entity.PhoneNumber;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int ID)
        {
            var ExistingClient = await _context.Clients.FirstOrDefaultAsync(x => x.ID == ID);

            if (ExistingClient == null) // Jeśli nie ma takiego klienta
            {
                return false;
            }

            _context.Clients.Remove(ExistingClient);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
