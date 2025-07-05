using Confy.Application.Rooms.Commands.Add;
using Confy.Application.Rooms.Queries.Get;
using Confy.Application.Rooms.Queries.GetAll;
using Confy.Domain.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confy.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/rooms")]
    public class RoomController(
        ISender sender) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> Add(AddRoomCommand command)
        {
            await sender.Send(command);
            return Created();
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetRoomQuery(id);
            var roomDto = await sender.Send(query);

            return Ok(roomDto);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var query = new GetAllRoomsQuery(page, pageSize);
            var paginationDto = await sender.Send(query);
            return Ok(paginationDto);
        }


    }
}
