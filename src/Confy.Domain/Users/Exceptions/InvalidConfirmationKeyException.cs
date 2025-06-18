using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    internal sealed class InvalidConfirmationKeyException : ConfyException
    {
        public InvalidConfirmationKeyException() : base("Confirmation key expired")
        {
        }
    }
}
