using MediatR;

namespace Confy.Application.Rooms.Commands.Reserve
{
    public sealed record ReserveRoomCommand(
        int RoomId,
        DateTime StartDate,
        DateTime EndDate) : IRequest;
}
