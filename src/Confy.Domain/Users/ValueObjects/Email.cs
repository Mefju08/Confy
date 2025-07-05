using Confy.Domain.Users.Exceptions;
using System.Text.RegularExpressions;

namespace Confy.Domain.Users.ValueObjects
{
    public sealed record Email
    {
        private static readonly Regex Regex = new(
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled);

        public string Value { get; }
        private Email(string value) => Value = value;

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidEmailException(email);

            if (email.Length > 100)
                throw new InvalidEmailException(email);

            email = email.ToLowerInvariant();
            if (!Regex.IsMatch(email))
                throw new InvalidEmailException(email);

            return new Email(email);
        }

        public static implicit operator string(Email email) => email.Value;
    }
}
