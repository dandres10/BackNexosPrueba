namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class HospitalBL : IHospitalAccion
    {
        private readonly HospitalDAL hospitalDAL;

        public HospitalBL(HospitalDAL hospitalDAL)
        {
            this.hospitalDAL = hospitalDAL;
        }

        public async Task<Respuesta<IHospitalDTO>> ConsultarHospital(IHospitalDTO hospital)
        {
            return await hospitalDAL.ConsultarHospital(hospital);
        }

        public async Task<Respuesta<IHospitalDTO>> ConsultarListaHospitales()
        {
            return await hospitalDAL.ConsultarListaHospitales();
        }
    }
}