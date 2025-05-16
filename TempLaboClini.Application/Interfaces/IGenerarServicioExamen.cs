using System;
using TempLaboClini.Application.DTOs;
using TempLaboClini.Domain.Entities;

namespace TempLaboClini.Application.Interfaces
{

    public interface IGenerarServicioExamen
    {
            // Gestión de solicitudes de examen
            void RegistrarSolicitudExamen(SolicitudExamenDTO solicitudDTO);
            SolicitudExamenDTO ObtenerSolicitudPorId(long id);
            IEnumerable<SolicitudExamenDTO> ObtenerTodasLasSolicitudes();
            void ActualizarSolicitud(SolicitudExamenDTO solicitudDTO);

            // Gestión de muestras
            void RecibirMuestra(long examenSolicitadoId, string estadoMuestra);
            void AsignarPersonalAMuestra(long examenSolicitadoId, long personalLaboratorioId);

            // Análisis de muestras
            void AnalizarMuestra(long examenSolicitadoId, long personalLaboratorioId);
            void RegistrarResultadoExamen(long examenSolicitadoId, ResultadoDTO resultadoDTO);

            // Generación de informes
            byte[] GenerarInforme(long solicitudExamenId);

            // Consulta de resultados
            IEnumerable<ExamenSolicitadoDTO> ConsultarResultadosPorPaciente(long pacienteId);
            IEnumerable<ExamenSolicitadoDTO> ConsultarResultadosPorFecha(DateTime fechaInicio, DateTime fechaFin);

            // Gestión de personal de laboratorio
            void RegistrarPersonalLaboratorio(PersonalLaboratorioDTO personalDTO);
            void ActualizarPersonalLaboratorio(PersonalLaboratorioDTO personalDTO);
            IEnumerable<PersonalLaboratorioDTO> ObtenerPersonalLaboratorio();
            PersonalLaboratorioDTO ObtenerPersonalLaboratorioPorId(long id);

            // Métodos auxiliares
            IEnumerable<PacienteDTO> ObtenerPacientes();
            IEnumerable<AseguradoraDTO> ObtenerAseguradoras();
            IEnumerable<MedicoDTO> ObtenerMedicos();
            IEnumerable<ExamenDTO> ObtenerExamenes();
        
    }
}
