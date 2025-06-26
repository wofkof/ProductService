using ProductService.Api.Dtos;
using ProductService.Api.Repositories;

namespace ProductService.Api.Services;

public class ProductServiceImpl : IProductService
{
    private readonly IProductRepository _repo;
    public ProductServiceImpl(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        var productsDto = products.Select(p =>
        new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        });
        return productsDto;
    }
}
