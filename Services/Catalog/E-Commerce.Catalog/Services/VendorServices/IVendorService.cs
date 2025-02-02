using E_Commerce.Catalog.Dtos.VendorDtos;

namespace E_Commerce.Catalog.Services.VendorServices
{
    public interface IVendorService
    {
        Task<List<ResultVendorDto>> GetAllVendorAsync();
        Task CreateVendorAsync(CreateVendorDto createVndorDto);
        Task UpdateVendorAsync(UpdateVendorDto updateVendorDto);
        Task DeleteVendorAsync(string id);
        Task<GetByIdVendorDto> GetByIdVendorAsync(string id);

    }
}
