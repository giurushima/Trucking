using Trucking.Enums;

namespace Trucking.Models.General
{
    public class TripDto
    {
        public int Id { get; set; }
        public string? Source { get; set; }
        public string? Destiny { get; set; }
        public string? Description { get; set; }
        public TripStatus TripStatus { get; set; }
    }
}
