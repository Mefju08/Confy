using Confy.Application.Reservations.Commands.UpdateStatus;
using Confy.Application.Rooms.Commands.Reserve;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confy.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/room/{roomId:Guid}/reservations")]
    public class ReservationController(
        ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid roomId, [FromBody] ReserveRoomCommand command)
        {
            await sender.Send(command with { RoomId = roomId });
            return Created();
        }

        [HttpPatch("{id:Guid}/cancel")]
        public async Task<IActionResult> Cancel([FromRoute] Guid id)
        {
            await sender.Send(new CancelReservationCommand(id));
            return NoContent();
        }
    }
}
