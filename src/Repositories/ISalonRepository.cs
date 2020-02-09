using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;

namespace Booking.Repositories
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Salon>> ListAsync();
        Task AddAsync(Salon salon);
        Task<Salon> FindByIdAsync(int id);
        void Update(Salon category);
        void Remove(Salon category);
    }
}