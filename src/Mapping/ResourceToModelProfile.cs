using AutoMapper;
using Booking.Models;
using Booking.Resources;

namespace Booking.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile(){
             CreateMap<SaveSalonResource, Salon>();
             CreateMap<SaveShowResource, Show>();
        }
    }
}