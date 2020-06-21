namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface IDoctorPacienteAccion
    {
        Respuesta<IDoctorPacienteDTO> GuardarPaciente(IPacienteDTO paciente);
    }
}