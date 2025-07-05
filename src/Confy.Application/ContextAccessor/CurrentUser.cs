using Confy.Abstractions.Types;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Application.ContextAccessor
{
    public sealed record CurrentUser(
        string Email,
        Role Role,
        AggregateId Id);
}
