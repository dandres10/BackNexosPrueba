namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IEspecialidadAccion
    {
        Task<Respuesta<IEspecialidadDTO>> ConsultarListaEspecialidades();

        Task<Respuesta<IEspecialidadDTO>> ConsultarEspecialidad(IEspecialidadDTO especialidad);
    }
}