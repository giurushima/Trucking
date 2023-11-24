using System.ComponentModel.DataAnnotations.Schema;
using Trucking.Entities;
using Trucking.Enums;

namespace Trucking.Models.Create
{
    public class CreateTripDto
    {
        public string? Source { get; set; }
        public string? Destiny { get; set; }
        public string? Description { get; set; }
        public TripStatus TripStatus { get; set; }
    }
}
