namespace Cookaracha.Core.ValueObjects;

public sealed record ItemName
{
    public string Value { get; private set; }

    public ItemName(string value)
    {
        Value = value;
    }

    public static implicit operator string(ItemName id)
        => id.Value;

    public static implicit operator ItemName(string value)
        => new(value);

    public static bool operator ==(ItemName id, string value)
        => id.Value == value;

    public static bool operator !=(ItemName id, string value)
        => id.Value != value;

    public static bool operator ==(string value, ItemName id)
        => id.Value == value;

    public static bool operator !=(string value, ItemName id)
        => id.Value != value;
}