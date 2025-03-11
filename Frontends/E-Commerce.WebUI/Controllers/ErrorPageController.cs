using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
