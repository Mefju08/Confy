using Confy.Domain.Repositories;
using Confy.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Repositories
{
    internal sealed class RoomRepository(
        ConfyDbContext db) : IRoomRepository
    {
        public Task<Room> GetAsync(int id)
            => db.Rooms.Where(x => x.Id == id)
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync();

        public Task<List<Room>> GetAllAsync()
            => db.Rooms.ToListAsync();

        public async Task<int> AddAsync(Room room)
        {
            await db.Rooms.AddAsync(room);
            await db.SaveChangesAsync();

            return room.Id;
        }

        public async Task UpdateAsync(Room room)
        {
            db.Rooms.Update(room);
            await db.SaveChangesAsync();
        }

    }
}
