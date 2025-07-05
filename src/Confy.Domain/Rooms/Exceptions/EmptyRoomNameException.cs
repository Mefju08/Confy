using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    internal sealed class EmptyRoomNameException : ConfyException
    {
        public EmptyRoomNameException() : base("Room name can not be empty")
        {
        }
    }
}
