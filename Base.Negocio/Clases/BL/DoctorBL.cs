namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class DoctorBL : IDoctorAccion
    {
        private readonly DoctorDAL doctorDAL;

        public DoctorBL(DoctorDAL doctorDAL)
        {
            this.doctorDAL = doctorDAL;
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarDoctor(IDoctorDTO doctor)
        {
            return await doctorDAL.ConsultarDoctor(doctor);
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarListaDoctores()
        {
            return await doctorDAL.ConsultarListaDoctores();
        }

        public async Task<Respuesta<IDoctorDTO>> GuardarDoctor(IDoctorDTO doctor)
        {
            return await doctorDAL.GuardarDoctor(doctor);
        }
    }
}