namespace Confy.Infrastructure.Exceptions.Models
{
    internal sealed record Error(
        string Code,
        string Message);
}
