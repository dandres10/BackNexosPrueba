namespace Base.Datos.Contexto.Entidades
{
    public partial class Doctor
    {
        public int CodigoDoctor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Especialidad { get; set; }
        public string NumeroCredencial { get; set; }
        public int Hospital { get; set; }

        public virtual Especialidad EspecialidadNavigation { get; set; }
        public virtual Hospital HospitalNavigation { get; set; }
    }
}