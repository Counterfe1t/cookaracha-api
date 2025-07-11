namespace Cookaracha.Core.ValueObjects;

public sealed record ItemQuantity
{
    public double Value { get; private set; }

    public ItemQuantity(double value)
    {
        Value = value;
    }

    public static implicit operator double(ItemQuantity id)
        => id.Value;

    public static implicit operator ItemQuantity(double value)
        => new(value);

    public static bool operator ==(ItemQuantity id, double value)
        => id.Value == value;

    public static bool operator !=(ItemQuantity id, double value)
        => id.Value != value;

    public static bool operator ==(double value, ItemQuantity id)
        => id.Value == value;

    public static bool operator !=(double value, ItemQuantity id)
        => id.Value != value;
}