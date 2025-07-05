using Confy.Domain.Clock;

namespace Confy.Infrastructure.Time
{
    internal sealed class Clock : IClock
    {
        public DateTime Now() => DateTime.Now;
    }
}
