using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Application.Queries;

public sealed record GetItems(
    Guid GroceryListId,
    int PageSize,
    int PageLimit) : IQuery<IEnumerable<ItemDto>>;