using Confy.Application.Auth.Exceptions;
using Confy.Application.Security;
using Confy.Domain.Abstractions;
using Confy.Domain.Repositories;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;
using MediatR;

namespace Confy.Application.Auth.Commands.Register
{
    internal sealed class RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IUnitOfWork unitOfWork) : IRequestHandler<RegisterCommand>
    {
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.Email);

            if (await userRepository.ExistsByEmailAsync(email))
                throw new UserAlreadyExistsException(request.Email);

            var fullName = FullName.Create(request.FullName);
            var password = Password.Create(passwordManager.Hash(request.Password));

            var user = User.Create(email, fullName, password);

            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
