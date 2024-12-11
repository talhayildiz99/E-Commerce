using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
