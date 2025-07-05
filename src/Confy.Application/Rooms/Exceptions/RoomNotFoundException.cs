using Confy.Domain.Exceptions;

namespace Confy.Application.Rooms.Exceptions
{
    public sealed class RoomNotFoundException(Guid roomId) :
        ConfyException($"Room with id: {roomId} not found")
    {
    }
}
