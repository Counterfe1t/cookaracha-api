using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Infrastructure.DAL.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/grocery-lists")]
public class GroceryListsController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get grocery lists by query.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<GroceryListDto>>> Get(
        [FromQuery] GetGroceryLists query,
        [FromServices] IQueryHandler<GetGroceryLists, IEnumerable<GroceryListDto>> handler)
        => Ok(await handler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    [SwaggerOperation("Get grocery list by ID.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GroceryListDto>> Get(
        [FromRoute] Guid id,
        [FromServices] IQueryHandler<GetGroceryList, GroceryListDto> handler)
        => Ok(await handler.HandleAsync(new(id)));

    [HttpPost]
    [SwaggerOperation("Create new grocery list.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Post(
        [FromBody] CreateGroceryList command,
        [FromServices] ICommandHandler<CreateGroceryList> handler)
    {
        command = command with { Id = Guid.NewGuid() };
        await handler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation("Update grocery list.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(
        [FromRoute] Guid id,
        [FromBody] UpdateGroceryList command,
        [FromServices] ICommandHandler<UpdateGroceryList> handler)
    {
        await handler.HandleAsync(command with { Id = id });
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation("Delete grocery list.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] ICommandHandler<DeleteGroceryList> handler)
    {
        await handler.HandleAsync(new(id));
        return NoContent();
    }
}