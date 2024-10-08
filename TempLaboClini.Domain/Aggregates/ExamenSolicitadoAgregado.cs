using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Aggregates
{

    public class ExamenSolicitadoAgregado : IDomainEvent
    {
        public SolicitudExamen Solicitud { get; }
        public long ExamenId { get; }
        public DateTime OccurredOn { get; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ExamenSolicitadoAgregado";

        public ExamenSolicitadoAgregado(SolicitudExamen solicitud, long examenId)
        {
            Solicitud = solicitud;
            ExamenId = examenId;

            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se realiza Agregar Examen item en la ExamenId{ExamenId} en {FechaOcurrencia}.");

        }
    }
}