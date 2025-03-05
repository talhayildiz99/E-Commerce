using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "Ödeme Ekranı";
            ViewBag.directory2 = "Kart İle Ödeme";
            return View();
        }
    }
}
