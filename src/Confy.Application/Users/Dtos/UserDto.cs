using Confy.Application.Reservations.Dtos;

namespace Confy.Application.Users.Dtos
{
    public sealed record UserDto(
        string Email,
        string FullName,
        IEnumerable<ReservationDto> Reservations);
}
