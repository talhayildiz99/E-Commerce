using E_Commerce.DtoLayer.CatalogDtos.TopDiscountDtos;
using E_Commerce.WebUI.Services.CatalogServices.TopDiscountServices;
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
        private readonly ITopDiscountService _topDiscountService;
        public TopDiscountController(ITopDiscountService topDiscountService)
        {
            _topDiscountService = topDiscountService;
        }

        void TopDiscountViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Özel İndirim ve Günün Teklif Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            TopDiscountViewBagList();
            var values = await _topDiscountService.GetAllTopDiscountAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateTopDiscount")]
        public IActionResult CreateTopDiscount()
        {
            TopDiscountViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateTopDiscount")]
        public async Task<IActionResult> CreateTopDiscount(CreateTopDiscountDto createTopDiscountDto)
        {
            await _topDiscountService.CreateTopDiscountAsync(createTopDiscountDto);
            return RedirectToAction("Index", "TopDiscount", new { area = "Admin" });
        }

        [Route("DeleteTopDiscount/{id}")]
        public async Task<IActionResult> DeleteTopDiscount(string id)
        {
            await _topDiscountService.DeleteTopDiscountAsync(id);
            return RedirectToAction("Index", "TopDiscount", new { area = "Admin" });
        }

        [Route("UpdateTopDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateTopDiscount(string id)
        {
            TopDiscountViewBagList();
            var values = await _topDiscountService.GetByIdTopDiscountAsync(id);
            return View(values);
        }

        [Route("UpdateTopDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateTopDiscount(UpdateTopDiscountDto updateTopDiscountDto)
        {
            await _topDiscountService.UpdateTopDiscountAsync(updateTopDiscountDto);
            return RedirectToAction("Index", "TopDiscount", new { area = "Admin" });
        }
    }
}
