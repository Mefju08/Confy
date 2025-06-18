using Confy.Application.Auth.Exceptions;
using Confy.Application.Notifications;
using Confy.Application.Security;
using Confy.Domain.Repositories;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;
using MediatR;

namespace Confy.Application.Auth.Commands.Register
{
    internal sealed class RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IKeyGenerator keyGenerator,
        IEmailSenderService emailSender) : IRequestHandler<RegisterCommand>
    {
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            bool isUserAlreadyExsits = await IsUserAlreadyExsists(request.Email);
            if (isUserAlreadyExsits)
            {
                throw new UserAlreadyExistsException(request.Email);
            }

            string hashedPassword = passwordManager.Hash(request.Password);
            string confirmationKey = keyGenerator.Generate();
            var user = new User(
                request.Email,
                request.FullName,
                hashedPassword,
                Role.User,
                false,
                confirmationKey);

            await userRepository.AddAsync(user);
            await emailSender.SendConfirmation(request.Email);
        }

        private async Task<bool> IsUserAlreadyExsists(string email)
        {
            var user = await userRepository.GetAsync(email);
            return user is not null;
        }
    }
}
