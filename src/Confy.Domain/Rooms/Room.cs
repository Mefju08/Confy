using Confy.Abstractions.Types;
using Confy.Domain.Rooms.ValueObjects;

namespace Confy.Domain.Rooms
{
    public sealed class Room : AggregateRoot
    {
        public RoomName Name { get; private set; }
        public RoomCapacity Capacity { get; private set; }
        public RoomLocation Location { get; private set; }
        public RoomDescription Description { get; private set; }

        private Room() { }
        private Room(AggregateId id, RoomName name, RoomCapacity capacity, RoomLocation location,
            RoomDescription description)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Location = location;
            Description = description;
        }

        public static Room Create(RoomName name, RoomCapacity capacity, RoomLocation location,
            RoomDescription description)
        {
            var room = new Room(AggregateId.Create(), name, capacity, location, description);

            return room;
        }
    }
}
