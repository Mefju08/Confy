using Confy.Application.Auth.Dtos;
using Confy.Application.Auth.Exceptions;
using Confy.Application.Security;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Auth.Commands.Login
{
    internal sealed class LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IJwtTokenGenerator tokenGenerator) : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(request.Email);
            if (user is null)
            {
                throw new InvalidCredentialsException();
            }

            if (!user.IsConfirmed)
            {
                throw new AccountNotConfirmedException();
            }

            bool isPasswordValid = passwordManager.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new InvalidCredentialsException();
            }

            string token = tokenGenerator.Generate(user);
            return new LoginResponseDto(
                user.Email,
                user.FullName,
                token);
        }
    }
}
