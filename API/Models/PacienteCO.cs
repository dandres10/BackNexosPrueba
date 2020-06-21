namespace API.Models
{
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Validaciones;
    using System.ComponentModel.DataAnnotations;

    public class PacienteCO : IPacienteDTO
    {
        public int CodigoPaciente { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [CantidadDigitos(7)]
        public string CodPostal { get; set; }

        [CantidadDigitos(11)]
        public string Telefono { get; set; }
    }
}