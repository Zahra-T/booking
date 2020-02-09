using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Booking.Models;
using Booking.Queries;
using Booking.Repositories;


namespace Booking.Repositories
{
    public class ShowRepository : BaseRepository, IShowRepository
    {
        public ShowRepository(AppDbContext context) : base(context) { }

		public async Task<QueryResult<Show>> ListAsync(ShowsQuery query)
		{
			IQueryable<Show> queryable = _context.Shows
													.Include(p => p.Salon)
													.AsNoTracking();

			if (query.SalonId.HasValue && query.SalonId > 0)
			{
				queryable = queryable.Where(p => p.SalonId == query.SalonId);
			}

			int totalItems = await queryable.CountAsync();

			List<Show> shows = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

			return new QueryResult<Show>
			{
				Items = shows,
				TotalItems = totalItems,
			};
		}

		public async Task<Show> FindByIdAsync(int id)
		{
			return await _context.Shows
								 .Include(p => p.Salon)
								 .FirstOrDefaultAsync(p => p.Id == id); 
		}

		public async Task AddAsync(Show show)
		{
			await _context.Shows.AddAsync(show);
		}

		public void Update(Show show)
		{
			_context.Shows.Update(show);
		}

		public void Remove(Show show)
		{
			_context.Shows.Remove(show);
		}
    }
}