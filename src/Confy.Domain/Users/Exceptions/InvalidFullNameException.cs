using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    internal sealed class InvalidFullNameException : ConfyException
    {
        public InvalidFullNameException(string fullName) : base($"Full name: {fullName} is invalid")
        {
        }
    }
}
