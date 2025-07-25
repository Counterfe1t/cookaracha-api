using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Item : EntityBase
{
    public ItemName Name { get; private set; }
    public ItemQuantity Quantity { get; private set; }

    public Item(
        EntityId id,
        ItemName name,
        ItemQuantity quantity,
        Date createdAt) : base(id, createdAt)
    {
        Name = name;
        Quantity = quantity;
    }
}