using FluentValidation;

namespace Confy.Application.Rooms.Commands.Reserve
{
    public sealed class ReserveRoomCommandValdiator
         : AbstractValidator<ReserveRoomCommand>
    {
        public ReserveRoomCommandValdiator()
        {
            RuleFor(x => x.EndDate)
                .NotEmpty();

            RuleFor(x => x.StartDate)
                .NotEmpty();
        }
    }
}
