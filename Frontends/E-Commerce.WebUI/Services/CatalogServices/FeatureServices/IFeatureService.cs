using E_Commerce.DtoLayer.CatalogDtos.FeatureDtos;

namespace E_Commerce.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
    }
}
