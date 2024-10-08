using TempLaboClini.Domain.Aggregates;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    internal class SolicitudPagada : IDomainEvent
    {
        public SolicitudPagada(SolicitudExamen solicitudExamen)
        {
            SolicitudExamen = solicitudExamen;
        }

        public Guid EventId => throw new NotImplementedException();

        public DateTime FechaOcurrencia => throw new NotImplementedException();

        public string EventType => throw new NotImplementedException();

        public SolicitudExamen SolicitudExamen { get; }

        public void HandleEvent()
        {
            throw new NotImplementedException();
        }
    }
}