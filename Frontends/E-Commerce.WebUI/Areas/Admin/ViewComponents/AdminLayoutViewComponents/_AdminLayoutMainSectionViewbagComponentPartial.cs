using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMainSectionViewbagComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
