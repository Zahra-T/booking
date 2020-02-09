using System.Threading.Tasks;
using Booking.Models;
using Booking.Queries;
using Booking.Communication;

namespace Booking.Services
{
    public interface IShowService
    {
        Task<QueryResult<Show>> ListAsync(ShowsQuery query);
        Task<ShowResponse> SaveAsync(Show show);
        Task<ShowResponse> UpdateAsync(int id, Show show);
        Task<ShowResponse> DeleteAsync(int id);
    }
}