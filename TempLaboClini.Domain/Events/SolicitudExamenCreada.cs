using TempLaboClini.Domain.Aggregates;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class SolicitudExamenCreada : IDomainEvent
    {
        public long SolicitudExamenId { get; private set; }
        public long PacienteId { get; private set; }
        public DateTime FechaSolicitud { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "SolicitudExamenCreada";

        public SolicitudExamen SolicitudExamen { get; }

        public SolicitudExamenCreada(long solicitudExamenId, long pacienteId, DateTime fechaSolicitud)
        {
            SolicitudExamenId = solicitudExamenId;
            PacienteId = pacienteId;
            FechaSolicitud = fechaSolicitud;

            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public SolicitudExamenCreada(SolicitudExamen solicitudExamen)
        {
            SolicitudExamen = solicitudExamen;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Solicitud Examen Creado Con PacienteId {PacienteId} ha sido asociado al Registro en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
