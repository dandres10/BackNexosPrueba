namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface IDoctorAccion
    {
        Respuesta<IDoctorDTO> GuardarDoctor(IDoctorDTO doctor);

        Respuesta<IDoctorDTO> EditarDoctor(IDoctorDTO doctor);

        Respuesta<IDoctorDTO> ConsultarListaDoctores();

        Respuesta<IDoctorDTO> EliminarDoctor(IDoctorDTO doctor);

        Respuesta<IDoctorDTO> ConsultarDoctor(IDoctorDTO doctor);
    }
}