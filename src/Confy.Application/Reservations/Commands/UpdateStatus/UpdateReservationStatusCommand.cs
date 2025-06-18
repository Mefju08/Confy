using Confy.Domain.Reservations.ValueObjects;
using MediatR;

namespace Confy.Application.Reservations.Commands.UpdateStatus
{
    public sealed record UpdateReservationStatusCommand(
        int ReservationId,
        ReservationStatus Status) : IRequest;
}
