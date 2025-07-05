namespace Confy.Application.Users.Dtos
{
    public sealed record UserDto(
        Guid Id,
        string Email,
        string FullName);
}
