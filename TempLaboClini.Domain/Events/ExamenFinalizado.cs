using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class ExamenFinalizado : IDomainEvent
    {
        public long ExamenSolicitadoId { get; private set; }
        public DateTime FechaFinalizacion { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ExamenFinalizado";

        public ExamenFinalizado(long examenSolicitadoId, DateTime fechaFinalizacion)
        {
            ExamenSolicitadoId = examenSolicitadoId;
            FechaFinalizacion = fechaFinalizacion;

            FechaOcurrencia = DateTime.Now;
            EventId = Guid.NewGuid();
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se realiza Finalizació Exame ExamenSolicitadoId{ExamenSolicitadoId} en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
