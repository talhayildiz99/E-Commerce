using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
