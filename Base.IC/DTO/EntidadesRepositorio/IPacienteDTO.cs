namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IPacienteDTO
    {
        int CodigoPaciente { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string CodPostal { get; set; }
        string Telefono { get; set; }
    }
}