using E_Commerce.Catalog.Dtos.ProductImageDtos;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto productImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto productImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);

    }
}
