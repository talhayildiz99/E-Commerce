using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
