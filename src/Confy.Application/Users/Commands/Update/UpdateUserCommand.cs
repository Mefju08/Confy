using MediatR;

namespace Confy.Application.Users.Commands.Update
{
    public sealed record UpdateUserCommand(
        string FullName) : IRequest;

}
