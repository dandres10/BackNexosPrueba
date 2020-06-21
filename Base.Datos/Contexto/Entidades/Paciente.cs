namespace Base.Datos.Contexto.Entidades
{
    public partial class Paciente
    {
        public int CodigoPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CodPostal { get; set; }
        public string Telefono { get; set; }
    }
}