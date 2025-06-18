using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    public sealed class InvalidEmailException : ConfyException
    {
        public InvalidEmailException(string email) : base($"Email: {email} is invalid")
        {
        }
    }
}
