using Confy.Application.Auth.Dtos;
using MediatR;

namespace Confy.Application.Auth.Commands.Login
{
    public sealed record LoginCommand(
        string Email,
        string Password) : IRequest<LoginResponseDto>;
}
