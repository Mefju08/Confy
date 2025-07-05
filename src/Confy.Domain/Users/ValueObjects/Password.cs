using Confy.Domain.Users.Exceptions;

namespace Confy.Domain.Users.ValueObjects
{
    public sealed record Password
    {
        public string Value { get; }

        private Password(string value)
        {
            Value = value;
        }

        public static Password Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new EmptyPasswordHashException();

            return new Password(password);
        }

        public static implicit operator string(Password password) => password.Value;
    }
}
