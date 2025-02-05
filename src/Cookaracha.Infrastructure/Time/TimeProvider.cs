using Cookaracha.Core.Abstractions;

namespace Cookaracha.Infrastructure.Time;

public class TimeProvider : ITimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}