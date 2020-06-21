namespace Base.Datos.Contexto.Entidades
{
    public partial class DoctorPaciente
    {
        public int CodigoDoctor { get; set; }
        public int CodigoPaciente { get; set; }

        public virtual Doctor CodigoDoctorNavigation { get; set; }
        public virtual Paciente CodigoPacienteNavigation { get; set; }
    }
}