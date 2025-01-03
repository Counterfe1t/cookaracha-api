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
    private readonly IQueryHandler<GetProducts, IEnumerable<ProductDto>> _getProductsHandler;
    private readonly IQueryHandler<GetProduct, ProductDto> _getProductHandler;

    private readonly ICommandHandler<CreateProduct> _createProductHandler;
    private readonly ICommandHandler<UpdateProduct> _updateProductHandler;
    private readonly ICommandHandler<DeleteProduct> _deleteProductHandler;

    public ProductsController(
        IQueryHandler<GetProducts, IEnumerable<ProductDto>> getProductsHandler,
        IQueryHandler<GetProduct, ProductDto> getProductHandler,
        ICommandHandler<CreateProduct> createProductHandler,
        ICommandHandler<UpdateProduct> updateProductHandler,
        ICommandHandler<DeleteProduct> deleteProductHandler)
    {
        _getProductsHandler = getProductsHandler;
        _getProductHandler = getProductHandler;
        _createProductHandler = createProductHandler;
        _updateProductHandler = updateProductHandler;
        _deleteProductHandler = deleteProductHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] GetProducts query)
        => Ok(await _getProductsHandler.HandleAsync(query));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
        => Ok(await _getProductHandler.HandleAsync(new GetProduct(id)));

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateProduct command)
    {
        command = command with { Id = Guid.NewGuid() };
        await _createProductHandler.HandleAsync(command);

        return CreatedAtAction(nameof(Get), new { command.Id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UpdateProduct command)
    {
        await _updateProductHandler.HandleAsync(command with { Id = id });
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await _deleteProductHandler.HandleAsync(new DeleteProduct(id));
        return NoContent();
    }
}