using Confy.Domain.Exceptions;

namespace Confy.Domain.Reservations.Exceptions
{
    internal sealed class ReservationIsAlreadyCanceledException(Guid reservationId)
        : ConfyException($"Reservation with ID: {reservationId} is already canceled.")
    {
    }
}
