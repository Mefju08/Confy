using MediatR;

namespace Confy.Application.Auth.Commands.Register
{
    public sealed record RegisterCommand(
        string Email,
        string FullName,
        string Password) : IRequest;
}