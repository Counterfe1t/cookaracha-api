namespace Cookaracha.Application.DTO;

public class ItemDto
{
    public Guid Id { get; set; }
    public Guid? ProductId { get; set; }
    public string? Name { get; set; }
    public double Quantity { get; set; }
    public ProductDto? Product { get; set; }
}