namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IPacienteAccion
    {
        Task<Respuesta<IPacienteDTO>>  GuardarPaciente(IPacienteDTO paciente);

        Task<Respuesta<IPacienteDTO>> EditarPaciente(IPacienteDTO paciente);

        Task<Respuesta<IPacienteDTO>> ConsultarListaPacientes();

        Task<Respuesta<IPacienteDTO>> EliminarPaciente(IPacienteDTO paciente);

        Task<Respuesta<IPacienteDTO>> ConsultarPaciente(IPacienteDTO paciente);
    }
}