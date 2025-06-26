using ProductService.Api.Dtos;

namespace ProductService.Api.Services;

public interface IProductService
{
    Task <IEnumerable<ProductDto>> GetAllAsync();
}