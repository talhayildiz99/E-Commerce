using E_Commerce.DtoLayer.CatalogDtos.VendorDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Vendor")]
    public class VendorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VendorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";
            @ViewBag.v0 = "Marka İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/Vendors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVendorDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateVendor")]
        public IActionResult CreateVendor()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";
            @ViewBag.v0 = "Marka İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createVendorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7060/api/Vendors", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteVendor/{id}")]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7060/api/Vendors?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateVendor/{id}")]
        public async Task<IActionResult> UpdateVendor(string id)
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";
            @ViewBag.v0 = "Marka İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/Vendors/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateVendorDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateVendor/{id}")]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateVendorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7060/api/Vendors/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }
    }
}
