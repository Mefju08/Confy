using FluentValidation;

namespace Confy.Application.Rooms.Queries.GetAll
{
    public sealed class GetAllRoomsQueryValidator : AbstractValidator<GetAllRoomsQuery>
    {
        public GetAllRoomsQueryValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .GreaterThan(1);

            RuleFor(x => x.PageSize)
                .NotEmpty()
                .LessThan(50);
        }
    }
}
