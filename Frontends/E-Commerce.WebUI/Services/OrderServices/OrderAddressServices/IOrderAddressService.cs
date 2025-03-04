using E_Commerce.DtoLayer.OrderDtos.OrderAddressDtos;

namespace E_Commerce.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    { 
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
