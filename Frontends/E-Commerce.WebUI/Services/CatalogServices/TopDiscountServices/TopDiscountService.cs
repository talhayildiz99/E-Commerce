using E_Commerce.DtoLayer.CatalogDtos.TopDiscountDtos;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.Services.CatalogServices.TopDiscountServices
{
    public class TopDiscountService : ITopDiscountService
    {
        private readonly HttpClient _httpClient;

        public TopDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateTopDiscountAsync(CreateTopDiscountDto createTopDiscountDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateTopDiscountDto>("topdiscounts", createTopDiscountDto);
        }

        public async Task DeleteTopDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("topdiscounts?id=" + id);
        }

        public async Task<List<ResultTopDiscountDto>> GetAllTopDiscountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("topdiscounts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTopDiscountDto>>(jsonData);
            return values;
        }

        public async Task<UpdateTopDiscountDto> GetByIdTopDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("topdiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateTopDiscountDto>();
            return values;
        }

        public async Task UpdateTopDiscountAsync(UpdateTopDiscountDto updateTopDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateTopDiscountDto>("topdiscounts", updateTopDiscountDto);
        }
    }
}
