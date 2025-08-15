namespace Cookaracha.Core.ValueObjects;

public sealed record ItemQuantity
{
    public double Value { get; private set; }

    public ItemQuantity(double value)
    {
        Value = value;
    }

    public static implicit operator double(ItemQuantity quantity)
        => quantity.Value;

    public static implicit operator ItemQuantity(double value)
        => new(value);

    public static bool operator ==(ItemQuantity quantity, double value)
        => quantity.Value == value;

    public static bool operator !=(ItemQuantity quantity, double value)
        => quantity.Value != value;

    public static bool operator ==(double value, ItemQuantity quantity)
        => quantity.Value == value;

    public static bool operator !=(double value, ItemQuantity quantity)
        => quantity.Value != value;
}