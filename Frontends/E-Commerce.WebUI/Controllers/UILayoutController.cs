using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
