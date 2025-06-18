using Confy.Domain.Rooms.Exceptions;

namespace Confy.Domain.Rooms.ValueObjects
{
    public sealed record RoomCapacity
    {
        public int Value { get; }
        public RoomCapacity(int value)
        {
            if (value <= 0)
            {
                throw new RoomCapacityOutOfRangeException();
            }
            Value = value;
        }

        public static implicit operator RoomCapacity(int value) => new RoomCapacity(value);
        public static implicit operator int(RoomCapacity roomCapacity) => roomCapacity.Value;
    }
}
