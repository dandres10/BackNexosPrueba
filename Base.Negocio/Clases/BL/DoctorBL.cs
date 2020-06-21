namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class DoctorBL : IDoctorAccion
    {
        private readonly DoctorDAL doctorDAL;
        private readonly ILogger logger;

        public DoctorBL(DoctorDAL doctorDAL, ILogger<DoctorBL> logger)
        {
            this.doctorDAL = doctorDAL;
            this.logger = logger;
            logger.LogInformation(LoggerDoctor.CapaNegocio);
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarDoctor(IDoctorDTO doctor)
        {
            logger.LogInformation(LoggerDoctor.ConsultarDoctor);
            return await doctorDAL.ConsultarDoctor(doctor);
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarListaDoctores()
        {
            logger.LogInformation(LoggerDoctor.ConsultarListaDoctores);
            return await doctorDAL.ConsultarListaDoctores();
        }

        public async Task<Respuesta<IDoctorDTO>> GuardarDoctor(IDoctorDTO doctor)
        {
            logger.LogInformation(LoggerDoctor.GuardarDoctor);
            return await doctorDAL.GuardarDoctor(doctor);
        }
    }
}