using Confy.Domain.Rooms;

namespace Confy.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<int> AddAsync(Room room);
        Task<List<Room>> GetAllAsync();
        Task<Room> GetAsync(int id);
        Task UpdateAsync(Room room);
    }
}