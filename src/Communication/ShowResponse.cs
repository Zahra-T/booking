using Booking.Models;

namespace Booking.Communication
{
    public class ShowResponse :BaseResponse<Show>
    {
        public ShowResponse(Show show) : base(show) { }
        public ShowResponse(string message) : base(message) { }
    }
}