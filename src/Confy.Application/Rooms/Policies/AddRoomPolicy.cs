using Confy.Domain.Repositories;
using Confy.Domain.Rooms.ValueObjects;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Application.Rooms.Policies
{
    internal sealed class AddRoomPolicy(
        IRoomRepository roomRepository) : IAddRoomPolicy
    {
        private const int _roomsLimit = 5;

        public bool CanBeApplied(Role role)
            => role is Role.Admin;
        public async Task<bool> CanAdd(RoomName roomName)
        {
            if (await roomRepository.GetCountAsync() >= _roomsLimit)
                return false;

            if (await roomRepository.ExistsByNameAsync(roomName))
                return false;

            return true;
        }
    }
}
