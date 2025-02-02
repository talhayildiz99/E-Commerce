using E_Commerce.DtoLayer.CatalogDtos.TopDiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _TopDiscountComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TopDiscountComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/TopDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTopDiscountDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
