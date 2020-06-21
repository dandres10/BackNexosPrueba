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
    using System.Linq;
    using System.Threading.Tasks;

    public class PacienteDAL : IPacienteAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private Respuesta<IPacienteDTO> Respuesta;
        private Respuestas<IPacienteDTO> Respuestas;
        private List<IPacienteDTO> listaPaciente;
        private List<string> listaMensajes;
        private Paciente data;

        public PacienteDAL(Context context, IMapper mapper)
        {
            this.Respuesta = new Respuesta<IPacienteDTO>();
            this.Respuestas = new Respuestas<IPacienteDTO>();
            this.context = context;
            this.mapper = mapper;
            this.listaMensajes = new List<string>();
            this.listaPaciente = new List<IPacienteDTO>();
            this.data = new Paciente();
        }

        public async Task<Respuesta<IPacienteDTO>> ConsultarListaPacientes()
        {
            try
            {
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                listaPaciente = mapper.Map<List<IPacienteDTO>>(await context.Paciente.ToListAsync());
                Respuesta = Respuestas.Exitosa(listaPaciente, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }

        public async Task<Respuesta<IPacienteDTO>> ConsultarPaciente(IPacienteDTO paciente)
        {
            try
            {
                data = await context.Paciente.FirstOrDefaultAsync(x => x.CodigoPaciente == paciente.CodigoPaciente);
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

        public async Task<Respuesta<IPacienteDTO>> EditarPaciente(IPacienteDTO paciente)
        {
            try
            {
                context.Entry(mapper.Map<Paciente>(paciente)).State = EntityState.Modified;
                await context.SaveChangesAsync();
                listaPaciente.Add(mapper.Map<Paciente>(paciente));
                listaMensajes.Add(MensajesBase.DatosEditados);
                Respuesta = Respuestas.Exitosa(listaPaciente, listaMensajes);
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.DatosNoEditados);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IPacienteDTO>> EliminarPaciente(IPacienteDTO paciente)
        {
            try
            {
                int pacienteId = await context.Paciente.Select(x => x.CodigoPaciente).FirstOrDefaultAsync(x => x == paciente.CodigoPaciente);
                listaPaciente.Add(paciente);
                if (pacienteId == default(int))
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaPaciente, listaMensajes);
                }
                else
                {
                    context.Paciente.Remove(new Paciente { CodigoPaciente = pacienteId });
                    await context.SaveChangesAsync();
                    listaMensajes.Add(MensajesBase.EliminacionExitosa);
                    Respuesta = Respuestas.Exitosa(listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.EliminacionFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }

            return Respuesta;
        }

        public async Task<Respuesta<IPacienteDTO>> GuardarPaciente(IPacienteDTO paciente)
        {
            try
            {
                listaPaciente.Add(paciente);
                context.Add(mapper.Map<Paciente>(paciente));
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