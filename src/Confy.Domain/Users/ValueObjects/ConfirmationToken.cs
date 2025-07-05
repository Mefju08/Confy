using Confy.Domain.Users.Exceptions;
using System.Security.Cryptography;

namespace Confy.Domain.Users.ValueObjects
{
    public sealed record ConfirmationToken
    {
        public string Value { get; }
        private ConfirmationToken(string value) => Value = value;

        public static ConfirmationToken Create(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new EmptyConfirmationTokenException();

            return new ConfirmationToken(token);
        }

        public static ConfirmationToken Generate()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(32);
            var tokenValue = Convert.ToBase64String(randomBytes)
                .TrimEnd('=').Replace('+', '-').Replace('/', '_');

            return new ConfirmationToken(tokenValue);
        }

        public static implicit operator string(ConfirmationToken token) => token.Value;

    }
}
