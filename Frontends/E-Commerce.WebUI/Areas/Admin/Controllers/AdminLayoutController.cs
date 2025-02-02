using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
