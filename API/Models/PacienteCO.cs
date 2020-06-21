namespace API.Models
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class PacienteCO : IPacienteDTO
    {
        public int CodigoPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CodPostal { get; set; }
        public string Telefono { get; set; }
    }
}