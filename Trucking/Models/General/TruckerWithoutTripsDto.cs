using System.ComponentModel.DataAnnotations;

namespace Trucking.Models.General
{
    public class TruckerWithoutTripsDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
    }
}
