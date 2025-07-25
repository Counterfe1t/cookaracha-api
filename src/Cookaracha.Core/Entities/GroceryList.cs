using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class GroceryList : EntityBase
{
    public GroceryListName Name { get; private set; }

    public GroceryList(
        EntityId id,
        GroceryListName name,
        Date createdAt) : base(id, createdAt)
    {
        Name = name;
    }

    public void ChangeGroceryListName(GroceryListName name)
    {
        Name = name;
    }
}