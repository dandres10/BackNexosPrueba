namespace API.Controllers
{
    using API.Models;
    using AutoMapper;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController
    {
        private readonly PacienteBL pacienteBL;
        private readonly IMapper mapper;

        public PacienteController(PacienteBL pacienteBL, IMapper mapper)
        {
            this.pacienteBL = pacienteBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarListaPacientes")]
        public async Task<Respuesta<PacienteCO>> ConsultarListaPacientes()
        {
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.ConsultarListaPacientes()); 
        }

        [HttpGet]
        [Route("ConsultarPaciente")]
        public async Task<Respuesta<PacienteCO>> ConsultarPaciente(PacienteCO paciente)
        {
            
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.ConsultarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }

        [HttpPut]
        [Route("EditarPaciente")]
        public async Task<Respuesta<PacienteCO>> EditarPaciente(PacienteCO paciente)
        {
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.EditarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }

        [HttpDelete]
        [Route("EliminarPaciente")]
        public async Task<Respuesta<PacienteCO>> EliminarPaciente(PacienteCO paciente)
        {
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.EliminarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }

        [HttpPost]
        [Route("GuardarPaciente")]
        public async Task<Respuesta<PacienteCO>> GuardarPaciente(PacienteCO paciente)
        {
            return mapper.Map<Respuesta<PacienteCO>>(await pacienteBL.GuardarPaciente(mapper.Map<IPacienteDTO>(paciente)));
        }
    }
}