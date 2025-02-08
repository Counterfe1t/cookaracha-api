using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class GroceryList : Entity
{
    public GroceryListId Id { get; private set; }
    public GroceryListName Name { get; private set; }

    public GroceryList(
        GroceryListId id,
        GroceryListName name,
        Date createdAt) : base(createdAt)
    {
        Id = id;
        Name = name;
    }

    public void ChangeGroceryListName(GroceryListName name)
    {
        Name = name;
    }
}