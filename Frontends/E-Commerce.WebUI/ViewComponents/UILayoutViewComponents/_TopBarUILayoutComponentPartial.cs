using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopBarUILayoutComponentPartial : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
