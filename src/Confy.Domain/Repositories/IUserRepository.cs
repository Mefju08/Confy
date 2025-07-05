using Confy.Abstractions.Types;
using Confy.Domain.Users;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(AggregateId id);
        Task<User> GetByEmailAsync(Email email);
        Task<bool> ExistsByEmailAsync(Email email);
        Task RemoveAsync(User user);
        Task UpdateAsync(User user);
    }
}