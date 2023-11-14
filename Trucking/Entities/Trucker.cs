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
    }
}
