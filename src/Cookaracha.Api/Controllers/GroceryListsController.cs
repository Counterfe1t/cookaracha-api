using Cookaracha.Application.Abstractions;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/grocery-lists")]
public class GroceryListsController : ControllerBase
{
    private readonly IQueryHandler<GetGroceryList, GroceryListDto> _getGroceryListHandler;

    public GroceryListsController(IQueryHandler<GetGroceryList, GroceryListDto> getGroceryListHandler)
    {
        _getGroceryListHandler = getGroceryListHandler;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GroceryListDto>> Get([FromRoute] Guid id)
        => Ok(await _getGroceryListHandler.HandleAsync(new GetGroceryList(id)));
}
