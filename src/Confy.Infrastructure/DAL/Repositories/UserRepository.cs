using Confy.Abstractions.Types;
using Confy.Domain.Repositories;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.DAL.Repositories
{
    internal sealed class UserRepository(
        ConfyDbContext db) : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            _ = db.Users.AddAsync(user);
            await Task.CompletedTask;
        }
        public Task<User> GetAsync(AggregateId id)
            => db.Users.SingleOrDefaultAsync(x => x.Id == id);

        public Task<User> GetByEmailAsync(string email)
            => db.Users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task UpdateAsync(User user)
        {
            db.Users.Update(user);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(User user)
        {
            db.Users.Remove(user);
            await Task.CompletedTask;
        }

        public Task<User> GetByEmailAsync(Email email)
            => db.Users.SingleOrDefaultAsync(x => x.Email == email);
        
        public Task<bool> ExistsByEmailAsync(Email email)
            => db.Users.AnyAsync(x => x.Email == email);
    }
}
