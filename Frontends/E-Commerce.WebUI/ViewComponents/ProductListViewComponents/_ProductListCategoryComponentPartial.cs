using E_Commerce.DtoLayer.CatalogDtos.CategoryDtos;
using E_Commerce.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListCategoryComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _ProductListCategoryComponentPartial(ICategoryService categoryService)
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
