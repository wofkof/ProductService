using Microsoft.AspNetCore.Mvc;
using ProductService.Api.Services;

namespace ProductService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}