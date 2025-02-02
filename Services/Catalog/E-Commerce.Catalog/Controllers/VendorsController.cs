using E_Commerce.Catalog.Dtos.VendorDtos;
using E_Commerce.Catalog.Services.VendorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> VendorList()
        {
            var values = await _vendorService.GetAllVendorAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorById(string id)
        {
            var values = await _vendorService.GetByIdVendorAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            await _vendorService.CreateVendorAsync(createVendorDto);
            return Ok("Marka başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            await _vendorService.DeleteVendorAsync(id);
            return Ok("Marka başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            await _vendorService.UpdateVendorAsync(updateVendorDto);
            return Ok("Marka başarıyla güncellendi");
        }

    }
}
