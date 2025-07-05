using Confy.Application.ContextAccessor;
using Confy.Application.Users.Exceptions;
using Confy.Domain.Abstractions;
using Confy.Domain.Repositories;
using Confy.Domain.Users.ValueObjects;
using MediatR;

namespace Confy.Application.Users.Commands.Update
{
    internal sealed class UpdateUserCommandHandler(
        IUserRepository userRepository,
        IUserContext userContext,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.Get();

            var user = await userRepository.GetAsync(currentUser.Id)
                ?? throw new UserNotFoundException();

            var fullName = FullName.Create(request.FullName);
            user.ChangeFullName(fullName);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
