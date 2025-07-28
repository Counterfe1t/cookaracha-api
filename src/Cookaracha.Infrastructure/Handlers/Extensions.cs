using Cookaracha.Application.DTO;
using Cookaracha.Core.Entities;

namespace Cookaracha.Infrastructure.Handlers;

internal static class Extensions
{
    public static ProductDto AsDto(this Product entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };

    public static ItemDto AsDto(this Item entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Quantity = entity.Quantity,
            ProductId = entity.ProductId?.Value,
            Product = entity.Product?.AsDto(),
        };

    public static GroceryListDto AsDto(this GroceryList entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Items = entity.Items.Select(i => i.AsDto()),
        };
}