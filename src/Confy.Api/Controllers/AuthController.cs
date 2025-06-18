using Confy.Application.Auth.Commands.Confirm;
using Confy.Application.Auth.Commands.Login;
using Confy.Application.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confy.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(
        ISender sender) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            await sender.Send(command);
            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await sender.Send(command);
            return Ok(result);
        }

        [HttpPatch("confirm")]
        public async Task<IActionResult> Confirm([FromBody] ConfirmAccountCommand command)
        {
            await sender.Send(command);
            return NoContent();
        }
    }
}
