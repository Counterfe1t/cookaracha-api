using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Item : EntityBase
{
    public ItemId Id { get; private set; }
    public ItemName Name { get; private set; }
    public ItemQuantity Quantity { get; private set; }

    public Item(
        ItemId id,
        ItemName name,
        ItemQuantity quantity,
        Date createdAt) : base(createdAt)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
}