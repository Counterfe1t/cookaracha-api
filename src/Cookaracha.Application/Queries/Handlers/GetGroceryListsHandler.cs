using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Queries.Handlers;

public sealed class GetGroceryListsHandler : IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>>
{
    private readonly IGroceryListsRepository _groceryListsRepository;

    public GetGroceryListsHandler(IGroceryListsRepository groceryListsRepository)
    {
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task<IEnumerable<GroceryListDto>> HandleAsync(GetGroceryLists command)
    {
        var groceryLists = await _groceryListsRepository.GetAllAsync();

        return groceryLists.Select(gl => new GroceryListDto
        {
            Id = gl.Id,
            Name = gl.Name,
        });
    }
}