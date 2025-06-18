using Confy.Application.ContextAccessor;
using Confy.Application.Rooms.Exceptions;
using Confy.Application.Rooms.Policies;
using Confy.Domain.Repositories;
using Confy.Domain.Rooms;
using MediatR;

namespace Confy.Application.Rooms.Commands.Add
{
    internal sealed class AddRoomCommandHandler(
        IRoomRepository roomRepository,
        IAddRoomPolicy addRoomPolicy,
        IUserContext userContext) : IRequestHandler<AddRoomCommand>
    {
        public async Task Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var rooms = await roomRepository.GetAllAsync();

            var room = new Room(
                request.Name,
                request.Capacity,
                request.Location,
                request.Description);

            var currentUser = userContext.Get();
            if (!addRoomPolicy.CanBeApplied(currentUser.Role))
            {
                throw new CanNotAddRoomException();
            }
            if (!addRoomPolicy.CanAdd(room, rooms))
            {
                throw new CanNotAddRoomException();
            }

            await roomRepository.AddAsync(room);
        }
    }
}
