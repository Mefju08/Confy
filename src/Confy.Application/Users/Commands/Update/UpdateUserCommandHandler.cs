using Confy.Application.ContextAccessor;
using Confy.Application.Users.Exceptions;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Users.Commands.Update
{
    internal sealed class UpdateUserCommandHandler(
        IUserRepository userRepository,
        IUserContext userContext) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.Get();

            var user = await userRepository.GetAsync(currentUser.Id);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            user.SetFullName(request.FullName);
            await userRepository.UpdateAsync(user);
        }
    }
}
