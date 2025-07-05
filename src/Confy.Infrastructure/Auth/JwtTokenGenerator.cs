using Confy.Application.Auth;
using Confy.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Confy.Infrastructure.Auth
{
    internal class JwtTokenGenerator(
        IOptions<AuthOptions> securityOptions) : IJwtTokenGenerator
    {
        public string Generate(Guid userId, string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityOptions.Value.SigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                issuer: securityOptions.Value.Issuer,
                audience: securityOptions.Value.Audience);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}
