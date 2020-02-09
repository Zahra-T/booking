namespace Booking.Queries
{
    public class ShowsQuery : Query
    {
        public int? SalonId { get; set; }
        public ShowsQuery(int? salonId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            SalonId = salonId;
        }
    }
}