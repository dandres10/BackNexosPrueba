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

    public class DoctorDAL : IDoctorAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private Respuesta<IDoctorDTO> Respuesta;
        private Respuestas<IDoctorDTO> Respuestas;
        private List<IDoctorDTO> listaPaciente;
        private List<string> listaMensajes;
        private Doctor data;

        public DoctorDAL(Context context, IMapper mapper)
        {
            this.Respuesta = new Respuesta<IDoctorDTO>();
            this.Respuestas = new Respuestas<IDoctorDTO>();
            this.context = context;
            this.mapper = mapper;
            this.listaMensajes = new List<string>();
            this.listaPaciente = new List<IDoctorDTO>();
            this.data = new Doctor();
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarDoctor(IDoctorDTO doctor)
        {

            try
            {
                data = await context.Doctor.FirstOrDefaultAsync(x => x.CodigoDoctor == doctor.CodigoDoctor);
                if (data == null)
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    listaPaciente.Add(data);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaPaciente, listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarListaDoctores()
        {
            try
            {
                listaPaciente = mapper.Map<List<IDoctorDTO>>(await context.Doctor.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaPaciente, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IDoctorDTO>> GuardarDoctor(IDoctorDTO doctor)
        {
            try
            {
                listaPaciente.Add(doctor);
                context.Add(mapper.Map<Doctor>(doctor));
                await context.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaPaciente, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.GuardadoFallido);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }
    }
}