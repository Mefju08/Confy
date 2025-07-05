using Confy.Domain.Exceptions;

namespace Confy.Application.Auth.Exceptions
{
    internal sealed class InvalidCredentialsException : ConfyException
    {
        public InvalidCredentialsException() : base("Invalid email or password")
        {
        }
    }
}
