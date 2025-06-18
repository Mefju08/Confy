namespace Confy.Application.Dtos
{
    public sealed record PaginationDto<T>(
        T Values,
        int CurrentPage,
        int PageSize);
}
