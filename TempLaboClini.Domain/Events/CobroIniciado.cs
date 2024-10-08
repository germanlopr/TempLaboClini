using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class CobroIniciado : IDomainEvent
    {
        public long FacturaId { get; private set; }
        public decimal MontoTotal { get; private set; }
        public DateTime FechaCobro { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "CobroIniciado";

        public CobroIniciado(long facturaId, decimal montoTotal, DateTime fechaCobro)
        {
            FacturaId = facturaId;
            MontoTotal = montoTotal;
            FechaCobro = fechaCobro;

            FechaOcurrencia = DateTime.Now; 
            EventId = Guid.NewGuid();   
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se realiza el cobro{FacturaId} en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
