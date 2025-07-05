using Confy.Abstractions.Types;
using Confy.Application.ContextAccessor;
using Confy.Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Confy.Infrastructure.ContextAccessor
{
    internal sealed class UserContext(
        IHttpContextAccessor context) : IUserContext
    {
        public CurrentUser Get()
        {
            var user = context?.HttpContext?.User
                ?? throw new InvalidOperationException("User context is not present"); ;
           
            if (user.Identity == null || !user.Identity.IsAuthenticated)
                throw new InvalidOperationException("User context is not present"); ;

            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            var emailClaim = user.FindFirst(ClaimTypes.Email);
            var roleClaim = user.FindFirst(ClaimTypes.Role);

            if (userIdClaim is null || emailClaim is null || roleClaim is null)
                throw new InvalidOperationException("User context is missing required claims.");

            return new CurrentUser(
              emailClaim.Value,
              Enum.Parse<Role>(roleClaim.Value),
               AggregateId.Create(Guid.Parse(userIdClaim.Value))
          );
        }
    }
}
