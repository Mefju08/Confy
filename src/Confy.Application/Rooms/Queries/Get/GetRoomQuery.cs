using Confy.Application.Rooms.Dtos;
using MediatR;

namespace Confy.Application.Rooms.Queries.Get
{
    public sealed record GetRoomQuery(
        int RoomId) : IRequest<RoomDto>;
}
