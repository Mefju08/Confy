using Confy.Domain.Rooms.Exceptions;

namespace Confy.Domain.Rooms.ValueObjects
{
    public sealed record RoomDescription
    {
        public string Value { get; }
        private RoomDescription(string value) => Value = value;

        public static RoomDescription Create(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new EmptyRoomDescriptionException();

            return new RoomDescription(description);
        }
        public static implicit operator string(RoomDescription roomDescription) => roomDescription.Value;
    }
}
