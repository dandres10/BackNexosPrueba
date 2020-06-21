namespace Base.Datos.Contexto.Entidades
{
    using System.Collections.Generic;

    public partial class Hospital
    {
        public Hospital()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int CodigoHospital { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}