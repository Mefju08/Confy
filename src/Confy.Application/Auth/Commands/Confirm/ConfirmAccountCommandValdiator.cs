using FluentValidation;

namespace Confy.Application.Auth.Commands.Confirm
{
    public class ConfirmAccountCommandValdiator : AbstractValidator<ConfirmAccountCommand>
    {
        public ConfirmAccountCommandValdiator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.ConfirmationKey)
                .NotEmpty();
        }
    }
}
