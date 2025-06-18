using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    public sealed class RoomAlreadyReservedException : ConfyException
    {
        public RoomAlreadyReservedException() : base("Room is already reserved")
        {
        }
    }
}
