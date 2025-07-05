using FluentValidation;

namespace Confy.Application.Rooms.Queries.Get
{
    public sealed class GetRoomQueryValidator : AbstractValidator<GetRoomQuery>
    {
        public GetRoomQueryValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty();
        }
    }
}
