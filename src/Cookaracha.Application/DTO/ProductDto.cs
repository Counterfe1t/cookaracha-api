namespace Cookaracha.Application.DTO;

public class ProductDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string? Name { get; set; }
}