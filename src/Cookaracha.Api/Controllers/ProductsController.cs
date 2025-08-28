using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Infrastructure.DAL.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get products by query.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get(
        [FromQuery] GetProducts query,
        [FromServices] IQueryHandler<GetProducts, IEnumerable<ProductDto>> handler)
        => Ok(await handler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    [SwaggerOperation("Get product by ID.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> Get(
        [FromRoute] Guid id,
        [FromServices] IQueryHandler<GetProduct, ProductDto> handler)
        => Ok(await handler.HandleAsync(new(id)));

    [HttpPost]
    [SwaggerOperation("Create new product.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Post(
        [FromBody] CreateProduct command,
        [FromServices] ICommandHandler<CreateProduct> handler)
    {
        command = command with { Id = Guid.NewGuid() };
        await handler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation("Update product by ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(
        [FromRoute] Guid id,
        [FromBody] UpdateProduct command,
        [FromServices] ICommandHandler<UpdateProduct> handler)
    {
        await handler.HandleAsync(command with { Id = id });
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation("Delete product by ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] ICommandHandler<DeleteProduct> handler)
    {
        await handler.HandleAsync(new(id));
        return NoContent();
    }
}