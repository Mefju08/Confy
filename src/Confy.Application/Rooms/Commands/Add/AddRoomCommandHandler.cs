using Confy.Application.ContextAccessor;
using Confy.Application.Rooms.Exceptions;
using Confy.Application.Rooms.Policies;
using Confy.Domain.Abstractions;
using Confy.Domain.Repositories;
using Confy.Domain.Rooms;
using Confy.Domain.Rooms.ValueObjects;
using MediatR;

namespace Confy.Application.Rooms.Commands.Add
{
    internal sealed class AddRoomCommandHandler(
        IRoomRepository roomRepository,
        IAddRoomPolicy addRoomPolicy,
        IUserContext userContext,
        IUnitOfWork unitOfWork) : IRequestHandler<AddRoomCommand>
    {
        public async Task Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.Get();
            if (!addRoomPolicy.CanBeApplied(currentUser.Role))
                throw new CanNotAddRoomException();

            var roomName = RoomName.Create(request.Name);

            if (!await addRoomPolicy.CanAdd(roomName))
                throw new CanNotAddRoomException();

            var roomCapacity = RoomCapacity.Create(request.Capacity);
            var roomLocation = RoomLocation.Create(request.Location);
            var roomDescription = RoomDescription.Create(request.Description);

            var room = Room.Create(
            roomName,
            roomCapacity,
            roomLocation,
            roomDescription);

            await roomRepository.AddAsync(room);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
