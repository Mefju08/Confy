using Confy.Application.Security;
using Confy.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Confy.Infrastructure.Security
{
    internal sealed class PasswordManager(
        IPasswordHasher<User> passwordHasher) : IPasswordManager
    {
        public string Hash(string password)
            => passwordHasher.HashPassword(null, password);

        public bool Verify(string password, string hash)
            => passwordHasher.VerifyHashedPassword(null, hash, password) is
             PasswordVerificationResult.Success;
    }
}
