using Cookaracha.Core.Exceptions;

namespace Cookaracha.Core.ValueObjects;

public sealed record ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidProductNameException(value);

        Value = value;
    }

    public static implicit operator string(ProductName productId)
        => productId.Value;

    public static implicit operator ProductName(string value)
        => new(value);
}