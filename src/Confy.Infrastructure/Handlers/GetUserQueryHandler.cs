using Confy.Application.ContextAccessor;
using Confy.Application.Users.Dtos;
using Confy.Application.Users.Exceptions;
using Confy.Application.Users.Queries.Get;
using Confy.Infrastructure.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.Handlers
{
    internal sealed class GetUserQueryHandler(
        ConfyDbContext db,
        IUserContext userContext) : IRequestHandler<GetUserQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.Get();
            var userDto = await db.Users
                .Where(u => u.Id == currentUser.Id)
                .Select(user => new UserDto(
                    user.Id.Value,
                    user.Email.Value,
                    user.FullName.Value
                ))
                .FirstOrDefaultAsync(cancellationToken);

            if (userDto is null)
                throw new UserNotFoundException();

            return userDto;
        }
    }
}
