namespace Trucking.Models.General
{
    public class TruckerWithoutTripsDto
    {
        public int Id { get; set; }
        public string CompleteName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
    }
}
