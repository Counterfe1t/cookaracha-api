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

    public static ProductId Create()
        => new(Guid.NewGuid());

    public static implicit operator Guid(ProductId productId)
        => productId.Value;

    public static implicit operator ProductId(Guid value)
        => new(value);
}