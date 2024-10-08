using TempLaboClini.Domain.Aggregates;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class MuestraRecibida : IDomainEvent
    {
        public long MuestraId { get; private set; }
        public DateTime FechaRecepcion { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "MuestraRecibida";

        public SolicitudExamen SolicitudExamen { get; }

        public MuestraRecibida(long muestraId, DateTime fechaRecepcion)
        {
            MuestraId = muestraId;
            FechaRecepcion = fechaRecepcion;
            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public MuestraRecibida(SolicitudExamen solicitudExamen)
        {
            SolicitudExamen = solicitudExamen;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Muestra Recibida con ID {MuestraId} en {FechaOcurrencia}.");

        }
    }

}
