using E_Commerce.DtoLayer.CatalogDtos.VendorDtos;
using E_Commerce.WebUI.Services.CatalogServices.VendorServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IVendorService _vendorService;
        public _VendorDefaultComponentPartial(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _vendorService.GetAllVendorAsync();
            return View(values);
        }
    }
}
