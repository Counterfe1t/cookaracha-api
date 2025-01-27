using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class GroceryList
{
    public GroceryListId Id { get; private set; }
    public GroceryListName Name { get; private set; }

    public GroceryList(
        GroceryListId id,
        GroceryListName name)
    {
        Id = id;
        Name = name;
    }
}