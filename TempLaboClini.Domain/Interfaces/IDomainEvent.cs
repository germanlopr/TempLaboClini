namespace TempLaboClini.Domain.Interfaces
{
    public interface IDomainEvent
    {
        Guid EventId { get; }
        DateTime FechaOcurrencia { get; }
        string EventType { get; }
        void HandleEvent();
    }
}