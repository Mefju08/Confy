using Confy.Domain.Exceptions;

namespace Confy.Application.Auth.Exceptions
{
    internal sealed class UserAlreadyExistsException : ConfyException
    {
        public UserAlreadyExistsException(string email) : base($"User assosiated with email: {email} " +
            "already exists")
        {
        }
    }
}
