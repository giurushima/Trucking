﻿namespace Trucking.Models
{
    public class TruckerDto
    {
        public int Id { get; set; }
        public string? NameAndLastName { get; set; } = string.Empty;
        public string? TruckerType { get; set; }
    }
}