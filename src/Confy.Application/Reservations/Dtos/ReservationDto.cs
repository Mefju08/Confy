using Confy.Domain.Reservations;

namespace Confy.Application.Reservations.Dtos
{
    public sealed record ReservationDto(
        Guid Id,
        DateTime StartDate,
        DateTime EndDate)
    {
        public static ReservationDto Map(Reservation reservation)
        {
            return new ReservationDto(reservation.Id, reservation.Dates.StartDate, reservation.Dates.EndDate);
        }
    }

}
