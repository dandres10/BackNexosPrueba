namespace Base.IC.Acciones.Entidades
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Threading.Tasks;

    public interface IHospitalAccion
    {
        Task<Respuesta<IHospitalDTO>> ConsultarListaHospitales();

        Task<Respuesta<IHospitalDTO>> ConsultarHospital(IHospitalDTO hospital);
    }
}