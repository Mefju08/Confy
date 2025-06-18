using Confy.Domain.Reservations;
using Confy.Domain.Reservations.ValueObjects;
using Confy.Domain.Rooms.Exceptions;
using Confy.Domain.Rooms.ValueObjects;

namespace Confy.Domain.Rooms
{
    public sealed class Room
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public RoomCapacity Capacity { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }
        public List<Reservation> Reservations { get; set; } = new();

        public Room(string name, RoomCapacity capacity, string location, string description)
        {
            Name = name;
            Capacity = capacity;
            Location = location;
            Description = description;
        }

        public void AddReservation(Reservation reservation, DateTime now)
        {
            if (reservation.StartDate < now || reservation.EndDate < now)
                throw new InvalidReservationDateException();
            if (reservation.StartDate >= reservation.EndDate)
                throw new InvalidReservationDateException();

            var activeReservations = Reservations.Where(x => x.Status is ReservationStatus.Active);
            if (activeReservations.Any(x => IsOverlapping(x, reservation)))
                throw new RoomAlreadyReservedException();

            Reservations.Add(reservation);
        }

        private bool IsOverlapping(Reservation a, Reservation b)
        {
            return !(a.EndDate <= b.StartDate || b.EndDate <= a.StartDate);
        }

    }
}
