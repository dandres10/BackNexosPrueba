namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface IHospitalAccion
    {
        Respuesta<IHospitalDTO> ConsultarListaPacientes();
    }
}