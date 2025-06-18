using Confy.Application.Security;
using System.Security.Cryptography;

namespace Confy.Infrastructure.Security
{
    internal sealed class KeyGenerator : IKeyGenerator
    {
        private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";
        private const int _length = 40;
        public string Generate()
        {
            var result = new char[_length];
            using var rng = RandomNumberGenerator.Create();
            byte[] buffer = new byte[sizeof(uint)];

            for (int i = 0; i < _length; i++)
            {
                rng.GetBytes(buffer);
                uint num = BitConverter.ToUInt32(buffer, 0);
                result[i] = _chars[(int)(num % _chars.Length)];
            }

            return new string(result);
        }
    }
}
