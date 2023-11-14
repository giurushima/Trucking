namespace Trucking.Models.Update
{
    public class UpdateTruckerDto
    {
        public int Id { get; set; }
        public string? CompleteName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
    }
}
