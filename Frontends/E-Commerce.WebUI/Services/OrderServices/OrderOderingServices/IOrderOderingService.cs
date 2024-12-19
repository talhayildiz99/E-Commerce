using E_Commerce.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace E_Commerce.WebUI.Services.OrderServices.OrderOderingServices
{
    public interface IOrderOderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
