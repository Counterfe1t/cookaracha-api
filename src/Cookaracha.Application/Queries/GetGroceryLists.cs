using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Application.Queries;

public sealed record GetGroceryLists(int PageNumber, int PageSize) : IQuery<IEnumerable<GroceryListDto>>;