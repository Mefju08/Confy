using Confy.Abstractions.Types;
using Confy.Application.ContextAccessor;
using Confy.Application.Reservations.Exceptions;
using Confy.Domain.Abstractions;
using Confy.Domain.Clock;
using Confy.Domain.Repositories;
using MediatR;

namespace Confy.Application.Reservations.Commands.UpdateStatus
{
    internal sealed class CancelReservationCommandHandler(
        IReservationRepository reservationRepository,
        IClock clock,
        IUnitOfWork unitOfWork,
        IUserContext userContext) : IRequestHandler<CancelReservationCommand>
    {
        public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationId = AggregateId.Create(request.ReservationId);
            var reservation = await reservationRepository.GetAsync(reservationId)
                ?? throw new ReservationNotFoundException();

            var userId = userContext.Get().Id;
            if (!reservation.UserId.Equals(userId))
                throw new ForbiddenReservationAccessException();

            reservation.Cancel(clock.Now());

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
