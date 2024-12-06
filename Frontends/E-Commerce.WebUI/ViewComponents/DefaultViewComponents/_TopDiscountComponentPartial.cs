using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _TopDiscountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
