using ProductService.Api.Dtos;
using ProductService.Api.Models;
using ProductService.Api.Repositories;

namespace ProductService.Api.Services;

public class ProductServiceImpl : IProductService
{
    private readonly IProductRepository _repo;
    public ProductServiceImpl(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };
        return await _repo.CreateAsync(product);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repo.DeleteAsync(id);
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

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return null;
        var productsDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
        return productsDto;
    }

    public Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = new Product
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };
        return _repo.UpdateAsync(id, product);
    }
}
