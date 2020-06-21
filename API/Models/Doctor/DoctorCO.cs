namespace API.Models.Doctor
{
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Validaciones;
    using System.ComponentModel.DataAnnotations;

    public class DoctorCO : IDoctorDTO
    {
        public int CodigoDoctor { get; set; }

        [Required]
        [CantidadCaracteres(51)]
        public string Nombre { get; set; }

        [Required]
        [CantidadCaracteres(51)]
        public string Apellido { get; set; }

        [Required]
        public int Especialidad { get; set; }

        [Required]
        [CantidadCaracteres(51)]
        public string NumeroCredencial { get; set; }

        [Required]
        public int Hospital { get; set; }
    }
}