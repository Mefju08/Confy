using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    public sealed class InvalidReservationDateException(string description) :
        ConfyException(description)
    {
    }
}
