using System.ComponentModel.DataAnnotations;
using Trucking.Enums;

namespace Trucking.Models.General
{
    public class TruckerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
        public Roles Roles { get; set; }
        public ICollection<TripDto> Trip { get; set; } = new List<TripDto>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.
        public List<TripDto> Trips { get; internal set; }
    }
}