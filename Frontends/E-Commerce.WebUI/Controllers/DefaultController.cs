using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
