using E_Commerce.WebUI.Models;
using E_Commerce.WebUI.Services.Interfaces;

namespace E_Commerce.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
    }
}
