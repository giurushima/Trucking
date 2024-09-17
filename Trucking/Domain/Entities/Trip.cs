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
        [Required(ErrorMessage = "Ingrese origen de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Source { get; set; }
        [Required(ErrorMessage = "Ingrese destino de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Destiny { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion de viaje (menor a 100 caracteres)")]
        [MaxLength(100)]
        public string? Description { get; set; }
        [ForeignKey("TruckerId")]
        public Trucker? Trucker { get; set; }
        [Required]
        public TripStatus TripStatus { get; set; }
        public int TruckerId { get; set; }
    }
}
