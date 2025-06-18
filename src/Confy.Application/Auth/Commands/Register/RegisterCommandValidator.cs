using FluentValidation;

namespace Confy.Application.Auth.Commands.Register
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(30)
                .Must(ContainsSpecialCharacter)
                    .WithMessage("The password must contain at least one special character.")
                .Must(ContainsDigit).
                    WithMessage("The password must contain at least one number.");
        }

        private bool ContainsSpecialCharacter(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private bool ContainsDigit(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
