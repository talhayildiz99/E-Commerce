namespace E_Commerce.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();
    }
}
