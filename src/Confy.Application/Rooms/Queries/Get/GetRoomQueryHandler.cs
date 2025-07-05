
using Confy.Abstractions.Types;
using Confy.Application.Rooms.Dtos;
using Confy.Application.Rooms.Exceptions;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Rooms.Queries.Get
{
    internal sealed class GetRoomQueryHandler(
        IRoomRepository roomRepository) : IRequestHandler<GetRoomQuery, RoomDto>
    {
        public async Task<RoomDto> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var roomId = AggregateId.Create(request.RoomId);

            var room = await roomRepository.GetAsync(roomId)
                ?? throw new RoomNotFoundException(roomId);

            var roomDto = RoomDto.Map(room);
            return roomDto;
        }
    }
}
