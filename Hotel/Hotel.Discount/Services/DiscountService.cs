using Hotel.Zniżka.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Zniżka.Services
{
    public class DiscountService
    {
        private DiscountDbContext _context;

        public DiscountService(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<Discount?> GetById(int ID)
        {
            return await _context.Discounts.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<IEnumerable<Discount>> Get()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task Add(Discount entity)
        {
            _context.Set<Discount>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Discount entity)
        {
            var ExistingDiscount = await _context.Discounts.FirstOrDefaultAsync(x => x.ID == entity.ID);

            if (ExistingDiscount == null)
            {
                return false;
            }

            ExistingDiscount.DiscountPercent = entity.DiscountPercent;
            ExistingDiscount.Description = entity.Description;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int ID)
        {
            var ExistingDiscount = await _context.Discounts.FirstOrDefaultAsync(x => x.ID == ID);

            if (ExistingDiscount == null)
            {
                return false;
            }

            _context.Discounts.Remove(ExistingDiscount);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
