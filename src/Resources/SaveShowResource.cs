using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.Resources
{
    public class SaveShowResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int SalonId { get; set; }

    }
}