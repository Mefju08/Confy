using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    internal sealed class EmptyConfirmationTokenException : ConfyException
    {
        public EmptyConfirmationTokenException() : base("Confirmation token can not be empty")
        {
        }
    }
}
