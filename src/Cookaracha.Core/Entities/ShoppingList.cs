using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class ShoppingList
{
    public ShoppingListId Id { get; private set; }

    public ShoppingList(ShoppingListId id)
    {
        Id = id;
    }
}