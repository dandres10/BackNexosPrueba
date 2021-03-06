﻿namespace API.Models.Paciente
{
    using Base.IC.Validaciones;
    using System.ComponentModel.DataAnnotations;

    public class PacienteGuardarCO
    {
        [Required]
        [CantidadCaracteres(51)]
        public string Nombre { get; set; }

        [Required]
        [CantidadCaracteres(51)]
        public string Apellido { get; set; }

        [Required]
        [CantidadDigitos(7)]
        public string CodPostal { get; set; }

        [Required]
        [CantidadDigitos(11)]
        public string Telefono { get; set; }
    }
}