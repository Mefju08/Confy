using Confy.Application.Dtos;
using Confy.Application.Rooms.Dtos;
using Confy.Application.Rooms.Queries.GetAll;
using Confy.Infrastructure.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Confy.Infrastructure.Handlers
{
    internal sealed class GetAllRoomsQueryHandler(
        ConfyDbContext db) :
        IRequestHandler<GetAllRoomsQuery, PaginationDto<RoomDto>>
    {
        public async Task<PaginationDto<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await db.Rooms.CountAsync(cancellationToken);

            var roomDtos = await db.Rooms
                 .OrderBy(r => r.Name)
                 .Skip(request.PageSize * (request.Page - 1))
                 .Take(request.PageSize)
                 .Select(room => new RoomDto(
                     room.Id,
                     room.Name,
                     room.Location,
                     room.Description,
                     room.Capacity
                 ))
                 .ToListAsync(cancellationToken);

            return new PaginationDto<RoomDto>(
                 roomDtos,
                 totalCount,
                 request.PageSize,
                 request.Page);

        }
    }
}
