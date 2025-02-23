using E_Commerce.DtoLayer.CatalogDtos.TopDiscountDtos;
using E_Commerce.WebUI.Services.CatalogServices.TopDiscountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _TopDiscountComponentPartial : ViewComponent
    {
        private readonly ITopDiscountService _topDiscountService;

        public _TopDiscountComponentPartial(ITopDiscountService topDiscountService)
        {
            _topDiscountService = topDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _topDiscountService.GetAllTopDiscountAsync();
            return View(values);
        }
    }
}
