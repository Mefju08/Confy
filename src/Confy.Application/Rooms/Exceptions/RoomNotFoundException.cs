using Confy.Domain.Exceptions;

namespace Confy.Application.Rooms.Exceptions
{
    public sealed class RoomNotFoundException : ConfyException
    {
        public RoomNotFoundException(int roomId) : base($"Room with id: {roomId} not found")
        {
        }
    }
}
