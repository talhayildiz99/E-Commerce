using E_Commerce.DtoLayer.DiscountDtos;

namespace E_Commerce.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7061/api/Discount/GetCodeDetailByCodeAsync?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7061/api/Discount/GetDiscountCouponCountRate?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
