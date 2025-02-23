﻿using E_Commerce.DtoLayer.CatalogDtos.FeatureDtos;
using E_Commerce.WebUI.Services.CatalogServices.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
