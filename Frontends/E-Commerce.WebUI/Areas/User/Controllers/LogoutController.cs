using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.User.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
