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
    public class EspecialidadController
    {
        private readonly EspecialidadBL especialidadBL;
        private readonly IMapper mapper;

        public EspecialidadController(EspecialidadBL especialidadBL, IMapper mapper)
        {
            this.especialidadBL = especialidadBL;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("ConsultarEspecialidad")]
        public async Task<Respuesta<EspecialidadCO>> ConsultarEspecialidad(EspecialidadCO especialidad)
        {
            return mapper.Map<Respuesta<EspecialidadCO>>(await especialidadBL.ConsultarEspecialidad(especialidad));
        }

        [HttpGet]
        [Route("ConsultarListaEspecialidades")]
        public async Task<Respuesta<EspecialidadCO>> ConsultarListaEspecialidades()
        {
            return mapper.Map<Respuesta<EspecialidadCO>>(await especialidadBL.ConsultarListaEspecialidades());
        }
    }
}