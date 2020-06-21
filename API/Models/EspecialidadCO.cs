namespace API.Models
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class EspecialidadCO : IEspecialidadDTO
    {
        public int CodigoEspecialidad { get; set; }
        public string Nombre { get; set; }
    }
}