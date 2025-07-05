namespace Confy.Infrastructure.Auth
{
    internal sealed class AuthOptions
    {
        public const string SectionName = "auth";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
    }
}
