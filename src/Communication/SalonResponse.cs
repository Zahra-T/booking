using Booking.Models;

namespace Booking.Communication
{
    public class SalonResponse : BaseResponse<Salon>
    {
        public SalonResponse(Salon salon) : base(salon)
        {}

        public SalonResponse(string message) : base(message)
        {}
    }
}