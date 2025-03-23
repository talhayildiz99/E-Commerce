namespace E_Commerce.Catalog.Services.StatisticServices
{
    public interface IStatisticservice
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetVendorCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
