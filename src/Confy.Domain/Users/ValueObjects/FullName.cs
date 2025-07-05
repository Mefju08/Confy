using Confy.Domain.Users.Exceptions;

namespace Confy.Domain.Users.ValueObjects
{
    public sealed record FullName
    {
        public string Value { get; }
        private FullName(string value) => Value = value;

        public static FullName Create(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new InvalidFullNameException(fullName);

            if (!fullName.Contains(" "))
                throw new InvalidFullNameException(fullName);

            return new FullName(fullName);
        }

        public static implicit operator string(FullName value) => value.Value;
    }
}
