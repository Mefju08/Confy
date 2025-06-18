using Confy.Application.ContextAccessor;
using Confy.Application.Rooms.Exceptions;
using Confy.Domain.Clock;
using Confy.Domain.Repositories;
using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;
using MediatR;

namespace Confy.Application.Rooms.Commands.Reserve
{
    internal sealed class ReserveRoomCommandHandler(
        IRoomRepository roomRepository,
        IUserContext userContext,
        IClock clock) : IRequestHandler<ReserveRoomCommand>
    {
        public async Task Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await roomRepository.GetAsync(request.RoomId);
            if (room is null)
            {
                throw new RoomNotFoundException(request.RoomId);
            }

            var currentUser = userContext.Get();

            var reservation = new Reservation(
                request.RoomId,
                currentUser.Id,
                request.StartDate,
                request.EndDate,
                ReservationStatus.Active);

            room.AddReservation(reservation, clock.Now());

            await roomRepository.UpdateAsync(room);
        }
    }
}
