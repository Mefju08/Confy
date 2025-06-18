using Confy.Domain.Users;

namespace Confy.Application.Auth
{
    public interface IJwtTokenGenerator
    {
        string Generate(User user);
    }
}