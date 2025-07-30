using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cookaracha.Api.Controllers;

// TODO: Add swagger documentation
[ApiController]
[Route("api/grocery-lists")]
public class GroceryListsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroceryListDto>>> Get(
        [FromQuery] GetGroceryLists query,
        [FromServices] IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>> handler)
        => Ok(await handler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GroceryListDto>> Get(
        [FromRoute] Guid id,
        [FromServices] IQueryHandler<GetGroceryList, GroceryListDto> handler)
        => Ok(await handler.HandleAsync(new GetGroceryList(id)));

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] CreateGroceryList command,
        [FromServices] ICommandHandler<CreateGroceryList> handler)
    {
        command = command with { Id = Guid.NewGuid() };
        await handler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(
        [FromRoute] Guid id,
        [FromBody] UpdateGroceryList command,
        [FromServices] ICommandHandler<UpdateGroceryList> handler)
    {
        await handler.HandleAsync(command with { Id = id });
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] ICommandHandler<DeleteGroceryList> handler)
    {
        await handler.HandleAsync(new DeleteGroceryList(id));
        return NoContent();
    }
}