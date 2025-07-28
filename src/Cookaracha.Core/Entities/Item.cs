using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Item : EntityBase
{
    public EntityId GroceryListId { get; private set; }
    public EntityId? ProductId { get; private set; }
    public ItemName Name { get; private set; }
    public ItemQuantity Quantity { get; private set; }
    public Product? Product { get; private set; }

    private Item() { }

    public Item(
        EntityId id,
        EntityId groceryListId,
        EntityId? productId,
        ItemName name,
        ItemQuantity quantity,
        Date createdAt) : base(id, createdAt)
    {
        GroceryListId = groceryListId;
        ProductId = productId;
        Name = name;
        Quantity = quantity;
    }
}