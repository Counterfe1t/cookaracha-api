using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/grocery-lists/{groceryListId:guid}/[controller]")]
public class ItemsController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get items from the grocery list.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ItemDto>> Get(
        [FromRoute] Guid groceryListId,
        [FromQuery] GetItems query,
        [FromServices] IQueryHandler<GetItems, IEnumerable<ItemDto>> handler)
        => Ok(await handler.HandleAsync(query with { GroceryListId = groceryListId }));

    [HttpGet("{itemId:guid}")]
    [SwaggerOperation("Get item from the grocery list by ID.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ItemDto>> Get(
        [FromRoute] Guid itemId,
        [FromServices] IQueryHandler<GetItem, ItemDto> handler)
        => Ok(await handler.HandleAsync(new(itemId)));

    [HttpPost]
    [SwaggerOperation("Create new item in the grocery list.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Post(
        [FromRoute] Guid groceryListId,
        [FromBody] CreateItem command,
        [FromServices] ICommandHandler<CreateItem> handler)
    {
        command = command with { Id = Guid.NewGuid(), GroceryListId = groceryListId };
        await handler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new { command.GroceryListId, command.Id }, null);
    }

    [HttpPut("{itemId:guid}")]
    [SwaggerOperation("Update item from the grocery list.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(
        [FromRoute] Guid itemId,
        [FromBody] UpdateItem command,
        [FromServices] ICommandHandler<UpdateItem> handler)
    {
        await handler.HandleAsync(command with { Id = itemId });
        return NoContent();
    }

    [HttpDelete("{itemId:guid}")]
    [SwaggerOperation("Delete item from the grocery list.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid itemId,
        [FromServices] ICommandHandler<DeleteItem> handler)
    {
        await handler.HandleAsync(new(itemId));
        return NoContent();
    }
}
