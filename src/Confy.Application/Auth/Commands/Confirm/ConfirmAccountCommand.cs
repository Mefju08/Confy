using MediatR;

namespace Confy.Application.Auth.Commands.Confirm
{
    public sealed record ConfirmAccountCommand(
        int UserId,
        string ConfirmationKey) : IRequest;
}
