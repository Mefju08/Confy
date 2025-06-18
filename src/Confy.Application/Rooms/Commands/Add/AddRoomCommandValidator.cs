using FluentValidation;

namespace Confy.Application.Rooms.Commands.Add
{
    public class AddRoomCommandValidator : AbstractValidator<AddRoomCommand>
    {
        public AddRoomCommandValidator()
        {
            RuleFor(x => x.Capacity)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(50);

            RuleFor(x => x.Location)
                .NotEmpty();
        }
    }
}
