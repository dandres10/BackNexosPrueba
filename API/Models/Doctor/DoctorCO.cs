namespace API.Models.Doctor
{
    using Base.IC.DTO.EntidadesRepositorio;
    using System.ComponentModel.DataAnnotations;

    public class DoctorCO : IDoctorDTO
    {
        public int CodigoDoctor { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public int Especialidad { get; set; }

        [Required]
        public string NumeroCredencial { get; set; }

        [Required]
        public int Hospital { get; set; }
    }
}