namespace TempLaboClini.Domain.Interfaces
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent domainEvent);
        void ClearEvents();
    }

}
