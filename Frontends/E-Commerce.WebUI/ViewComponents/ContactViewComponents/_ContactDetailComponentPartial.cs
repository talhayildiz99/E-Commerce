using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
