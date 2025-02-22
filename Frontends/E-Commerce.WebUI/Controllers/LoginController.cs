using E_Commerce.DtoLayer.IdentityDtos.LoginDtos;
using E_Commerce.WebUI.Models;
using E_Commerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace E_Commerce.WebUI.Controllers
{
    public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IIdentityService _ıdentityService;

        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService ıdentityService)
        {
            _httpClientFactory = httpClientFactory;
            _ıdentityService = ıdentityService;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SignInDto signInDto)
		{
            await _ıdentityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
		}
	}
}
