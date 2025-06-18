namespace Confy.Application.Reservations.Dtos
{
    public sealed record ReservationDto(
        int Id,
        DateTime StartDate,
        DateTime EndDate);

}
