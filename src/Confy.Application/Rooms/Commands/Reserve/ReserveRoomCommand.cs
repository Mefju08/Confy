using MediatR;

namespace Confy.Application.Rooms.Commands.Reserve
{
    public sealed record ReserveRoomCommand(
        Guid RoomId,
        DateTime StartDate,
        DateTime EndDate) : IRequest;
}
