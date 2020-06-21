namespace API.Models
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class HospitalCO : IHospitalDTO
    {
        public int CodigoHospital { get; set; }
        public string Nombre { get; set; }
    }
}