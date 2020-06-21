namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class PacienteBL : IPacienteAccion
    {
        private readonly PacienteDAL pacienteDAL;
        private readonly ILogger logger;

        public PacienteBL(PacienteDAL pacienteDAL, ILogger<PacienteBL> logger)
        {
            this.pacienteDAL = pacienteDAL;
            this.logger = logger;
            logger.LogInformation(LoggerPaciente.CapaNegocio);
        }

        public async Task<Respuesta<IPacienteDTO>> ConsultarListaPacientes()
        {
            logger.LogInformation(LoggerPaciente.ConsultarListaPacientes);
            return await pacienteDAL.ConsultarListaPacientes();
        }

        public async Task<Respuesta<IPacienteDTO>> ConsultarPaciente(IPacienteDTO paciente)
        {
            logger.LogInformation(LoggerPaciente.ConsultarPaciente);
            return await pacienteDAL.ConsultarPaciente(paciente);
        }

        public async Task<Respuesta<IPacienteDTO>> EditarPaciente(IPacienteDTO paciente)
        {
            logger.LogInformation(LoggerPaciente.EditarPaciente);
            return await pacienteDAL.EditarPaciente(paciente);
        }

        public async Task<Respuesta<IPacienteDTO>> EliminarPaciente(IPacienteDTO paciente)
        {
            logger.LogInformation(LoggerPaciente.EliminarPaciente);
            return await pacienteDAL.EliminarPaciente(paciente);
        }

        public async Task<Respuesta<IPacienteDTO>> GuardarPaciente(IPacienteDTO paciente)
        {
            logger.LogInformation(LoggerPaciente.GuardarPaciente);
            return await pacienteDAL.GuardarPaciente(paciente);
        }
    }
}