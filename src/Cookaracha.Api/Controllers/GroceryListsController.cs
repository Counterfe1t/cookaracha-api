using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
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

    private readonly ICommandHandler<CreateGroceryList> _createGroceryListHandler;

    public GroceryListsController(
        IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>> getGroceryListsHandler,
        IQueryHandler<GetGroceryList, GroceryListDto> getGroceryListHandler,
        ICommandHandler<CreateGroceryList> createGroceryListHandler)
    {
        _getGroceryListsHandler = getGroceryListsHandler;
        _getGroceryListHandler = getGroceryListHandler;
        _createGroceryListHandler = createGroceryListHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroceryListDto>>> Get([FromQuery] GetGroceryLists query)
        => Ok(await _getGroceryListsHandler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GroceryListDto>> Get([FromRoute] Guid id)
        => Ok(await _getGroceryListHandler.HandleAsync(new GetGroceryList(id)));

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateGroceryList command)
    {
        command = command with { Id = Guid.NewGuid() };
        await _createGroceryListHandler.HandleAsync(command);

        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }
}