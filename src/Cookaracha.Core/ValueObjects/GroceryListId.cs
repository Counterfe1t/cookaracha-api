using Cookaracha.Core.Exceptions;

namespace Cookaracha.Core.ValueObjects;

public sealed record GroceryListId
{
    public Guid Value { get; }

    public GroceryListId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(GroceryListId id)
        => id.Value;

    public static implicit operator GroceryListId(Guid value)
        => new(value);
}