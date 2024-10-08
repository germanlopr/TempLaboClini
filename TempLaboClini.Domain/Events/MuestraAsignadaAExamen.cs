using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class MuestraAsignadaAExamen : IDomainEvent
    {
        public long ExamenId { get; private set; }
        public long MuestraId { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "MuestraAsignadaAExamen";

        public MuestraAsignadaAExamen(long examenId, long muestraId)
        {
            ExamenId = examenId;
            MuestraId = muestraId;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"Muestra asignada MuestraId {MuestraId} ha sido asociado a la solicitud de examen con ID {ExamenId} en {FechaOcurrencia}.");
        }
    }

}
