using E_Commerce.DtoLayer.CatalogDtos.VendorDtos;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.Services.CatalogServices.VendorServices
{
    public class VendorService : IVendorService
    {
        private readonly HttpClient _httpClient;

        public VendorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateVendorAsync(CreateVendorDto createVendorDto)
        {
            await _httpClient.PostAsJsonAsync<CreateVendorDto>("vendors", createVendorDto);
        }

        public async Task DeleteVendorAsync(string id)
        {
            await _httpClient.DeleteAsync("vendors?id=" + id);
        }

        public async Task<UpdateVendorDto> GetByIdVendorAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("vendors/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateVendorDto>();
            return values;
        }

        public async Task<List<ResultVendorDto>> GetAllVendorAsync()
        {
            var responseMessage = await _httpClient.GetAsync("vendors");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultVendorDto>>(jsonData);
            return values;
        }

        public async Task UpdateVendorAsync(UpdateVendorDto updateVendorDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateVendorDto>("vendors", updateVendorDto);
        }

    }
}
