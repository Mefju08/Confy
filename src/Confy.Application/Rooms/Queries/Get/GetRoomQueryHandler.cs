using AutoMapper;
using Confy.Application.Rooms.Dtos;
using Confy.Application.Rooms.Exceptions;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Rooms.Queries.Get
{
    internal sealed class GetRoomQueryHandler(
        IRoomRepository roomRepository,
        IMapper mapper) : IRequestHandler<GetRoomQuery, RoomDto>
    {
        public async Task<RoomDto> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await roomRepository.GetAsync(request.RoomId);
            if (room is null)
            {
                throw new RoomNotFoundException(request.RoomId);
            }

            var roomDto = mapper.Map<RoomDto>(room);

            return roomDto;
        }
    }
}
