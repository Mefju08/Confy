using Confy.Domain.Reservations;
using Confy.Domain.Users.Exceptions;
using Confy.Domain.Users.ValueObjects;

namespace Confy.Domain.Users
{
    public sealed class User
    {
        public int Id { get; private set; }
        public Email Email { get; private set; }
        public FullName FullName { get; private set; }
        public string PasswordHash { get; private set; }
        public Role Role { get; private set; }
        public bool IsConfirmed { get; private set; }
        public string ConfirmationKey { get; private set; }
        public List<Reservation> Reservations { get; private set; }

        public User(Email email, FullName fullName, string passwordHash, Role role,
            bool isConfirmed, string confirmationKey)
        {
            Email = email;
            FullName = fullName;
            PasswordHash = passwordHash;
            Role = role;
            IsConfirmed = isConfirmed;
            ConfirmationKey = confirmationKey;
        }

        public void SetFullName(FullName fullName) => FullName = fullName;
        public void Confirm(string confirmationKey)
        {
            if (IsConfirmed)
            {
                throw new AccountAlreadyConfirmedException();
            }

            if (ConfirmationKey != confirmationKey)
            {
                throw new InvalidConfirmationKeyException();
            }

            IsConfirmed = true;
            ConfirmationKey = null;
        }


    }
}
