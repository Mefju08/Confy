using Confy.Abstractions.Types;
using Confy.Domain.Users.Events;
using Confy.Domain.Users.Exceptions;
using Confy.Domain.Users.ValueObjects;
namespace Confy.Domain.Users
{
    public sealed class User : AggregateRoot
    {
        public Email Email { get; private set; }
        public FullName FullName { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }
        public bool IsConfirmed { get; private set; }
        public ConfirmationToken ConfirmationToken { get; private set; }

        private User() { }
        private User(AggregateId id, Email email, FullName fullName, Password password, Role role,
            bool isConfirmed, ConfirmationToken confirmationToken)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            Password = password;
            Role = role;
            IsConfirmed = isConfirmed;
            ConfirmationToken = confirmationToken;

            AddDomainEvent(new UserCreated(Id, Email));
        }
        public static User Create(Email email, FullName fullName, Password password)
        {
            var confirmationToken = ConfirmationToken.Generate();
            var user = new User(
                AggregateId.Create(),
                email,
                fullName,
                password,
                Role.User,
                isConfirmed: false,
                confirmationToken
            );

            return user;
        }

        public void ChangeFullName(FullName fullName)
        {
            if (FullName.Equals(fullName))
                return;

            FullName = fullName;
        }
        public void Confirm(string confirmationToken)
        {
            if (IsConfirmed)
                throw new AccountAlreadyConfirmedException();

            if (ConfirmationToken is null || ConfirmationToken != confirmationToken)
                throw new InvalidConfirmationKeyException();

            IsConfirmed = true;
            ConfirmationToken = null;
        }
        public void PromoteToAdmin()
        {
            if (Role == Role.Admin)
                throw new UserIsAlreadyAdminException(Id);

            Role = Role.Admin;
        }
    }
}
