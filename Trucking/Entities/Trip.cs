using System.Net.NetworkInformation;
using Trucking.Enums;

namespace Trucking.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string? Source { get; set; }
        public string? Destiny { get; set; }
        public string? Description { get; set; }
        public TripStatus TripStatus { get; set; }
    }
}
