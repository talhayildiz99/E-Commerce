using E_Commerce.DtoLayer.CatalogDtos.TopDiscountDtos;

namespace E_Commerce.WebUI.Services.CatalogServices.TopDiscountServices
{
    public interface ITopDiscountService
    {
        Task<List<ResultTopDiscountDto>> GetAllTopDiscountAsync();
        Task CreateTopDiscountAsync(CreateTopDiscountDto createTopDiscountDto);
        Task UpdateTopDiscountAsync(UpdateTopDiscountDto updateTopDiscountDto);
        Task DeleteTopDiscountAsync(string id);
        Task<UpdateTopDiscountDto> GetByIdTopDiscountAsync(string id);

    }
}
