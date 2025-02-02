using E_Commerce.Catalog.Dtos.TopDiscountDtos;
using E_Commerce.Catalog.Services.TopDiscountServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TopDiscountsController : ControllerBase
    {
        private readonly ITopDiscountService _topDiscountService;

        public TopDiscountsController(ITopDiscountService topDiscountService)
        {
            _topDiscountService = topDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> TopDiscountList()
        {
            var values = await _topDiscountService.GetAllTopDiscountAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopDiscountById(string id)
        {
            var values = await _topDiscountService.GetByIdTopDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopDiscount(CreateTopDiscountDto createTopDiscountDto)
        {
            await _topDiscountService.CreateTopDiscountAsync(createTopDiscountDto);
            return Ok("Öne çıkan indirim başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTopDiscount(string id)
        {
            await _topDiscountService.DeleteTopDiscountAsync(id);
            return Ok("Öne çıkan indirim başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopDiscount(UpdateTopDiscountDto updateTopDiscountDto)
        {
            await _topDiscountService.UpdateTopDiscountAsync(updateTopDiscountDto);
            return Ok("Öne çıkan indirim başarıyla güncellendi");
        }

    }
}
