namespace API.Models
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class DoctorCO : IDoctorDTO
    {
        public int CodigoDoctor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Especialidad { get; set; }
        public string NumeroCredencial { get; set; }
        public int Hospital { get; set; }
    }
}