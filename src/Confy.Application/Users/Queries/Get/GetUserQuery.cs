using Confy.Application.Users.Dtos;
using MediatR;

namespace Confy.Application.Users.Queries.Get
{
    public sealed record GetUserQuery() : IRequest<UserDto>;

}
