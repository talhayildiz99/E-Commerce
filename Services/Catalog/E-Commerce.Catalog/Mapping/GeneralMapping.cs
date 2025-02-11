using AutoMapper;
using E_Commerce.Catalog.Dtos.AboutDtos;
using E_Commerce.Catalog.Dtos.CategoryDtos;
using E_Commerce.Catalog.Dtos.ContactDtos;
using E_Commerce.Catalog.Dtos.FeatureDtos;
using E_Commerce.Catalog.Dtos.FeatureSliderDtos;
using E_Commerce.Catalog.Dtos.ProductDetailDtos;
using E_Commerce.Catalog.Dtos.ProductDtos;
using E_Commerce.Catalog.Dtos.ProductImageDtos;
using E_Commerce.Catalog.Dtos.TopDiscountDtos;
using E_Commerce.Catalog.Dtos.VendorDtos;
using E_Commerce.Catalog.Entities;

namespace E_Commerce.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<TopDiscount, ResultTopDiscountDto>().ReverseMap();
            CreateMap<TopDiscount, CreateTopDiscountDto>().ReverseMap();
            CreateMap<TopDiscount, UpdateTopDiscountDto>().ReverseMap();
            CreateMap<TopDiscount, GetByIdTopDiscountDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Vendor, ResultVendorDto>().ReverseMap();
            CreateMap<Vendor, CreateVendorDto>().ReverseMap();
            CreateMap<Vendor, UpdateVendorDto>().ReverseMap();
            CreateMap<Vendor, GetByIdVendorDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
        }
    }
}
