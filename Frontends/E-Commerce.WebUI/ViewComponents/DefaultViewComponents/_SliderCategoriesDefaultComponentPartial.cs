using E_Commerce.DtoLayer.CatalogDtos.CategoryDtos;
using E_Commerce.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SliderCategoriesDefaultComponentPartial: ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _SliderCategoriesDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
