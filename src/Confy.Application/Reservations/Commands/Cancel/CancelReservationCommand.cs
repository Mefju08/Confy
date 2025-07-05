using MediatR;

namespace Confy.Application.Reservations.Commands.UpdateStatus
{
    public sealed record CancelReservationCommand(
        Guid ReservationId) : IRequest;
}
