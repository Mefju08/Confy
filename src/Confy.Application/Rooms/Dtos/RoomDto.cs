using Confy.Domain.Rooms;

namespace Confy.Application.Rooms.Dtos
{
    public sealed record RoomDto(
        Guid Id,
        string Name,
        string Location,
        string Description,
        int Capacity)
    {
        public static RoomDto Map(Room room)
        {
            return new RoomDto(room.Id, room.Name, room.Location, room.Description, room.Capacity);
        }
    }
}
