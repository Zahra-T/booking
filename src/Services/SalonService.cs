using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Booking.Models;
using Booking.Services;
using Booking.Communication;
using Booking.Infrastructure;
using Booking.Repositories;

namespace Booking.Services
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _salonRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public SalonService(ISalonRepository salonRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _salonRepository = salonRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Salon>> ListAsync()
        {
            var salons = await _cache.GetOrCreateAsync(CacheKeys.SalonsList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _salonRepository.ListAsync();
            });
            
            return salons;
        }


        public async Task<SalonResponse> SaveAsync(Salon salon)
        {
            try
            {
                await _salonRepository.AddAsync(salon);
                await _unitOfWork.CompleteAsync();

                return new SalonResponse(salon);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SalonResponse($"An error occurred when saving the salon: {ex.Message}");
            }
        }

        public async Task<SalonResponse> UpdateAsync(int id, Salon salon)
        {
            var existingSalon = await _salonRepository.FindByIdAsync(id);

            if (existingSalon == null)
                return new SalonResponse("Salon not found.");

            existingSalon.Name = salon.Name;

            try
            {
                _salonRepository.Update(existingSalon);
                await _unitOfWork.CompleteAsync();

                return new SalonResponse(existingSalon);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SalonResponse($"An error occurred when updating the salon: {ex.Message}");
            }
        }

        public async Task<SalonResponse> DeleteAsync(int id)
        {
            var existingSalon = await _salonRepository.FindByIdAsync(id);

            if (existingSalon == null)
                return new SalonResponse("Salon not found.");

            try
            {
                _salonRepository.Remove(existingSalon);
                await _unitOfWork.CompleteAsync();

                return new SalonResponse(existingSalon);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SalonResponse($"An error occurred when deleting the salon: {ex.Message}");
            }
        }
    }
}