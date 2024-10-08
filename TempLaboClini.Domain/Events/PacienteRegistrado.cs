using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class PacienteRegistrado : IDomainEvent
    {
        public long PacienteId { get; private set; }
        public DateTime FechaRegistro { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "PacienteRegistrado";

        public PacienteRegistrado(long pacienteId, DateTime fechaRegistro)
        {
            PacienteId = pacienteId;
            FechaRegistro = fechaRegistro;
            FechaOcurrencia = DateTime.UtcNow; // Establece la fecha y hora del evento
            EventId = Guid.NewGuid();
        }

        public void HandleEvent()
        {
           // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Paciente con ID {PacienteId} ha sido asociado al Registro en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.
        }
    }

}
