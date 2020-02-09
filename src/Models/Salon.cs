using System.Collections.Generic;

namespace Booking.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatWidth { get; set; }
        public int SeatHeight { get; set; }
        public int DisplayLength { get; set; }
        public IList<Show> Shows { get; set; }
        public IList<Seat> Seats { get; set; }
    }
}
