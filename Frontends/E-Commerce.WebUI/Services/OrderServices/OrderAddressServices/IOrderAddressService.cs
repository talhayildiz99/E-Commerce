﻿using E_Commerce.DtoLayer.OrderDtos.OrderAddressDtos;

namespace E_Commerce.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        // Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //    Task DeleteAboutAsync(string id);
        //    Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}
