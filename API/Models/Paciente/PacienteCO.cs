namespace API.Models.Paciente
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

        [Required]
        [CantidadDigitos(7)]
        public string CodPostal { get; set; }

        [Required]
        [CantidadDigitos(11)]
        public string Telefono { get; set; }
    }
}