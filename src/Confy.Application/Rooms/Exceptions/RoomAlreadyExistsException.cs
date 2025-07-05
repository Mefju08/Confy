using Confy.Domain.Exceptions;

namespace Confy.Application.Rooms.Exceptions
{
    internal sealed class RoomAlreadyExistsException : ConfyException
    {
        public RoomAlreadyExistsException(string name) : base($"Room with name: {name} already exists")
        {
        }
    }
}
