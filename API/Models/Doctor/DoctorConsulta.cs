namespace API.Models.Doctor
{
    using System.ComponentModel.DataAnnotations;

    public class DoctorConsulta
    {
        [Required]
        public int CodigoDoctor { get; set; }
    }
}