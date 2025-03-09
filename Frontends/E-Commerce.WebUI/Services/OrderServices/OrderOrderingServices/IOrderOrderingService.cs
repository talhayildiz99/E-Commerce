using E_Commerce.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace E_Commerce.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
