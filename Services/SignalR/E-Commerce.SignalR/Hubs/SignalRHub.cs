using E_Commerce.SignalR.Services.SignalRCommentServices;
using Microsoft.AspNetCore.SignalR;

namespace E_Commerce.SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
        }
    }
}
