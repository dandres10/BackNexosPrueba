namespace API.Controllers
{
    using API.Models.Paciente;
    using AutoMapper;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Base.Negocio.Clases.BL;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController
    {
        private readonly PacienteBL pacienteBL;
        private readonly IMapper mapper;
        private readonly ILogger<PacienteController> logger;

        public PacienteController(PacienteBL pacienteBL, IMapper mapper, ILogger<PacienteController> logger)
        {
            this.pacienteBL = pacienteBL;
            this.mapper = mapper;
            this.logger = logger;
            logger.LogInformation(LoggerPaciente.CapaControlador);
        }

        [HttpGet]
        [Route("ConsultarListaPacientes")]
        public async Task<Respuesta<PacienteCO>> ConsultarListaPacientes()
        {
            logger.LogInformation(LoggerPaciente.ConsultarListaPacientes);
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.ConsultarListaPacientes());
        }

        [HttpPost]
        [Route("ConsultarPaciente")]
        public async Task<Respuesta<PacienteCO>> ConsultarPaciente(PacienteConsultaCO paciente)
        {
            logger.LogInformation(LoggerPaciente.ConsultarPaciente);
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.ConsultarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }

        [HttpPut]
        [Route("EditarPaciente")]
        public async Task<Respuesta<PacienteCO>> EditarPaciente(PacienteCO paciente)
        {
            logger.LogInformation(LoggerPaciente.EditarPaciente);
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.EditarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }

        [HttpPost]
        [Route("EliminarPaciente")]
        public async Task<Respuesta<PacienteCO>> EliminarPaciente(PacienteConsultaCO paciente)
        {
            logger.LogInformation(LoggerPaciente.EliminarPaciente);
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.EliminarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }

        [HttpPost]
        [Route("GuardarPaciente")]
        public async Task<Respuesta<PacienteCO>> GuardarPaciente(PacienteGuardarCO paciente)
        {
            logger.LogInformation(LoggerPaciente.GuardarPaciente);
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.GuardarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }
    }
}