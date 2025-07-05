using Confy.Application.Dtos;
using Confy.Application.Rooms.Dtos;
using MediatR;

namespace Confy.Application.Rooms.Queries.GetAll
{
    public sealed record GetAllRoomsQuery(
        int Page,
        int PageSize) : IRequest<PaginationDto<RoomDto>>;
}
