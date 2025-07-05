using Confy.Abstractions.Types;
using Confy.Domain.Repositories;
using Confy.Domain.Rooms;
using Confy.Domain.Rooms.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Repositories
{
    internal sealed class RoomRepository(
        ConfyDbContext db) : IRoomRepository
    {
        public Task<Room> GetAsync(AggregateId id)
            => db.Rooms.SingleOrDefaultAsync(x => x.Id == id);

        public Task<bool> ExistsByNameAsync(RoomName name)
            => db.Rooms.AnyAsync(x => x.Name == name);

        public Task<int> GetCountAsync()
            => db.Rooms.CountAsync();

        public async Task AddAsync(Room room)
        {
            _ = db.Rooms.AddAsync(room);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Room room)
        {
            db.Rooms.Update(room);
            await Task.CompletedTask;
        }

    }
}
