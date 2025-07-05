using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    internal sealed class EmptyRoomLocationException : ConfyException
    {
        public EmptyRoomLocationException() : base("Room location can not be empty")
        {
        }
    }
}
