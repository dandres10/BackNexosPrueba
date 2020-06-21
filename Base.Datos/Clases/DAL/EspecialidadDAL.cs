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

    public class EspecialidadDAL : IEspecialidadAccion
    {
        private readonly Context context;
        private readonly IMapper mapper;
        private Respuesta<IEspecialidadDTO> Respuesta;
        private Respuestas<IEspecialidadDTO> Respuestas;
        private List<IEspecialidadDTO> listaEspecialidad;
        private List<string> listaMensajes;
        private Especialidad data;

        public EspecialidadDAL(Context context, IMapper mapper)
        {
            this.Respuesta = new Respuesta<IEspecialidadDTO>();
            this.Respuestas = new Respuestas<IEspecialidadDTO>();
            this.context = context;
            this.mapper = mapper;
            this.listaMensajes = new List<string>();
            this.listaEspecialidad = new List<IEspecialidadDTO>();
            this.data = new Especialidad();
        }

        public async Task<Respuesta<IEspecialidadDTO>> ConsultarEspecialidad(IEspecialidadDTO especialidad)
        {
            try
            {
                data = await context.Especialidad.FirstOrDefaultAsync(x => x.CodigoEspecialidad == especialidad.CodigoEspecialidad);
                if (data == null)
                {
                    listaMensajes.Add(MensajesBase.DatoNoEncontrado);
                    Respuesta = Respuestas.Alerta(listaMensajes);
                }
                else
                {
                    listaEspecialidad.Add(data);
                    listaMensajes.Add(MensajesBase.ConsultaExitosa);
                    Respuesta = Respuestas.Exitosa(listaEspecialidad, listaMensajes);
                }
            }
            catch (Exception)
            {
                listaMensajes.Add(MensajesBase.ConsultaFallida);
                Respuesta = Respuestas.Fallida(listaMensajes);
            }
            return Respuesta;
        }

        public async Task<Respuesta<IEspecialidadDTO>> ConsultarListaEspecialidades()
        {
            try
            {
                listaMensajes.Add(MensajesBase.ConsultaExitosa);
                listaEspecialidad = mapper.Map<List<IEspecialidadDTO>>(await context.Especialidad.ToListAsync());
                Respuesta = Respuestas.Exitosa(listaEspecialidad, listaMensajes);
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