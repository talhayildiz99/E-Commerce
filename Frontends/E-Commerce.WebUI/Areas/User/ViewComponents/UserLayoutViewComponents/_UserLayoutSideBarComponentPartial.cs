﻿using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
