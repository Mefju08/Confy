using MediatR;
namespace Confy.Abstractions.Events
{
    public interface IDomainEvent : INotification
    {
        public Guid Id { get; }
    }
}
