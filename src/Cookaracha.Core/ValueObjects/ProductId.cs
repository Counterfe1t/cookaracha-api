using Cookaracha.Core.Exceptions;

namespace Cookaracha.Core.ValueObjects;

public sealed record ProductId
{
    public Guid Value { get; }

    public ProductId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(ProductId id)
        => id.Value;

    public static implicit operator ProductId(Guid value)
        => new(value);

    public static bool operator ==(ProductId id, Guid value)
        => id.Value == value;

    public static bool operator !=(ProductId id, Guid value)
        => id.Value != value;

    public static bool operator ==(Guid value, ProductId id)
        => id.Value == value;

    public static bool operator !=(Guid value, ProductId id)
        => id.Value != value;
}