using E_Commerce.DtoLayer.CatalogDtos.TopDiscountDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/TopDiscount")]
    public class TopDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TopDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Özel İndirimler";
            @ViewBag.v3 = "Özel İndirim Listesi";
            @ViewBag.v0 = "Özel İndirim İşlemleri";

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

        [HttpGet]
        [Route("CreateTopDiscount")]
        public IActionResult CreateTopDiscount()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Özel İndirimler";
            @ViewBag.v3 = "Özel İndirim Listesi";
            @ViewBag.v0 = "Özel İndirim İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateTopDiscount")]
        public async Task<IActionResult> CreateTopDiscount(CreateTopDiscountDto createTopDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTopDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7060/api/TopDiscounts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "TopDiscount", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteTopDiscount/{id}")]
        public async Task<IActionResult> DeleteTopDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7060/api/TopDiscounts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "TopDiscount", new { area = "Admin" });
            }
            return View();
        }


        [HttpGet]
        [Route("UpdateTopDiscount/{id}")]
        public async Task<IActionResult> UpdateTopDiscount(string id)
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Özel İndirimler";
            @ViewBag.v3 = "Özel İndirim Listesi";
            @ViewBag.v0 = "Özel İndirim İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/TopDiscounts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTopDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateTopDiscount/{id}")]

        public async Task<IActionResult> UpdateTopDiscount(UpdateTopDiscountDto updateTopDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTopDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7060/api/TopDiscounts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "TopDiscount", new { area = "Admin" });
            }
            return View();
        }
    }
}
