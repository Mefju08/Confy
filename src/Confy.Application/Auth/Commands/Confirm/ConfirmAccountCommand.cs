using MediatR;

namespace Confy.Application.Auth.Commands.Confirm
{
    public sealed record ConfirmAccountCommand(
        Guid UserId,
        string ConfirmationKey) : IRequest;
}
