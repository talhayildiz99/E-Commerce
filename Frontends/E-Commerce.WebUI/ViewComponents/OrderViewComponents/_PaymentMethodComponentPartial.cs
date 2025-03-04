using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
