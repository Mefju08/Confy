using FluentValidation;

namespace Confy.Application.Rooms.Commands.Reserve
{
    public sealed class ReserveRoomCommandValdiator
         : AbstractValidator<ReserveRoomCommand>
    {
        public ReserveRoomCommandValdiator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty();

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.StartDate)
                .WithMessage("'End Date' must be after 'Start Date'.");
        }
    }
}
