using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trucking.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string? Name { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
