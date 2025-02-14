using Cookaracha.Core.Exceptions;
using Cookaracha.Core.Sanitization;
using Cookaracha.Core.Validation;

namespace Cookaracha.Core.ValueObjects;

public sealed record ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        Value = ProductNameValidator.IsValid(value)
            ? ProductNameSanitizer.Sanitize(value)
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
}