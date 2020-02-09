using System;
using System.Threading.Tasks;
using Booking.Models;
using Booking.Queries;
using Booking.Repositories;
using Booking.Services;
using Booking.Communication;

namespace Booking.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;
        private readonly ISalonRepository _salonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShowService(IShowRepository showRepository, ISalonRepository salonRepository, IUnitOfWork unitOfWork)
        {
            _showRepository = showRepository;
            _salonRepository = salonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QueryResult<Show>> ListAsync(ShowsQuery query)
        { 
            var shows = await  _showRepository.ListAsync(query);
            return shows;
        }

        public async Task<ShowResponse> SaveAsync(Show show)
        {
            try
            {
                var existingSalon = await _salonRepository.FindByIdAsync(show.SalonId);
                if (existingSalon == null)
                    return new ShowResponse("Invalid salon.");

                await _showRepository.AddAsync(show);
                await _unitOfWork.CompleteAsync();

                return new ShowResponse(show);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ShowResponse($"An error occurred when saving the show: {ex.Message}");
            }
        }

        public async Task<ShowResponse> UpdateAsync(int id, Show show)
        {
            var existingShow = await _showRepository.FindByIdAsync(id);

            if (existingShow == null)
                return new ShowResponse("Show not found.");

            var existingSalon = await _salonRepository.FindByIdAsync(show.SalonId);
            if (existingSalon == null)
                return new ShowResponse("Invalid Salon.");

            existingShow.Title = show.Title;
            existingShow.StartTime = show.StartTime;
            existingShow.EndTime = show.EndTime;
            existingShow.Summary = show.Summary;
            existingShow.Price = show.Price;
            existingShow.SalonId = show.SalonId;

            try
            {
                _showRepository.Update(existingShow);
                await _unitOfWork.CompleteAsync();

                return new ShowResponse(existingShow);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ShowResponse($"An error occurred when updating the show: {ex.Message}");
            }
        }

        public async Task<ShowResponse> DeleteAsync(int id)
        {
            var existingShow = await _showRepository.FindByIdAsync(id);

            if (existingShow == null)
                return new ShowResponse("Show not found.");

            try
            {
                _showRepository.Remove(existingShow);
                await _unitOfWork.CompleteAsync();

                return new ShowResponse(existingShow);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ShowResponse($"An error occurred when deleting the show: {ex.Message}");
            }
        }

    }
}