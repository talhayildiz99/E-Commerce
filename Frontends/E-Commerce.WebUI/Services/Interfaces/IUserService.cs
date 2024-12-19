using E_Commerce.WebUI.Models;

namespace E_Commerce.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
