using Confy.Domain.Rooms;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Application.Rooms.Policies
{
    public interface IAddRoomPolicy
    {
        bool CanBeApplied(Role role);
        bool CanAdd(Room room, IEnumerable<Room> allRooms);
    }
}