using E_Commerce.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Öne Çıkanlar";
            @ViewBag.v3 = "Öne Çıkanlar Listesi";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Öne Çıkanlar";
            @ViewBag.v3 = "Öne Çıkanlar Listesi";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7060/api/FeatureSliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7060/api/FeatureSliders?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }


        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Öne Çıkanlar";
            @ViewBag.v3 = "Öne Çıkanlar Listesi";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/FeatureSliders/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]

        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7060/api/FeatureSliders/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
