using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;
using Booking.Communication;


namespace Booking.Services
{
    public interface ISalonService
    {
         Task<IEnumerable<Salon>> ListAsync();
         Task<SalonResponse> SaveAsync(Salon salon);
         Task<SalonResponse> UpdateAsync(int id, Salon salon);
         Task<SalonResponse> DeleteAsync(int id);
    }
}