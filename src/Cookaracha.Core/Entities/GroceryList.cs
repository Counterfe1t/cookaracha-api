using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class GroceryList : EntityBase
{
    private HashSet<Item> _items = [];

    public GroceryListName Name { get; private set; }
    public IEnumerable<Item> Items => _items;

    /// <summary>
    /// Empty constructor is required for EF Core property mapping.
    /// </summary>
    private GroceryList() { }

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

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void AddItems(IEnumerable<Item> items)
    {
        foreach (var item in items)
            AddItem(item);
    }
}