using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class CoberturaAseguradoraConfirmada : IDomainEvent
    {
        public long AseguradoraId { get; private set; }
        public long SolicitudExamenId { get; private set; }
        public DateTime FechaConfirmacion { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "CoberturaAseguradoraConfirmada";

        public CoberturaAseguradoraConfirmada(long aseguradoraId, long solicitudExamenId, DateTime fechaConfirmacion)
        {
            AseguradoraId = aseguradoraId;
            SolicitudExamenId = solicitudExamenId;
            FechaConfirmacion = fechaConfirmacion;
            FechaOcurrencia = DateTime.Now;
            EventId = new Guid();
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se realiza la{SolicitudExamenId} en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.
        }
    }

}
