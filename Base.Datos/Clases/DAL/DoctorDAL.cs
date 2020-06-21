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
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DoctorDAL : IDoctorAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private readonly ILogger<DoctorDAL> logger;
        private Respuesta<IDoctorDTO> Respuesta;
        private Respuestas<IDoctorDTO> Respuestas;
        private List<IDoctorDTO> listaDoctor;
        private List<string> listaMensajes;
        private Doctor data;

        public DoctorDAL(Context context, IMapper mapper, ILogger<DoctorDAL> logger)
        {
            this.Respuesta = new Respuesta<IDoctorDTO>();
            this.Respuestas = new Respuestas<IDoctorDTO>();
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
            this.listaMensajes = new List<string>();
            this.listaDoctor = new List<IDoctorDTO>();
            this.data = new Doctor();
            logger.LogInformation(LoggerDoctor.CapaDatos);
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarDoctor(IDoctorDTO doctor)
        {
            try
            {
                data = await context.Doctor.FirstOrDefaultAsync(x => x.CodigoDoctor == doctor.CodigoDoctor);
                if (data == null)
                {
                    logger.LogWarning(string.Format(LoggerDoctor.DoctorNoEncontrado, doctor.CodigoDoctor));
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    logger.LogInformation(LoggerDoctor.DoctorConsultaCorrecta);
                    listaDoctor.Add(data);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaDoctor, listaMensajes);
                }
            }
            catch (Exception)
            {
                logger.LogError(LoggerDoctor.ConsultaFallo);
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IDoctorDTO>> ConsultarListaDoctores()
        {
            try
            {
                listaDoctor = mapper.Map<List<IDoctorDTO>>(await context.Doctor.ToListAsync());
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                Respuesta = Respuestas.Exitosa(listaDoctor, listaMensajes);
                logger.LogInformation(LoggerDoctor.DoctorConsultaCorrecta);
            }
            catch (Exception)
            {
                logger.LogError(LoggerDoctor.ConsultaFallo);
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IDoctorDTO>> GuardarDoctor(IDoctorDTO doctor)
        {
            try
            {
                listaDoctor.Add(doctor);
                context.Add(mapper.Map<Doctor>(doctor));
                await context.SaveChangesAsync();
                listaMensajes.Add(MensajesBase.GuardadoExitoso);
                Respuesta = Respuestas.Exitosa(listaDoctor, listaMensajes);
                logger.LogInformation(LoggerDoctor.DoctorGuardado);
            }
            catch (Exception)
            {
                logger.LogError(LoggerDoctor.ConsultaFallo);
                listaMensajes.Add(MensajesBase.GuardadoFallido);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }
    }
}