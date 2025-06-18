namespace Confy.Application.Auth.Dtos
{
    public sealed record LoginResponseDto(
        string Email,
        string FullName,
        string Token);
}
