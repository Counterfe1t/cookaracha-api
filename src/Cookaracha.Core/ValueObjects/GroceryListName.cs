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
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidGroceryListNameException(value);

        if (value.Length < MinLength || value.Length > MaxLength)
            throw new InvalidGroceryListNameException(value);

        Value = Sanitize(value);
    }

    public static implicit operator string(GroceryListName name)
        => name.Value;

    public static implicit operator GroceryListName(string value)
        => new(value);

    // TODO: Rename and move this method to a core utility class
    private static string Sanitize(string value)
        => Regex.Replace(value.ToLower().Trim(), @"\s+", " ");
}