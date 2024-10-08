
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class ServicioExamenCreado : IDomainEvent
    {
        public long SolicitudExamenId { get; private set; }
        public string NumeroServicio { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ServicioExamenCreado";

        public ServicioExamenCreado(long solicitudExamenId, string numeroServicio)
        {
            SolicitudExamenId = solicitudExamenId;
            NumeroServicio = numeroServicio;
            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Solicitud Examen Con Número {NumeroServicio} ha sido asociado al Registro en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }
}
