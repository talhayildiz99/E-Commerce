using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
