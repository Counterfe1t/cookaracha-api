using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Sanitization;
using Cookaracha.Core.Validation;

namespace Cookaracha.Core.ValueObjects;

public sealed record ItemName
{
    public string Value { get; private set; }

    public ItemName(string value)
    {
        Value = ItemNameValidator.IsValid(value)
            ? ItemNameSanitizer.Sanitize(value)
            : throw new InvalidItemNameException(value);
    }

    public static implicit operator string(ItemName name)
        => name.Value;

    public static implicit operator ItemName(string value)
        => new(value);

    public static bool operator ==(ItemName name, string value)
        => name.Value == value;

    public static bool operator !=(ItemName name, string value)
        => name.Value != value;

    public static bool operator ==(string value, ItemName name)
        => name.Value == value;

    public static bool operator !=(string value, ItemName name)
        => name.Value != value;
}