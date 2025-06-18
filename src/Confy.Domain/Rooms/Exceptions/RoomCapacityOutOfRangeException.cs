using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    internal sealed class RoomCapacityOutOfRangeException : ConfyException
    {
        public RoomCapacityOutOfRangeException() : base("Capacity has to by greater than 0")
        {
        }
    }
}
