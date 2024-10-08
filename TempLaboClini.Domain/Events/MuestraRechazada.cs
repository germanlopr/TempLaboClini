using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class MuestraRechazada : IDomainEvent
    {
        public long MuestraId { get; private set; }
        public string MotivoRechazo { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "MuestraRechazada";

        public MuestraRechazada(long muestraId, string motivoRechazo)
        {
            MuestraId = muestraId;
            MotivoRechazo = motivoRechazo;

            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;

        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"El Muestra Rechazada con ID {MuestraId} en {FechaOcurrencia}.");
        }
    }

}
