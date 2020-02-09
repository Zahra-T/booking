using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Booking.Models;
using Booking;

namespace Booking.Repositories
{
    public class SalonRepository : BaseRepository, ISalonRepository
    {
        public SalonRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Salon>> ListAsync()
        {
            return await _context.Salons
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Salon salon)
        {
            await _context.Salons.AddAsync(salon);
        }

        public async Task<Salon> FindByIdAsync(int id)
        {
            return await _context.Salons.FindAsync(id);
        }

        public void Update(Salon salon)
        {
            _context.Salons.Update(salon);
        }

        public void Remove(Salon salon)
        {
            _context.Salons.Remove(salon);
        }
    }
}