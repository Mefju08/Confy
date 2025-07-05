using Confy.Domain.Exceptions;

namespace Confy.Application.Users.Exceptions
{
    public sealed class UserNotFoundException : ConfyException
    {
        public UserNotFoundException() : base("User not found")
        {
        }
    }
}
