using Confy.Domain.Rooms;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Application.Rooms.Policies
{
    internal sealed class AddRoomPolicy : IAddRoomPolicy
    {
        private const int _roomsLimit = 5;

        public bool CanBeApplied(Role role)
            => role is Role.Admin;
        public bool CanAdd(Room room, IEnumerable<Room> allRooms)
        {
            if (allRooms.Count() >= _roomsLimit)
            {
                return false;
            }

            if (allRooms.Any(x => x.Name.ToLower() == room.Name.ToLower()))
            {
                return false;
            }

            return true;
        }
    }
}
