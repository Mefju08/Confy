using Confy.Domain.Exceptions;

namespace Confy.Domain.Users.Exceptions
{
    internal sealed class UserIsAlreadyAdminException : ConfyException
    {
        public UserIsAlreadyAdminException(Guid userId) :
            base($"User with ID: {userId} is already admin")
        {
        }
    }
}
