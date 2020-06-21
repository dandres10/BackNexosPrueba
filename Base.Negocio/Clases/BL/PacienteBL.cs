namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public class PacienteBL : IPacienteAccion
    {
        private readonly PacienteDAL pacienteDAL;

        public PacienteBL(PacienteDAL pacienteDAL)
        {
            this.pacienteDAL = pacienteDAL;
        }

        public async Task<Respuesta<IPacienteDTO>> ConsultarListaPacientes()
        {
            return await pacienteDAL.ConsultarListaPacientes();
        }

        public async Task<Respuesta<IPacienteDTO>> ConsultarPaciente(IPacienteDTO paciente)
        {
            return await pacienteDAL.ConsultarPaciente(paciente);
        }

        public async Task<Respuesta<IPacienteDTO>> EditarPaciente(IPacienteDTO paciente)
        {
            return await pacienteDAL.EditarPaciente(paciente);
        }

        public async Task<Respuesta<IPacienteDTO>> EliminarPaciente(IPacienteDTO paciente)
        {
            return await pacienteDAL.EliminarPaciente(paciente);
        }

        public async Task<Respuesta<IPacienteDTO>> GuardarPaciente(IPacienteDTO paciente)
        {
            return await pacienteDAL.GuardarPaciente(paciente);
        }
    }
}