using Confy.Domain.Users;

namespace Confy.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string email);
        Task RemoveAsync(User user);
        Task UpdateAsync(User user);
    }
}