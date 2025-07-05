using Confy.Abstractions.Types;
using Confy.Domain.Rooms;
using Confy.Domain.Rooms.ValueObjects;

namespace Confy.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<Room> GetAsync(AggregateId id);
        Task<bool> ExistsByNameAsync(RoomName name);
        Task<int> GetCountAsync();
        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
    }
}