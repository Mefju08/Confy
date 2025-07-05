using MediatR;

namespace Confy.Application.Rooms.Commands.Add
{
    public sealed record AddRoomCommand(
        string Name,
        int Capacity,
        string Location,
        string Description) : IRequest;
}
