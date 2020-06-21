namespace API.Controllers
{
    using API.Models.Doctor;
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
    public class DoctorController
    {
        private readonly DoctorBL doctorBL;
        private readonly IMapper mapper;
        private readonly ILogger<DoctorController> logger;

        public DoctorController(DoctorBL doctorBL, IMapper mapper, ILogger<DoctorController> logger)
        {
            this.doctorBL = doctorBL;
            this.mapper = mapper;
            this.logger = logger;
            logger.LogInformation(LoggerDoctor.CapaControlador);
        }

        [HttpGet]
        [Route("ConsultarDoctor")]
        public async Task<Respuesta<DoctorCO>> ConsultarDoctor(DoctorConsulta doctor)
        {
            logger.LogInformation(LoggerDoctor.ConsultarDoctor);
            return mapper.Map<Respuesta<DoctorCO>>(await doctorBL.ConsultarDoctor(mapper.Map<IDoctorDTO>(doctor)));
        }

        [HttpGet]
        [Route("ConsultarListaDoctores")]
        public async Task<Respuesta<DoctorCO>> ConsultarListaDoctores()
        {
            logger.LogInformation(LoggerDoctor.ConsultarListaDoctores);
            return mapper.Map<Respuesta<DoctorCO>>(await doctorBL.ConsultarListaDoctores());
        }

        [HttpPost]
        [Route("GuardarDoctor")]
        public async Task<Respuesta<DoctorCO>> GuardarDoctor(DoctorGuradar doctor)
        {
            logger.LogInformation(LoggerDoctor.GuardarDoctor);
            return mapper.Map<Respuesta<DoctorCO>>(await doctorBL.GuardarDoctor(mapper.Map<IDoctorDTO>(doctor)));
        }
    }
}