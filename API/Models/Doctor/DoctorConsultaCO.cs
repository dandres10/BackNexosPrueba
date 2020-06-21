namespace API.Models.Doctor
{
    using System.ComponentModel.DataAnnotations;

    public class DoctorConsultaCO
    {
        [Required]
        public int CodigoDoctor { get; set; }
    }
}