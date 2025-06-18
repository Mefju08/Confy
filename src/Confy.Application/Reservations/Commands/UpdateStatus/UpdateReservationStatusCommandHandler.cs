using Confy.Application.Reservations.Exceptions;
using Confy.Domain.Clock;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Reservations.Commands.UpdateStatus
{
    internal sealed class UpdateReservationStatusCommandHandler(
        IReservationRepository reservationRepository,
        IClock clock) : IRequestHandler<UpdateReservationStatusCommand>
    {
        public async Task Handle(UpdateReservationStatusCommand request, CancellationToken cancellationToken)
        {
            var reservation = await reservationRepository.GetAsync(request.ReservationId);
            if (reservation is null)
            {
                throw new ReservationNotFoundException();
            }

            reservation.SetStatus(request.Status, clock.Now());
            await reservationRepository.UpdateAsync(reservation);
        }
    }
}
