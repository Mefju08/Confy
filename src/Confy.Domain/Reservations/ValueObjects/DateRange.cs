using Confy.Domain.Rooms.Exceptions;

namespace Confy.Domain.Reservations.ValueObjects
{
    public sealed record DateRange
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        private DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public static DateRange Create(DateTime startDate, DateTime endDate, DateTime now)
        {
            if (startDate < now)
                throw new InvalidReservationDateException("Reservation start date cannot be in the past.");

            if (endDate < now)
                throw new InvalidReservationDateException("Reservation end date cannot be in the past.");

            if (startDate >= endDate)
                throw new InvalidReservationDateException("Start date must be before end date.");

            return new DateRange(startDate, endDate);
        }
    }
}
