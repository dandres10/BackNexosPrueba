namespace API.Models.Doctor
{
    using Base.IC.Validaciones;
    using System.ComponentModel.DataAnnotations;

    public class DoctorGuradarCO
    {
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