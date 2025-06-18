using FluentValidation;

namespace Confy.Application.Auth.Commands.Confirm
{
    public class ConfirmAccountCommandValdiator : AbstractValidator<ConfirmAccountCommand>
    {
        public ConfirmAccountCommandValdiator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ConfirmationKey)
                .NotEmpty();
        }
    }
}
