namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IDoctorDTO
    {
        int CodigoDoctor { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        int Especialidad { get; set; }
        string NumeroCredencial { get; set; }
        int Hospital { get; set; }
    }
}