using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    internal sealed class TooShortRoomNameException : ConfyException
    {
        public TooShortRoomNameException(string name) : base($"Room name: {name} is too short")
        {
        }
    }
}
