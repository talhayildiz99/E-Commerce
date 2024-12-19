using Microsoft.AspNetCore.Mvc;
using E_Commerce.WebUI.Services.CommentServices;
using E_Commerce.WebUI.Services.Interfaces;
using E_Commerce.WebUI.Services.MessageServices;

namespace E_Commerce.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
            ViewBag.messageCount = messageCount;

            int totalCommentcount = await _commentService.GetTotalCommentCount();
            ViewBag.totalCommentCount = totalCommentcount;  

            return View();
        }
    }
}
