using Cookaracha.Application.Dtos;
using Cookaracha.Application.Interfaces;
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
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get() => Ok(await _productsService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
    {
        var result = await _productsService.GetAsync(id);
        
        return result is null
            ? NotFound()
            : Ok(result);
    }
}