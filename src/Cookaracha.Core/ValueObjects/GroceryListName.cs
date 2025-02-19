using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Sanitization;
using Cookaracha.Core.Validation;

namespace Cookaracha.Core.ValueObjects;

public sealed record GroceryListName
{
    public string Value { get; }

    public GroceryListName(string value)
    {
        Value = GroceryListNameValidator.IsValid(value)
            ? GroceryListNameSanitizer.Sanitize(value)
            : throw new InvalidGroceryListNameException(value);
    }

    public static implicit operator string(GroceryListName name)
        => name.Value;

    public static implicit operator GroceryListName(string value)
        => new(value);

    public static bool operator ==(GroceryListName name, string value)
        => name.Value == value;

    public static bool operator !=(GroceryListName name, string value)
        => name.Value != value;

    public static bool operator ==(string value, GroceryListName name)
        => name.Value == value;

    public static bool operator !=(string value, GroceryListName name)
        => name.Value != value;
}