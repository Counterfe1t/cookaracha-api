using Cookaracha.Application.Commands;
using Cookaracha.Application.Dtos;
using Cookaracha.Application.Interfaces;
using Cookaracha.Core.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        => Ok(await _productsService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
    {
        var result = await _productsService.GetAsync(id);

        return result is not null
            ? Ok(result)
            : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateProduct command)
    {
        var result = await _productsService.CreateProductAsync(command with { Id = ProductId.Create() });

        return result is not null
            ? CreatedAtAction(nameof(Post), result)
            : BadRequest();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UpdateProduct command)
        => await _productsService.UpdateProductAsync(command with { Id = id })
            ? NoContent()
            : BadRequest();

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
        => await _productsService.DeleteProductAsync(new DeleteProduct(id))
            ? NoContent()
            : NotFound();
}