using Confy.Application.Reservations.Commands.UpdateStatus;
using Confy.Application.Rooms.Commands.Reserve;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confy.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/room/{roomId:int}/reservations")]
    public class ReservationController(
        ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] int roomId, [FromBody] ReserveRoomCommand command)
        {
            await sender.Send(command with { RoomId = roomId });
            return Created();
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpadteStatus([FromRoute] int id, [FromBody] UpdateReservationStatusCommand command)
        {
            await sender.Send(command with { ReservationId = id });
            return NoContent();
        }
    }
}
