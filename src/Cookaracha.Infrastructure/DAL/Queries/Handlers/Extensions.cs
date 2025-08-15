using Cookaracha.Application.DTO;
using Cookaracha.Core.Entities;

namespace Cookaracha.Infrastructure.DAL.Queries.Handlers;

internal static class Extensions
{
    public static ProductDto AsDto(this Product entity)
        => new()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            ModifiedAt = entity.ModifiedAt?.Value,
            Name = entity.Name,
        };

    public static ItemDto AsDto(this Item entity)
        => new()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            ModifiedAt = entity.ModifiedAt?.Value,
            GroceryListId = entity.GroceryListId,
            ProductId = entity.ProductId?.Value,
            Product = entity.Product?.AsDto(),
            Name = entity.Name,
            Quantity = entity.Quantity,
            IsChecked = entity.IsChecked,
        };

    public static GroceryListDto AsDto(this GroceryList entity)
        => new()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            ModifiedAt = entity.ModifiedAt?.Value,
            Name = entity.Name,
            Items = entity.Items.Select(i => i.AsDto()),
        };
}