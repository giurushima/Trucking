using Trucking.Enums;

namespace Trucking.Models.Create
{
    public class CreateTruckerDto
    {
        public int Id { get; set; }
        public string? CompleteName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
    }
}
