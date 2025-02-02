using E_Commerce.Catalog.Dtos.TopDiscountDtos;

namespace E_Commerce.Catalog.Services.TopDiscountServices
{
    public interface ITopDiscountService
    {
        Task<List<ResultTopDiscountDto>> GetAllTopDiscountAsync();
        Task CreateTopDiscountAsync(CreateTopDiscountDto createTopDiscountDto);
        Task UpdateTopDiscountAsync(UpdateTopDiscountDto updateTopDiscountDto);
        Task DeleteTopDiscountAsync(string id);
        Task<GetByIdTopDiscountDto> GetByIdTopDiscountAsync(string id);
    }
}
