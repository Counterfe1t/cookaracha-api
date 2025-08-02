namespace Cookaracha.Application.DTO;

public class ItemDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid GroceryListId { get; set; }
    public Guid? ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public string? Name { get; set; }
    public double Quantity { get; set; }
    public bool IsChecked { get; set; }
}