using TempLaboClini.Domain.Aggregates;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    internal class EstadoExamenActualizado : IDomainEvent
    {
        public EstadoExamenActualizado(SolicitudExamen solicitudExamen, long examenSolicitadoId, string nuevoEstado)
        {
            SolicitudExamen = solicitudExamen;
            ExamenSolicitadoId = examenSolicitadoId;
            NuevoEstado = nuevoEstado;
        }

        public SolicitudExamen SolicitudExamen { get; }
        public long ExamenSolicitadoId { get; }
        public string NuevoEstado { get; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "EstadoExamenActualizado";

        public void HandleEvent()
        {
            throw new NotImplementedException();
        }
    }
}