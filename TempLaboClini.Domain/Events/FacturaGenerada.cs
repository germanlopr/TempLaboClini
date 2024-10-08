using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class FacturaGenerada : IDomainEvent
    {
        public string NroFactura { get; private set; }
        public long SolicitudExamenId { get; private set; }
        public decimal Monto { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "FacturaGenerada";

        public Aggregates.SolicitudExamen SolicitudExamen { get; }

        public FacturaGenerada(string nroFactura, long solicitudExamenId, decimal monto)
        {
            NroFactura = nroFactura;
            SolicitudExamenId = solicitudExamenId;
            Monto = monto;

            FechaOcurrencia = DateTime.Now;
            EventId = Guid.NewGuid();
        }

        public FacturaGenerada(Aggregates.SolicitudExamen solicitudExamen, string nroFactura)
        {
            SolicitudExamen = solicitudExamen;
            NroFactura = nroFactura;
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se Generó Factura Número{NroFactura} en {FechaOcurrencia}.");

        }
    }

}
