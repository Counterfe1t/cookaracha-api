using Cookaracha.Application.Abstractions;
using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Cookaracha.Api.Controllers;

// TODO: Add swagger documentation
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get(
        [FromQuery] GetProducts query,
        [FromServices] IQueryHandler<GetProducts, IEnumerable<ProductDto>> handler)
        => Ok(await handler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Get(
        [FromRoute] Guid id,
        [FromServices] IQueryHandler<GetProduct, ProductDto> handler)
        => Ok(await handler.HandleAsync(new GetProduct(id)));

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromBody] CreateProduct command,
        [FromServices] ICommandHandler<CreateProduct> handler)
    {
        command = command with { Id = Guid.NewGuid() };
        await handler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(
        [FromRoute] Guid id,
        [FromBody] UpdateProduct command,
        [FromServices] ICommandHandler<UpdateProduct> handler)
    {
        await handler.HandleAsync(command with { Id = id });
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] ICommandHandler<DeleteProduct> handler)
    {
        await handler.HandleAsync(new DeleteProduct(id));
        return NoContent();
    }
}