using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
