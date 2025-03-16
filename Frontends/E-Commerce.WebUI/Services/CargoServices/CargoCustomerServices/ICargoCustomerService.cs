using E_Commerce.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace E_Commerce.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
