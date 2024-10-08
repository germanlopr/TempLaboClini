using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class ResultadoRevisadoPorMedico : IDomainEvent
    {
        public long ResultadoId { get; private set; }
        public long MedicoId { get; private set; }
        public DateTime FechaRevision { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ResultadoRevisadoPorMedico";

        public ResultadoRevisadoPorMedico(long resultadoId, long medicoId, DateTime fechaRevision)
        {
            ResultadoId = resultadoId;
            MedicoId = medicoId;
            FechaRevision = fechaRevision;

            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Examen revisado por el medico con ID {ResultadoId} ha sido asociado al Registro en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
