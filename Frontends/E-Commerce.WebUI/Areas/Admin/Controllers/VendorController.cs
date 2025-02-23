using E_Commerce.DtoLayer.CatalogDtos.VendorDtos;
using E_Commerce.WebUI.Services.CatalogServices.VendorServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Vendor")]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            VendorViewBagList();
            var values = await _vendorService.GetAllVendorAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateVendor")]
        public IActionResult CreateVendor()
        {
            VendorViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            await _vendorService.CreateVendorAsync(createVendorDto);
            return RedirectToAction("Index", "Vendor", new { area = "Admin" });
        }

        [Route("DeleteVendor/{id}")]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            await _vendorService.DeleteVendorAsync(id);
            return RedirectToAction("Index", "Vendor", new { area = "Admin" });
        }

        [Route("UpdateVendor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVendor(string id)
        {
            VendorViewBagList();
            var values = await _vendorService.GetByIdVendorAsync(id);
            return View(values);
        }

        [Route("UpdateVendor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            await _vendorService.UpdateVendorAsync(updateVendorDto);
            return RedirectToAction("Index", "Vendor", new { area = "Admin" });
        }
        void VendorViewBagList()
        {
            @ViewBag.v1 = "Ana Sayfa";
            @ViewBag.v2 = "Markalar";
            @ViewBag.v3 = "Marka Listesi";
            @ViewBag.v0 = "Marka İşlemleri";
        }
    }
}
