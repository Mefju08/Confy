namespace Confy.Application.Auth
{
    public interface IJwtTokenGenerator
    {
        string Generate(Guid userId, string email, string role);
    }
}