using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class PagoConfirmado : IDomainEvent
    {
        public long FacturaId { get; private set; }
        public DateTime FechaPago { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "PagoConfirmado";

        public PagoConfirmado(long facturaId, DateTime fechaPago)
        {
            FacturaId = facturaId;
            FechaPago = fechaPago;

            EventId = Guid.NewGuid();  
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            // Lógica para manejar el evento, como notificar a otros componentes o actualizar el estado del sistema
            Console.WriteLine($"La Factura con ID {FacturaId} ha sido asociado al Registro en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
