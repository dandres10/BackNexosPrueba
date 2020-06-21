namespace Base.Datos.Contexto.Entidades
{
    using System.Collections.Generic;

    public partial class Especialidad
    {
        public Especialidad()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int CodigoEspecialidad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}