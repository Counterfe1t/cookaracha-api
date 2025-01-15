using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Core.Repositories;

namespace Cookaracha.Application.Queries.Handlers;

public sealed class GetGroceryListHandler : IQueryHandler<GetGroceryList, GroceryListDto>
{
    private readonly IGroceryListsRepository _groceryListsRepository;

    public GetGroceryListHandler(IGroceryListsRepository groceryListsRepository)
    {
        _groceryListsRepository = groceryListsRepository;
    }

    public async Task<GroceryListDto> HandleAsync(GetGroceryList command)
    {
        var result = await _groceryListsRepository.GetAsync(command.GroceryListId) ?? throw new Exception();

        return new GroceryListDto
        {
            Id = result.Id
        };
    }
}