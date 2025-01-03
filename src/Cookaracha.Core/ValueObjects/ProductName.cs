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
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidProductNameException(value);

        if (value.Length < MinLength || value.Length > MaxLength)
            throw new InvalidProductNameException(value);

        Value = Sanitize(value);
    }

    public static implicit operator string(ProductName name)
        => name.Value;

    public static implicit operator ProductName(string value)
        => new(value);

    // TODO: Rename and move this method to a core utility class
    private static string Sanitize(string value)
        => Regex.Replace(value.ToLower().Trim(), @"\s+", " ");
}