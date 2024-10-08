using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class ExamenAsignadoAlArea : IDomainEvent
    {
        public long ExamenId { get; private set; }
        public long AreaId { get; private set; }
        public DateTime FechaAsignacion { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ExamenAsignadoAlArea";

        public ExamenAsignadoAlArea(long examenId, long areaId, DateTime fechaAsignacion)
        {
            ExamenId = examenId;
            AreaId = areaId;
            FechaAsignacion = fechaAsignacion;

            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se realiza Asignacion del ExamenId{ExamenId} en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
