using Confy.Application.Auth.Dtos;
using Confy.Application.Auth.Exceptions;
using Confy.Application.Security;
using Confy.Domain.Repositories;
using Confy.Domain.Users.ValueObjects;
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
            var email = Email.Create(request.Email);
            var user = await userRepository.GetByEmailAsync(email)
                ?? throw new InvalidCredentialsException();

            if (!user.IsConfirmed)
                throw new AccountNotConfirmedException();

            bool isPasswordValid = passwordManager.Verify(request.Password, user.Password);
            if (!isPasswordValid)
                throw new InvalidCredentialsException();

            string token = tokenGenerator.Generate(user.Id, user.Email, user.Role.ToString());

            return new LoginResponseDto(
               user.Email,
               user.FullName,
               token);
        }
    }
}
