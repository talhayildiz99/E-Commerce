﻿using E_Commerce.Catalog.Dtos.ProductDetailDtos;

namespace E_Commerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);

    }
}
