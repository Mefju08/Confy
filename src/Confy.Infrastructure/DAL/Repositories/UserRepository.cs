using Confy.Domain.Repositories;
using Confy.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Repositories
{
    internal sealed class UserRepository(
        ConfyDbContext db) : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public Task<User> GetAsync(int id)
            => db.Users.Where(x => x.Id == id)
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync();
        public Task<User> GetAsync(string email)
            => db.Users.Where(x => x.Email == email)
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync();

        public Task UpdateAsync(User user)
        {
            db.Users.Update(user);
            return Task.FromResult(db.SaveChangesAsync());
        }

        public Task RemoveAsync(User user)
        {
            db.Users.Remove(user);
            return Task.FromResult(db.SaveChangesAsync());
        }
    }
}
