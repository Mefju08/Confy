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
            var user = context?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var role = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.FirstOrDefault().Value;

            return new CurrentUser(
                email,
                Enum.Parse<Role>(role),
                Convert.ToInt32(userId));
        }
    }
}
