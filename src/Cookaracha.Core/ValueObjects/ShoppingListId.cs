using Cookaracha.Core.Exceptions;

namespace Cookaracha.Core.ValueObjects;

public sealed record ShoppingListId
{
    public Guid Value { get; }

    public ShoppingListId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(ShoppingListId id)
        => id.Value;

    public static implicit operator ShoppingListId(Guid value)
        => new(value);
}