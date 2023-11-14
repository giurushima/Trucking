using Trucking.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucking.Entities
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Source { get; set; }
        public string? Destiny { get; set; }
        public string? Description { get; set; }
        public TripStatus TripStatus { get; set; }
        [ForeignKey("TruckerId")]
        public Trucker? Trucker { get; set; }
        public int TruckerId { get; set; }
    }
}
