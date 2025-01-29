using Cookaracha.Core.Exceptions;
using System.Text.RegularExpressions;

namespace Cookaracha.Core.ValueObjects;

public sealed record ProductName
{
    private const int MinLength = 2;
    private const int MaxLength = 50;

    public string Value { get; }

    public ProductName(string value)
    {
        Value = IsValid(value)
            ? Sanitize(value)
            : throw new InvalidProductNameException(value);
    }

    public static implicit operator string(ProductName name)
        => name.Value;

    public static implicit operator ProductName(string value)
        => new(value);

    public static bool operator ==(ProductName name, string value)
        => name.Value == value;

    public static bool operator !=(ProductName name, string value)
        => name.Value != value;

    public static bool operator ==(string value, ProductName name)
        => name.Value == value;

    public static bool operator !=(string value, ProductName name)
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

    // TODO: Rename and move sanitization to a core utility class
    private static string Sanitize(string value)
        => Regex.Replace(value.ToLower().Trim(), @"\s+", " ");
}