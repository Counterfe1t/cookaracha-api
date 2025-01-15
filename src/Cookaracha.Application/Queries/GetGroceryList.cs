using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;

namespace Cookaracha.Application.Queries;

public sealed record GetGroceryList(Guid GroceryListId) : IQuery<GroceryListDto>;