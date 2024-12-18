using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
