namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class EspecialidadBL : IEspecialidadAccion
    {
        private readonly EspecialidadDAL especialidadDAL;

        public EspecialidadBL(EspecialidadDAL especialidadDAL)
        {
            this.especialidadDAL = especialidadDAL;
        }

        public async Task<Respuesta<IEspecialidadDTO>> ConsultarEspecialidad(IEspecialidadDTO especialidad)
        {
            return await especialidadDAL.ConsultarEspecialidad(especialidad);
        }

        public async Task<Respuesta<IEspecialidadDTO>> ConsultarListaEspecialidades()
        {
            return await especialidadDAL.ConsultarListaEspecialidades();
        }
    }
}