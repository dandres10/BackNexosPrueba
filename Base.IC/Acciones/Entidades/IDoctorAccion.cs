namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IDoctorAccion
    {
        Task<Respuesta<IDoctorDTO>> GuardarDoctor(IDoctorDTO doctor);

        Task<Respuesta<IDoctorDTO>> ConsultarListaDoctores();

        Task<Respuesta<IDoctorDTO>> ConsultarDoctor(IDoctorDTO doctor);
    }
}