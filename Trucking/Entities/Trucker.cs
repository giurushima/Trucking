using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trucking.Entities
{
    public class Trucker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CompleteName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
        public ICollection<Trip> Trips { get; set; } = new List<Trip>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.
    }
}
