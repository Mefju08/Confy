using Confy.Domain.Rooms.Exceptions;

namespace Confy.Domain.Rooms.ValueObjects
{
    public sealed record RoomCapacity
    {
        public int Value { get; }
        private RoomCapacity(int value) => Value = value;

        public static RoomCapacity Create(int capacity)
        {
            if (capacity <= 0)
                throw new RoomCapacityOutOfRangeException();

            return new RoomCapacity(capacity);
        }
        public static implicit operator int(RoomCapacity roomCapacity) => roomCapacity.Value;
    }
}
