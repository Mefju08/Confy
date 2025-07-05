using FluentValidation;

namespace Confy.Application.Rooms.Queries.GetAll
{
    public sealed class GetAllRoomsQueryValidator : AbstractValidator<GetAllRoomsQuery>
    {
        private readonly int[] _allowedPageSizes = { 5, 10, 20, 50 };

        public GetAllRoomsQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .Must(value => _allowedPageSizes.Contains(value))
                .WithMessage($"Page size must be one of the following: {string.Join(", ", _allowedPageSizes)}");
        }
    }
}
