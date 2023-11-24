namespace Trucking.Models.General
{
    public class TruckerDto
    {
        public int Id { get; set; }
        public string? CompleteName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
        public ICollection<TripDto> Trip { get; set; } = new List<TripDto>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.
        public List<TripDto> Trips { get; internal set; }
    }
}
