using Trucking.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

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
        [ForeignKey("TruckerId")]
        public Trucker? Trucker { get; set; }
        public TripStatus TripStatus { get; set; }
        public int TruckerId { get; set; }
    }
}
