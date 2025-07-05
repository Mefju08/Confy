using Confy.Domain.Exceptions;

namespace Confy.Application.Auth.Exceptions
{
    internal class AccountNotConfirmedException : ConfyException
    {
        public AccountNotConfirmedException() : base("Account is not confirmed")
        {
        }
    }
}
