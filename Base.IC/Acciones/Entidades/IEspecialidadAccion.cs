namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface IEspecialidadAccion
    {
        Respuesta<IEspecialidadDTO> ConsultarListaPacientes();
    }
}