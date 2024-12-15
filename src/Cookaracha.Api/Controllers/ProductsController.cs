using Cookaracha.Application.Commands;
using Cookaracha.Application.DTO;
using Cookaracha.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult> Post([FromBody] CreateProduct command)
    {
        command = command with { Id = Guid.NewGuid() };
        await _productsService.CreateProductAsync(command);

        return CreatedAtAction(nameof(Get), new { command.Id }, null);
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