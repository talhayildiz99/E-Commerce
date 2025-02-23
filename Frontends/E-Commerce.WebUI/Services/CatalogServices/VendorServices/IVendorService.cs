using E_Commerce.DtoLayer.CatalogDtos.VendorDtos;

namespace E_Commerce.WebUI.Services.CatalogServices.VendorServices
{
    public interface IVendorService
    {
        Task<List<ResultVendorDto>> GetAllVendorAsync();
        Task CreateVendorAsync(CreateVendorDto createVendorDto);
        Task UpdateVendorAsync(UpdateVendorDto updateVendorDto);
        Task DeleteVendorAsync(string id);
        Task<UpdateVendorDto> GetByIdVendorAsync(string id);

    }
}
