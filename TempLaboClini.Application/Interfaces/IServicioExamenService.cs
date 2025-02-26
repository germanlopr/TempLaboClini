using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Application.DTOs;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Infrastructure.Repositories;

namespace TempLaboClini.Application.Interfaces
{
    //public interface IServicioExamenService
    //{
    //    void RegistrarPaciente(PacienteDTO pacienteDTO);

    //    void CrearSolicitudExamen(SolicitudExamenDTO solicitudDTO);

    //}

    public interface IServicioExamenService
    {
        // Métodos para gestionar pacientes
        //void RegistrarPaciente(PacienteDTO pacienteDTO);

        // Métodos para gestionar solicitudes de examen
        //void CrearSolicitudExamen(SolicitudExamenDTO solicitudDTO);

        // Métodos para gestionar Obtenr todas las solicitudes
        IEnumerable<SolicitudExamenDTO> ObtenerTodasLasSolicitudes();

        // Métodos para gestionar solicitudes por el id
        SolicitudExamenDTO ObtenerSolicitudPorId(long id);

        // Métodos para gestionar la actualizacion solicitudes de examen
        void ActualizarSolicitud(SolicitudExamenDTO solicitudDTO);

        // Métodos para gestionar resultados de examen
        void RegistrarResultadoExamen(long examenSolicitadoId, ResultadoDTO resultadoDTO);
        IEnumerable ObtenerPacientes();
        IEnumerable ObtenerAseguradoras();
        IEnumerable ObtenerMedicos();
    }

}
