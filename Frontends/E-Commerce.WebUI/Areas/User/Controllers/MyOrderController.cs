using Microsoft.AspNetCore.Mvc;
using E_Commerce.WebUI.Services.Interfaces;
using E_Commerce.WebUI.Services.OrderServices.OrderOderingServices;

namespace E_Commerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOderingService _orderOderingService;
        private readonly IUserService _userService;
        public MyOrderController(IOrderOderingService orderOderingService, IUserService userService)
        {
            _orderOderingService = orderOderingService;
            _userService = userService;
        }
        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderOderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}
