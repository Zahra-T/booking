using System;

namespace Booking.Resources
{
    public class ShowResource
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int SalonId { get; set; }

    }
}