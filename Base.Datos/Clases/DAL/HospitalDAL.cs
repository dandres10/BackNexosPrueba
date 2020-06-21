namespace Base.Datos.Clases.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.IC.Acciones.Entidades;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.RecursosTexto;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HospitalDAL : IHospitalAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private Respuesta<IHospitalDTO> Respuesta;
        private Respuestas<IHospitalDTO> Respuestas;
        private List<IHospitalDTO> listaHospital;
        private List<string> listaMensajes;
        private Hospital data;

        public HospitalDAL(Context context, IMapper mapper)
        {
            this.Respuesta = new Respuesta<IHospitalDTO>();
            this.Respuestas = new Respuestas<IHospitalDTO>();
            this.context = context;
            this.mapper = mapper;
            this.listaMensajes = new List<string>();
            this.listaHospital = new List<IHospitalDTO>();
            this.data = new Hospital();
        }

        public async Task<Respuesta<IHospitalDTO>> ConsultarHospital(IHospitalDTO hospital)
        {
            try
            {
                data = await context.Hospital.FirstOrDefaultAsync(x => x.CodigoHospital == hospital.CodigoHospital);
                if (data == null)
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    listaHospital.Add(data);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaHospital, listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IHospitalDTO>> ConsultarListaHospitales()
        {
            try
            {
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                listaHospital = mapper.Map<List<IHospitalDTO>>(await context.Hospital.ToListAsync());
                Respuesta = Respuestas.Exitosa(listaHospital, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }
    }
}