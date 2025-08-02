namespace Cookaracha.Core.ValueObjects;

public sealed record ItemChecked
{
    public bool Value { get; private set; }

    public ItemChecked(bool value)
    {
        Value = value;
    }

    public static implicit operator bool(ItemChecked isChecked)
        => isChecked.Value;

    public static implicit operator ItemChecked(bool value)
        => new(value);

    public static bool operator ==(ItemChecked isChecked, bool value)
        => isChecked.Value == value;

    public static bool operator !=(ItemChecked isChecked, bool value)
        => isChecked.Value != value;

    public static bool operator ==(bool value, ItemChecked isChecked)
        => isChecked.Value == value;

    public static bool operator !=(bool value, ItemChecked isChecked)
        => isChecked.Value != value;
}