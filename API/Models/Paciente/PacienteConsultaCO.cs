namespace API.Models.Paciente
{
    using System.ComponentModel.DataAnnotations;

    public class PacienteConsultaCO
    {
        [Required]
        public int CodigoPaciente { get; set; }
    }
}