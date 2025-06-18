namespace Confy.Application.Rooms.Dtos
{
    public sealed record RoomDto(
        int Id,
        string Name,
        string Location,
        string Description,
        int Capacity);
}
