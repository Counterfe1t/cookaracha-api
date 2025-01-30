using Cookaracha.Core.Exceptions;
using System.Text.RegularExpressions;

namespace Cookaracha.Core.ValueObjects;

public sealed record GroceryListName
{
    private const int MinLength = 2;
    private const int MaxLength = 50;

    public string Value { get; }

    public GroceryListName(string value)
    {
        Value = IsValid(value)
            ? Sanitize(value)
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

    // TODO: Improve and move validation to a core utility class
    private static bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        if (value.Length < MinLength || value.Length > MaxLength)
            return false;

        return true;
    }

    // TODO: Rename and move this method to a core utility class
    private static string Sanitize(string value)
        => Regex.Replace(value.Trim(), @"\s+", " ");
}