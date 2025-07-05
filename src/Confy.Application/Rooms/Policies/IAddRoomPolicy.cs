using Confy.Domain.Rooms.ValueObjects;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Application.Rooms.Policies
{
    public interface IAddRoomPolicy
    {
        bool CanBeApplied(Role role);
        Task<bool> CanAdd(RoomName roomName);
    }
}