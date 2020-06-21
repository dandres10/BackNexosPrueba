namespace API.Controllers
{
    using API.Models;
    using AutoMapper;
    using Base.IC.Clases;
    using Base.Negocio.Clases.BL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController
    {
        private readonly DoctorBL doctorBL;
        private readonly IMapper mapper;

        public DoctorController(DoctorBL doctorBL, IMapper mapper)
        {
            this.doctorBL = doctorBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarDoctor")]
        public async Task<Respuesta<DoctorCO>> ConsultarDoctor(DoctorCO doctor)
        {
            return mapper.Map<Respuesta<DoctorCO>>(await doctorBL.ConsultarDoctor(doctor));
        }

        [HttpGet]
        [Route("ConsultarListaDoctores")]
        public async Task<Respuesta<DoctorCO>> ConsultarListaDoctores()
        {
            return mapper.Map<Respuesta<DoctorCO>>(await doctorBL.ConsultarListaDoctores());
        }

        [HttpPost]
        [Route("GuardarDoctor")]
        public async Task<Respuesta<DoctorCO>> GuardarDoctor(DoctorCO doctor)
        {
            return mapper.Map<Respuesta<DoctorCO>>(await doctorBL.GuardarDoctor(doctor));
        }
    }
}