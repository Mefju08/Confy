namespace Confy.Application.Dtos
{
    public sealed record PaginationDto<T>(
     IEnumerable<T> Items,
     int TotalCount,
     int PageSize,
     int CurrentPage)
    {
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
