using Confy.Abstractions.Types;
using Confy.Domain.Reservations.Exceptions;
using Confy.Domain.Reservations.ValueObjects;

namespace Confy.Domain.Reservations
{
    public sealed class Reservation : AggregateRoot
    {
        public AggregateId RoomId { get; private set; }
        public AggregateId UserId { get; private set; }
        public DateRange Dates { get; private set; }
        public ReservationStatus Status { get; private set; }

        private Reservation() { }
        private Reservation(AggregateId id, AggregateId roomId, AggregateId userId, DateRange dates,
            ReservationStatus status)
        {
            Id = id;
            RoomId = roomId;
            UserId = userId;
            Dates = dates;
            Status = status;
        }

        public static Reservation Create(AggregateId roomId, AggregateId userId, DateRange dates)
        {
            var reservation = new Reservation(AggregateId.Create(), roomId, userId, dates,
                ReservationStatus.Active);

            return reservation;
        }
        public void Cancel(DateTime now)
        {
            if (Status is ReservationStatus.Canceled)
                throw new ReservationIsAlreadyCanceledException(Id);

            if (Dates.StartDate.AddHours(-2) <= now)
                throw new TooLateToChangeReservationStatusException();

            Status = ReservationStatus.Canceled;
        }
    }
}
