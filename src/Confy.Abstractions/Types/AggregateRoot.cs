using Confy.Abstractions.Events;

namespace Confy.Abstractions.Types
{
    public abstract class AggregateRoot<T>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public T Id { get; protected set; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }

    public abstract class AggregateRoot : AggregateRoot<AggregateId>
    {
    }
}
