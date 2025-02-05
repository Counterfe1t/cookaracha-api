﻿namespace Cookaracha.Core.Abstractions;

public interface ITimeProvider
{
    /// <summary>
    /// Gets the current date and time in Coordinated Universal Time (UTC).
    /// </summary>
    public DateTimeOffset UtcNow { get; }
}