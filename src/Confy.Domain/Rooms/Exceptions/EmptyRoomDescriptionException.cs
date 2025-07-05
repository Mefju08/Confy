using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    internal sealed class EmptyRoomDescriptionException : ConfyException
    {
        public EmptyRoomDescriptionException() : base("Room description can not be empty")
        {
        }
    }
}
