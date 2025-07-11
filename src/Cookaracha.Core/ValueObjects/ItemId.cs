namespace Cookaracha.Core.ValueObjects;

public sealed record ItemId
{
    public Guid Value { get; private set; }

    public ItemId(Guid value)
    {
        Value = value;
    }

    public static implicit operator Guid(ItemId id)
        => id.Value;

    public static implicit operator ItemId(Guid value)
        => new(value);

    public static bool operator ==(ItemId id, Guid value)
        => id.Value == value;

    public static bool operator !=(ItemId id, Guid value)
        => id.Value != value;

    public static bool operator ==(Guid value, ItemId id)
        => id.Value == value;

    public static bool operator !=(Guid value, ItemId id)
        => id.Value != value;
}