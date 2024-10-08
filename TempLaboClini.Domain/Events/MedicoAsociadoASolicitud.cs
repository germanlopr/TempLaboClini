

using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class MedicoAsociadoASolicitud : IDomainEvent
    {
        public long SolicitudExamenId { get; private set; }
        public long MedicoId { get; private set; }

        // Propiedad de la interfaz IDomainEvent
        public DateTime FechaOcurrencia { get; private set; }

        // Propiedad de la interfaz IDomainEvent
        public string EventType => "MedicoAsociadoASolicitud";

        public Guid EventId { get; private set; }

        // Constructor
        public MedicoAsociadoASolicitud(long solicitudExamenId, long medicoId)
        {
            SolicitudExamenId = solicitudExamenId;
            MedicoId = medicoId;
            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.UtcNow; // Establece la fecha y hora del evento
        }

        // Implementación del método de la interfaz IDomainEvent
        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El médico con ID {MedicoId} ha sido asociado a la solicitud de examen con ID {SolicitudExamenId} en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.
        }
    }
}
