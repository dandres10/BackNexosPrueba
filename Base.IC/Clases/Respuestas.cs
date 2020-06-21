namespace Base.IC.Clases
{
    using Base.IC.Enumeraciones;
    using System.Collections.Generic;

    public class Respuestas<T>
    {
        private Respuesta<T> Respuesta;

        public Respuestas()
        {
            this.Respuesta = new Respuesta<T>();
        }

        public Respuesta<T> Exitosa(List<T> entidades, List<string> mensaje)
        {
            Respuesta.Entidades = entidades;
            Respuesta.Mensajes.AddRange(mensaje);
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
            return Respuesta;
        }

        public Respuesta<T> Exitosa(List<string> mensaje)
        {
            Respuesta.Mensajes.AddRange(mensaje);
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
            return Respuesta;
        }

        public Respuesta<T> Fallida(List<string> mensaje)
        {
            Respuesta.Mensajes.AddRange(mensaje);
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = TipoNotificacion.Fallida;
            return Respuesta;
        }

        public Respuesta<T> Alerta(List<T> entidades, List<string> mensaje)
        {
            Respuesta.Entidades = entidades;
            Respuesta.Mensajes.AddRange(mensaje);
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = TipoNotificacion.Advertencia;
            return Respuesta;
        }

        public Respuesta<T> Alerta(List<string> mensaje)
        {
            Respuesta.Mensajes.AddRange(mensaje);
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = TipoNotificacion.Advertencia;
            return Respuesta;
        }
    }
}