using Confy.Abstractions.Types;
using Confy.Application.Users.Exceptions;
using Confy.Domain.Abstractions;
using Confy.Domain.Repositories;
using Confy.Domain.Users.ValueObjects;
using MediatR;

namespace Confy.Application.Auth.Commands.Confirm
{
    internal sealed class ConfirmAccountCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<ConfirmAccountCommand>
    {
        public async Task Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
        {
            var userId = AggregateId.Create(request.UserId);
            var token = ConfirmationToken.Create(request.ConfirmationKey);

            var user = await userRepository.GetAsync(userId)
               ?? throw new UserNotFoundException();

            user.Confirm(token);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
