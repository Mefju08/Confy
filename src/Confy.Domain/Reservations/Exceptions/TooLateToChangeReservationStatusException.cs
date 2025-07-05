using Confy.Domain.Exceptions;

namespace Confy.Domain.Reservations.Exceptions
{
    internal class TooLateToChangeReservationStatusException : ConfyException
    {
        public TooLateToChangeReservationStatusException() : base("It's too late to change reservation status")
        {
        }
    }
}
