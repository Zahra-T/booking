using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;
using Booking.Queries;

namespace Booking.Repositories
{
    public interface IShowRepository
    {
        Task<QueryResult<Show>> ListAsync(ShowsQuery query);
        Task AddAsync(Show show);
        Task<Show> FindByIdAsync(int id);
        void Update(Show show);
        void Remove(Show show);
    }
}