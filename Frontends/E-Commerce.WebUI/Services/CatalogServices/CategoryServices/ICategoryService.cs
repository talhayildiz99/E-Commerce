using E_Commerce.DtoLayer.CatalogDtos.CategoryDtos;

namespace E_Commerce.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<UpdateCategoryDto> GetByIdCategoryAsync(string id);
    }
}
