using FluentValidation;

namespace Confy.Application.Auth.Commands.Login
{
    public sealed class LoginCommandValdiator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValdiator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
