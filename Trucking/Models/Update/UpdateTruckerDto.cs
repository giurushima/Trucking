﻿using System.ComponentModel.DataAnnotations;

namespace Trucking.Models.Update
{
    public class UpdateTruckerDto
    {
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; }
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
    }
}