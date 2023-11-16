using System.ComponentModel.DataAnnotations.Schema;
using Trucking.Enums;

namespace Trucking.Models.Update
{
    public class UpdateTripDto
    {
        public string? Source { get; set; }
        public string? Destiny { get; set; }
        public string? Description { get; set; }
        public TripStatus TripStatus { get; set; }

        [ForeignKey("TruckerId")]
        public int TruckerId { get; set; }
    }
}
