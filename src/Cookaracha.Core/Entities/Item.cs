using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Item : EntityBase
{
    public EntityId GroceryListId { get; private set; }
    public EntityId? ProductId { get; private set; }
    public Product? Product { get; private set; }
    public ItemName Name { get; private set; }
    public ItemQuantity Quantity { get; private set; }
    public ItemChecked IsChecked { get; private set; }

    /// <summary>
    /// Empty constructor is required for EF Core property mapping.
    /// </summary>
    private Item() { }

    public Item(
        EntityId id,
        Date createdAt,
        EntityId groceryListId,
        EntityId? productId,
        ItemName name,
        ItemQuantity quantity,
        ItemChecked isChecked) : base(id, createdAt)
    {
        GroceryListId = groceryListId;
        ProductId = productId;
        Name = name;
        Quantity = quantity;
        IsChecked = isChecked;
    }

    public void ChangeProductId(EntityId? productId)
        => ProductId = productId;

    public void ChangeName(ItemName name)
        => Name = name;

    public void ChangeQuantity(ItemQuantity quantity)
        => Quantity = quantity;

    public void ChangeIsChecked(ItemChecked isChecked)
        => IsChecked = isChecked;
}