using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class ResultadoExamenRegistrado : IDomainEvent
    {
        public long ExamenSolicitadoId { get; private set; }
        public DateTime FechaResultado { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ResultadoExamenRegistrado";

        public ResultadoExamenRegistrado(long examenSolicitadoId, DateTime fechaResultado)
        {
            ExamenSolicitadoId = examenSolicitadoId;
            FechaResultado = fechaResultado;
            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Examen Solicitado con ID {ExamenSolicitadoId} ha sido asociado al Registro en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
