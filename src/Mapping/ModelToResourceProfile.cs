
using AutoMapper;
using Booking.Models;
using Booking.Resources;
using Booking.Queries;

namespace src.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Salon, SalonResource>();
            CreateMap<Show, ShowResource>();
            CreateMap<QueryResult<Show>, QueryResultResource<ShowResource>>();
        }
    }
}