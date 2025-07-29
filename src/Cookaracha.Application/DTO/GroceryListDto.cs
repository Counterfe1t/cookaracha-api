namespace Cookaracha.Application.DTO;

public class GroceryListDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<ItemDto> Items { get; set; } = [];
    public DateTimeOffset CreatedAt { get; set; }
}