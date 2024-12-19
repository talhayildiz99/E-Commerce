using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
