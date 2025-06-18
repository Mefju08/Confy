using Confy.Application.Users.Exceptions;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Auth.Commands.Confirm
{
    internal sealed class ConfirmAccountCommandHandler(
        IUserRepository userRepository) : IRequestHandler<ConfirmAccountCommand>
    {
        public async Task Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(request.UserId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            user.Confirm(request.ConfirmationKey);
            await userRepository.UpdateAsync(user);
        }
    }
}
