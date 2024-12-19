using E_Commerce.DtoLayer.DiscountDtos;

namespace E_Commerce.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
