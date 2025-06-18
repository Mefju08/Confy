using Confy.Domain.Exceptions;

namespace Confy.Application.Rooms.Exceptions
{
    internal sealed class CanNotAddRoomException : ConfyException
    {
        public CanNotAddRoomException() : base("Room can not be added")
        {
        }
    }
}
