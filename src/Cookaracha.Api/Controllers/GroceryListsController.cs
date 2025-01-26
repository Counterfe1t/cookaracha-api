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
    private readonly ICommandHandler<UpdateGroceryList> _updateGroceryListHandler;
    private readonly ICommandHandler<DeleteGroceryList> _deleteGroceryListHandler;

    public GroceryListsController(
        IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>> getGroceryListsHandler,
        IQueryHandler<GetGroceryList, GroceryListDto> getGroceryListHandler,
        ICommandHandler<CreateGroceryList> createGroceryListHandler,
        ICommandHandler<UpdateGroceryList> updateGroceryListHandler,
        ICommandHandler<DeleteGroceryList> deleteGroceryListHandler)
    {
        _getGroceryListsHandler = getGroceryListsHandler;
        _getGroceryListHandler = getGroceryListHandler;
        _createGroceryListHandler = createGroceryListHandler;
        _updateGroceryListHandler = updateGroceryListHandler;
        _deleteGroceryListHandler = deleteGroceryListHandler;
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

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UpdateGroceryList command)
    {
        await _updateGroceryListHandler.HandleAsync(command with { Id = id });
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await _deleteGroceryListHandler.HandleAsync(new DeleteGroceryList(id));
        return NoContent();
    }
}