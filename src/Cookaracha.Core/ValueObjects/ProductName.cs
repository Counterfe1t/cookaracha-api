using Cookaracha.Core.Exceptions;

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

        Value = value;
    }

    public static implicit operator string(ProductName name)
        => name.Value;

    public static implicit operator ProductName(string value)
        => new(value);
}