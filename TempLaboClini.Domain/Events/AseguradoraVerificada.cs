using TempLaboClini.Domain.Interfaces;

namespace TempLaboClini.Domain.Events
{
    public class AseguradoraVerificada : IDomainEvent
    {
        public long AseguradoraId { get; private set; }
        public DateTime FechaVerificacion { get; private set; }

        public Guid EventId { get; private set; }

        public DateTime FechaOcurrencia { get; private set; }

        public string EventType => "AseguradoraVerificada";

        public AseguradoraVerificada(long aseguradoraId, DateTime fechaVerificacion)
        {
            AseguradoraId = aseguradoraId;
            FechaVerificacion = fechaVerificacion;
            EventId = Guid.NewGuid();
            FechaOcurrencia = DateTime.Now;
        }

        public void HandleEvent()
        {
            Console.WriteLine($"Se Verifica la Aseguradora con el Id {AseguradoraId} en {FechaOcurrencia}.");
        }
    }

}
