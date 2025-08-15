using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Infrastructure.DAL.Queries;

public sealed record GetItems(
    Guid GroceryListId,
    int PageNumber,
    int PageSize) : IQuery<IEnumerable<ItemDto>>;