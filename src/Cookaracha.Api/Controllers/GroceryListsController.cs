using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/grocery-lists")]
public class GroceryListsController : ControllerBase
{
    private readonly IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>> _getGroceryListsHandler;
    private readonly IQueryHandler<GetGroceryList, GroceryListDto> _getGroceryListHandler;

    public GroceryListsController(
        IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>> getGroceryListsHandler,
        IQueryHandler<GetGroceryList, GroceryListDto> getGroceryListHandler)
    {
        _getGroceryListsHandler = getGroceryListsHandler;
        _getGroceryListHandler = getGroceryListHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroceryListDto>>> Get([FromQuery] GetGroceryLists query)
        => Ok(await _getGroceryListsHandler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GroceryListDto>> Get([FromRoute] Guid id)
        => Ok(await _getGroceryListHandler.HandleAsync(new GetGroceryList(id)));
}