using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucking.Enums;

namespace Trucking.Models.General
{
    public class TripDto
    {
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
        [Required]
        public TripStatus TripStatus { get; set; }
    }
}