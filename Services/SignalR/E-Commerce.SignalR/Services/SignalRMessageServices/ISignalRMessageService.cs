namespace E_Commerce.SignalR.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
