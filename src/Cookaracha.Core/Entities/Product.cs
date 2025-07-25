using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Product : EntityBase
{
    public ProductName Name { get; private set; }

    public Product(
        EntityId id,
        ProductName name,
        Date createdAt) : base(id, createdAt)
    {
        Name = name;
    }

    public void ChangeProductName(ProductName name)
    {
        Name = name;
    }
}