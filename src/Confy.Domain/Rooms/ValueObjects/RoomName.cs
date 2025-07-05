using Confy.Domain.Rooms.Exceptions;

namespace Confy.Domain.Rooms.ValueObjects
{
    public sealed record RoomName
    {
        public string Value { get; }
        private RoomName(string value) => Value = value;

        public static RoomName Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyRoomNameException();

            if (name.Length < 5)
                throw new TooShortRoomNameException(name);

            return new RoomName(name);
        }
        public static implicit operator string(RoomName roomName) => roomName.Value;
    }
}
