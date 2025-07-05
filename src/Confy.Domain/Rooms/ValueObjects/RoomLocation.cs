using Confy.Domain.Rooms.Exceptions;

namespace Confy.Domain.Rooms.ValueObjects
{
    public sealed record RoomLocation
    {
        public string Value { get; }
        private RoomLocation(string value) => Value = value;

        public static RoomLocation Create(string location)
        {
            if (string.IsNullOrEmpty(location))
                throw new EmptyRoomLocationException();

            return new RoomLocation(location);
        }
        public static implicit operator string(RoomLocation roomLocation) => roomLocation.Value;
    }
}
