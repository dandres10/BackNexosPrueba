using Base.IC.Clases;
using Base.IC.DTO.EntidadesRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.IC.Acciones.Entidades
{
    public interface IPacienteAccion
    {
        Respuesta<IPacienteDTO> GuardarPaciente(IPacienteDTO paciente);

        Respuesta<IPacienteDTO> EditarPaciente(IPacienteDTO paciente);

        Respuesta<IPacienteDTO> ConsultarListaPacientes();

        Respuesta<IPacienteDTO> EliminarPaciente(IPacienteDTO paciente);

        Respuesta<IPacienteDTO> ConsultarPaciente(IPacienteDTO paciente);
    }
}
