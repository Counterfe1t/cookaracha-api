using Cookaracha.Core.Exceptions;

namespace Cookaracha.Core.ValueObjects;

public sealed record EntityId
{
    public Guid Value { get; }

    public EntityId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(EntityId id)
        => id.Value;

    public static implicit operator Guid?(EntityId id)
        => id?.Value;

    public static implicit operator EntityId(Guid value)
        => new(value);

    public static bool operator ==(EntityId id, Guid value)
        => id.Value == value;

    public static bool operator !=(EntityId id, Guid value)
        => id.Value != value;

    public static bool operator ==(Guid value, EntityId id)
        => id.Value == value;

    public static bool operator !=(Guid value, EntityId id)
        => id.Value != value;
}