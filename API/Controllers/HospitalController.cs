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
    public class HospitalController
    {
        private readonly HospitalBL hospitalBL;
        private readonly IMapper mapper;

        public HospitalController(HospitalBL hospitalBL, IMapper mapper)
        {
            this.hospitalBL = hospitalBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("ConsultarHospital")]
        public async Task<Respuesta<HospitalCO>> ConsultarHospital(HospitalCO hospital)
        {
            return mapper.Map<Respuesta<HospitalCO>>(await hospitalBL.ConsultarHospital(hospital));
        }

        [HttpGet]
        [Route("ConsultarListaHospitales")]
        public async Task<Respuesta<HospitalCO>> ConsultarListaHospitales()
        {
            return mapper.Map<Respuesta<HospitalCO>>(await hospitalBL.ConsultarListaHospitales());
        }
    }
}