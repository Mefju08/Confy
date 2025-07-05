using Confy.Domain.Exceptions;

namespace Confy.Application.Reservations.Exceptions
{
    internal sealed class ReservationNotFoundException : ConfyException
    {
        public ReservationNotFoundException() : base("Reservation not found")
        {
        }
    }

    internal sealed class ForbiddenReservationAccessException : ConfyException
    {
        public ForbiddenReservationAccessException() : base("Forbidden restauration cancelation")
        {
        }
    }
}
