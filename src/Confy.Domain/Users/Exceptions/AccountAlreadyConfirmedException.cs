using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    internal sealed class AccountAlreadyConfirmedException : ConfyException
    {
        public AccountAlreadyConfirmedException() : base("Account is already confirmed")
        {
        }
    }
}
