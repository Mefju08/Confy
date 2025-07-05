using Confy.Application.Users.Commands.Update;
using Confy.Application.Users.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confy.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController(
        ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetUserQuery();
            var userDto = await sender.Send(query);

            return Ok(userDto);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await sender.Send(command);
            return NoContent();
        }

    }
}
