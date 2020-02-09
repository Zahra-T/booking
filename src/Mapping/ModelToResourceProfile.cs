
using AutoMapper;
using Booking.Models;
using Booking.Resources;


namespace src.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Salon, SalonResource>();
            CreateMap<Show, ShowResource>();
        }
    }
}