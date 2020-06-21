namespace API.Models.Paciente
{
    using System.ComponentModel.DataAnnotations;

    public class PacienteConsulta
    {
        [Required]
        public int CodigoPaciente { get; set; }
    }
}