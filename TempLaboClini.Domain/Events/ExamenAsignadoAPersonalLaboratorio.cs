using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class ExamenAsignadoAPersonalLaboratorio : IDomainEvent
    {
        public long ExamenSolicitadoId { get; private set; }
        public long PersonalLaboratorioId { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "ExamenAsignadoAPersonalLaboratorio";

        public ExamenAsignadoAPersonalLaboratorio(long examenSolicitadoId, long personalLaboratorioId)
        {
            ExamenSolicitadoId = examenSolicitadoId;
            PersonalLaboratorioId = personalLaboratorioId;

            FechaOcurrencia = DateTime.Now;
            EventId = Guid.NewGuid();
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se realiza Asignacion Examen al PersonalLaboratorioId {PersonalLaboratorioId} en {FechaOcurrencia}.");

            // Aquí podrías agregar más lógica según sea necesario, como enviar notificaciones, etc.

        }
    }

}
