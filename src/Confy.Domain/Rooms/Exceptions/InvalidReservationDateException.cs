using Confy.Domain.Exceptions;

namespace Confy.Domain.Rooms.Exceptions
{
    public sealed class InvalidReservationDateException : ConfyException
    {
        public InvalidReservationDateException() : base("Invalid reservation date")
        {
        }
    }
}
