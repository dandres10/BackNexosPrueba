namespace Base.Negocio.Clases.BO
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class PacienteBO : IPacienteDTO
    {
        public int CodigoPaciente { get ; set ; }
        public string Nombre { get ; set ; }
        public string Apellido { get ; set ; }
        public string CodPostal { get ; set ; }
        public string Telefono { get ; set ; }
    }
}