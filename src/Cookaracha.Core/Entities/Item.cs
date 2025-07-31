using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Item : EntityBase
{
    public EntityId GroceryListId { get; private set; }
    public EntityId? ProductId { get; private set; }
    public ItemName Name { get; private set; }
    public ItemQuantity Quantity { get; private set; }
    public Product? Product { get; private set; }

    /// <summary>
    /// Empty constructor is required for EF Core property mapping.
    /// </summary>
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

    public void ChangeProductId(Guid? productId)
    {
        ModifiedAt = DateTimeOffset.UtcNow;
        ProductId = productId;
    }

    public void ChangeName(ItemName name)
    {
        ModifiedAt = DateTimeOffset.UtcNow;
        Name = name;
    }

    public void ChangeQuantity(ItemQuantity quantity)
    {
        ModifiedAt = DateTimeOffset.UtcNow;
        Quantity = quantity;
    }
}