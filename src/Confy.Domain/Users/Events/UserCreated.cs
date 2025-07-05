using Confy.Abstractions.Events;

namespace Confy.Domain.Users.Events
{
    public record UserCreated(Guid UserId, string Email) : IDomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
