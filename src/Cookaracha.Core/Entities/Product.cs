using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Entities;

public sealed class Product
{
    public ProductId Id { get; private set; }
    public ProductName Name { get; private set; }

    public Product(ProductId id, ProductName name)
    {
        Id = id;
        Name = name;
    }

    public void ChangeProductName(ProductName name)
    {
        Name = name;
    }
}