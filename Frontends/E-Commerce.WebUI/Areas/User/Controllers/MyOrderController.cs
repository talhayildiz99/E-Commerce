using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        public IActionResult MyOrderList()
        {
            return View();
        }
    }
}
