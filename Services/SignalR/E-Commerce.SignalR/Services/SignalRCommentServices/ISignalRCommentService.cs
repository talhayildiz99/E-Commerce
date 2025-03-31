namespace E_Commerce.SignalR.Services.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
