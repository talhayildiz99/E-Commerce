﻿using E_Commerce.WebUI.Services.BasketServices;
using E_Commerce.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCouponCountRate(code);

            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;

            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
            // ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
