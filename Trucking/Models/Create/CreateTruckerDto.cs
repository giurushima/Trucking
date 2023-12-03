using System.ComponentModel.DataAnnotations;
using Trucking.Enums;

namespace Trucking.Models.Create
{
    public class CreateTruckerDto
    {
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
    }
}