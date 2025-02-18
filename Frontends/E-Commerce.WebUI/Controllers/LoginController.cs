﻿using E_Commerce.DtoLayer.IdentityDtos.LoginDtos;
using E_Commerce.WebUI.Models;
using E_Commerce.WebUI.Services;
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
		private readonly ILoginService _loginService;
		private readonly IIdentityService _ıdentityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService ıdentityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _ıdentityService = ıdentityService;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(createLoginDto),Encoding.UTF8,	"application/json");
			var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				if (tokenModel != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();

					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("e-commercetoken", tokenModel.Token));
						var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
						var authProps = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true
						};

						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity), authProps);
                        var id = _loginService.GetUserId;
                        return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}


		//[HttpGet]
		//public IActionResult SignIn()
		//{
		//	return View();
		//}

		//[HttpPost]
		public async Task<IActionResult> SignIn(SignInDto signInDto)
		{
			signInDto.Username = "talha.yildiz";
			signInDto.Password = "123456789Bb*";
			await _ıdentityService.SignIn(signInDto);
			return RedirectToAction("Index", "Test");
		}
	}
}
