using Confy.Domain.Exceptions;

namespace Confy.Application.Users.Exceptions
{
    internal class UserNotFoundException : ConfyException
    {
        public UserNotFoundException() : base("User not found")
        {
        }
    }
}
