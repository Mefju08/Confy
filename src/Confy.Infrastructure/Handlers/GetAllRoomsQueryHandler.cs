using AutoMapper;
using Confy.Application.Dtos;
using Confy.Application.Rooms.Dtos;
using Confy.Application.Rooms.Queries.GetAll;
using Confy.Infrastructure.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.Handlers
{
    internal sealed class GetAllRoomsQueryHandler(
        ConfyDbContext db,
        IMapper mapper) :
        IRequestHandler<GetAllRoomsQuery, PaginationDto<IEnumerable<RoomDto>>>
    {
        public async Task<PaginationDto<IEnumerable<RoomDto>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await db.Rooms
                 .Skip(request.PageSize * (request.Page - 1))
                 .Take(request.PageSize)
                 .ToListAsync();

            var roomDtos = mapper.Map<IEnumerable<RoomDto>>(rooms);

            return new PaginationDto<IEnumerable<RoomDto>>(
                roomDtos,
                request.PageSize,
                request.PageSize);
        }
    }
}
