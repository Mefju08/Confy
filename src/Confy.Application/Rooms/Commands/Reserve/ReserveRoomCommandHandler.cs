using Confy.Abstractions.Types;
using Confy.Application.ContextAccessor;
using Confy.Application.Rooms.Exceptions;
using Confy.Domain.Abstractions;
using Confy.Domain.Clock;
using Confy.Domain.Repositories;
using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;
using Confy.Domain.Rooms.Exceptions;
using MediatR;

namespace Confy.Application.Rooms.Commands.Reserve
{
    internal sealed class ReserveRoomCommandHandler(
        IRoomRepository roomRepository,
        IUserContext userContext,
        IClock clock,
        IReservationRepository reservationRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<ReserveRoomCommand>
    {
        public async Task Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
        {
            var roomId = AggregateId.Create(request.RoomId);
            var room = await roomRepository.GetAsync(roomId)
                ?? throw new RoomNotFoundException(roomId.Value);

            var dateRange = DateRange.Create(request.StartDate, request.EndDate, clock.Now());

            var isAlreadyReserved = await reservationRepository.IsRoomAlreadyReservedAsync(room.Id, dateRange);
            if (isAlreadyReserved)
                throw new RoomAlreadyReservedException();

            var currentUser = userContext.Get();
            var reservation = Reservation.Create(room.Id, currentUser.Id, dateRange);

            await reservationRepository.AddAsync(reservation);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
