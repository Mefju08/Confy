using Confy.Domain.Users.Exceptions;

namespace Confy.Domain.Users.ValueObjects
{
    public sealed record FullName
    {
        public string Value { get; }
        public FullName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidFullNameException(value);
            }

            if (!value.Contains(" "))
            {
                throw new InvalidFullNameException(value);
            }

            Value = value;
        }

        public static implicit operator FullName(string value) => new FullName(value);
        public static implicit operator string(FullName value) => value.Value;
    }
}
