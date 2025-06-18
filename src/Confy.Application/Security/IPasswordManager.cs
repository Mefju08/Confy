namespace Confy.Application.Security
{
    public interface IPasswordManager
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}