using AutoMapper;
using Confy.Application.ContextAccessor;
using Confy.Application.Reservations.Dtos;
using Confy.Application.Users.Dtos;
using Confy.Application.Users.Exceptions;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Users.Queries.Get
{
    internal sealed class GetUserQueryHandler(
        IUserRepository userRepository,
        IUserContext userContext,
        IMapper mapper) : IRequestHandler<GetUserQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.Get();

            var user = await userRepository.GetAsync(currentUser.Id);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            return new UserDto(
                user.Email,
                user.FullName,
                mapper.Map<IEnumerable<ReservationDto>>(user.Reservations));
        }
    }
}
