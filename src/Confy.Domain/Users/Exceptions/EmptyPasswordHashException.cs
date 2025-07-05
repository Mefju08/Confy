using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    internal sealed class EmptyPasswordHashException : ConfyException
    {
        public EmptyPasswordHashException() : base("Password hash can not be empty")
        {
        }
    }
}
