using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "Anasayfa"; 
            ViewBag.directory2 = "Ürün Listesi"; 
            return View();
        }
    }
}
