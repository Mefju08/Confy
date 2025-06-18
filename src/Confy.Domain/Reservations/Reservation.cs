using Confy.Domain.Reservations.Exceptions;
using Confy.Domain.Reservations.ValueObjects;
using Confy.Domain.Rooms;
using Confy.Domain.Users;

namespace Confy.Domain.Reservations
{
    public sealed class Reservation
    {
        public int Id { get; private set; }
        public int RoomId { get; private set; }
        public Room Room { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public ReservationStatus Status { get; private set; }

        public Reservation(int roomId, int userId, DateTime startDate, DateTime endDate, ReservationStatus status)
        {
            RoomId = roomId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        public void SetStatus(ReservationStatus status, DateTime now)
        {
            if (StartDate.AddHours(-2) <= now)
            {
                throw new TooLateToChangeReservationStatusException();
            }

            Status = status;
        }

    }
}
